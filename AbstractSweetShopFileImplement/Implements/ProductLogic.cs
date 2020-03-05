using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopFileImplement.Implements
{
    public class ProductLogic : IProductLogic
    {
        private readonly FileDataListSingleton source;

        public ProductLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.ProductName == model.ProductName && rec.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть кондитерское изделие с таким названием");
            if (model.Id.HasValue)
            {
                element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                    throw new Exception("Элемент не найден");
            }
            else
            {
                int maxId = source.Products.Count > 0 ? source.Ingredients.Max(rec => rec.Id) : 0;
                element = new Product { Id = maxId + 1 };
                source.Products.Add(element);
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.ProductIngredients.RemoveAll(rec =>
                rec.ProductId == model.Id && !model.ProductIngredients.ContainsKey(rec.IngredientId));
            // обновили количество у существующих записей
            var updateComponents = source.ProductIngredients.Where(rec =>
                rec.ProductId == model.Id && model.ProductIngredients.ContainsKey(rec.IngredientId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.ProductIngredients[updateComponent.IngredientId].Item2;
                model.ProductIngredients.Remove(updateComponent.IngredientId);
            }
            // добавили новые
            int maxPCId = source.ProductIngredients.Count > 0 ? source.ProductIngredients.Max(rec => rec.Id) : 0;
            foreach (var pi in model.ProductIngredients)
                source.ProductIngredients.Add(new ProductIngredient
                {
                    Id = ++maxPCId,
                    ProductId = element.Id,
                    IngredientId = pi.Key,
                    Count = pi.Value.Item2
                });
        }

        public void Delete(ProductBindingModel model)
        {
            // удаляем записи по компонентам при удалении кондитерского изделия
            source.ProductIngredients.RemoveAll(rec => rec.ProductId == model.Id);
            Product element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
                source.Products.Remove(element);
            else
                throw new Exception("Элемент не найден");
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            return source.Products
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ProductViewModel
                {
                    Id = rec.Id,
                    ProductName = rec.ProductName,
                    Price = rec.Price,
                    ProductIngredients = source.ProductIngredients
                    .Where(recPC => recPC.ProductId == rec.Id)
                    .ToDictionary(recPC => recPC.IngredientId, recPC =>
                    (source.Ingredients.FirstOrDefault(recC => recC.Id == recPC.IngredientId)?.IngredientName, recPC.Count))
                })
                .ToList();
        }
    }
}