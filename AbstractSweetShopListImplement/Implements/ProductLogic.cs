using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly DataListSingleton source;

        public ProductLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product tempProduct = model.Id.HasValue ? null : new Product { Id = 1 };
            foreach (var product in source.Products)
            {
                if (product.ProductName == model.ProductName && product.Id != model.Id)
                    throw new Exception("Уже есть кондитерское изделие с таким названием");
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                    tempProduct.Id = product.Id + 1;
                else if (model.Id.HasValue && product.Id == model.Id)
                    tempProduct = product;
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                    throw new Exception("Элемент не найден");
                CreateModel(model, tempProduct);
            }
            else
                source.Products.Add(CreateModel(model, tempProduct));
        }

        public void Delete(ProductBindingModel model)
        {
            // удаляем записи по ингредиентам при удалении изделия
            for (int i = 0; i < source.ProductIngredients.Count; ++i)
                if (source.ProductIngredients[i].ProductId == model.Id)
                    source.ProductIngredients.RemoveAt(i--);
            for (int i = 0; i < source.Products.Count; ++i)
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in source.Products)
            {
                if (model != null)
                {
                    if (product.Id == model.Id)
                    {
                        result.Add(CreateViewModel(product));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(product));
            }
            return result;
        }

        private Product CreateModel(ProductBindingModel model, Product product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            //обновляем существуюущие ингредиенты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.ProductIngredients.Count; ++i)
            {
                if (source.ProductIngredients[i].Id > maxPCId)
                    maxPCId = source.ProductIngredients[i].Id;
                if (source.ProductIngredients[i].ProductId == product.Id)
                {
                    // если в модели пришла запись ингредиента с таким id
                    if (model.ProductIngredients.ContainsKey(source.ProductIngredients[i].IngredientId))
                    {
                        // обновляем количество
                        source.ProductIngredients[i].Count =
                            model.ProductIngredients[source.ProductIngredients[i].IngredientId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.ProductIngredients.Remove(source.ProductIngredients[i].IngredientId);
                    }
                    else
                        source.ProductIngredients.RemoveAt(i--);
                }
            }
            // новые записи
            foreach (var pi in model.ProductIngredients)
            {
                source.ProductIngredients.Add(new ProductIngredient
                {
                    Id = ++maxPCId,
                    ProductId = product.Id,
                    IngredientId = pi.Key,
                    Count = pi.Value.Item2
                });
            }
            return product;
        }

        private ProductViewModel CreateViewModel(Product product)
        {
            // требуется дополнительно получить список ингредиентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> productIngredients = new Dictionary<int, (string, int)>();
            foreach (var pi in source.ProductIngredients)
                if (pi.ProductId == product.Id)
                {
                    string ingredientName = string.Empty;
                    foreach (var ingredient in source.Ingredients)
                        if (pi.IngredientId == ingredient.Id)
                        {
                            ingredientName = ingredient.IngredientName;
                            break;
                        }
                    productIngredients.Add(pi.IngredientId, (ingredientName, pi.Count));
                }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductIngredients = productIngredients
            };
        }
    }
}