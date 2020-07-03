using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopFileImplement.Implements
{
    public class StoreHouseLogic : IStoreHouseLogic
    {
        private readonly FileDataListSingleton source;

        public StoreHouseLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(StoreHouseBindingModel model)
        {
            StoreHouse element = source.StoreHouses.FirstOrDefault(rec => rec.StoreHouseName == model.StoreHouseName && rec.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть склад с таким названием");
            if (model.Id.HasValue)
            {
                element = source.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                    throw new Exception("Элемент не найден");
            }
            else
            {
                int maxId = source.StoreHouses.Count > 0 ? source.StoreHouses.Max(rec => rec.Id) : 0;
                element = new StoreHouse { Id = maxId + 1 };
                source.StoreHouses.Add(element);
            }
            element.StoreHouseName = model.StoreHouseName;
        }

        public List<StoreHouseViewModel> Read(StoreHouseBindingModel model)
        {
            return source.StoreHouses
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new StoreHouseViewModel
                {
                    Id = rec.Id,
                    StoreHouseName = rec.StoreHouseName,
                    StoreHouseIngredients = source.StoreHouseIngredients
                    .Where(recSI => recSI.StoreHouseId == rec.Id)
                    .ToDictionary(recSI => recSI.IngredientId, recSI =>
                    (source.Ingredients.FirstOrDefault(recI => recI.Id == recSI.IngredientId)?.IngredientName, recSI.Count))
                })
                .ToList();
        }

        public void Delete(StoreHouseBindingModel model)
        {
            // удаляем записи по ингредиентам при удалении склада
            source.StoreHouseIngredients.RemoveAll(rec => rec.StoreHouseId == model.Id);
            StoreHouse element = source.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
                source.StoreHouses.Remove(element);
            else
                throw new Exception("Элемент не найден");
        }

        public void AddIngredient(StoreHouseIngredientBindingModel model)
        {
            StoreHouseIngredient si = source.StoreHouseIngredients.FirstOrDefault(rec => rec.StoreHouseId == model.StoreHouseId
                && rec.IngredientId == model.IngredientId);
            if (si != null)
            {
                si.Count += model.Count;
                return;
            }
            source.StoreHouseIngredients.Add(new StoreHouseIngredient
            {
                Id = source.StoreHouseIngredients.Count + 1,
                IngredientId = model.IngredientId,
                StoreHouseId = model.StoreHouseId,
                Count = model.Count
            });
        }

        public StoreHouseViewModel ReadStoreHouse(int id)
        {
            // требуется дополнительно получить список ингредиентов с названиями и их количество
            Dictionary<int, (string, int)> ingredients = new Dictionary<int, (string, int)>();
            foreach (var si in source.StoreHouseIngredients)
                if (si.StoreHouseId == id)
                {
                    string ingredientName = source.Ingredients.FirstOrDefault(rec => rec.Id == si.IngredientId).IngredientName;
                    ingredients.Add(si.IngredientId, (ingredientName, si.Count));
                }
            string storeHouseName = source.StoreHouses.FirstOrDefault(rec => rec.Id == id).StoreHouseName;
            return new StoreHouseViewModel
            {
                Id = id,
                StoreHouseName = storeHouseName,
                StoreHouseIngredients = ingredients
            };
        }

        public bool IsIngredientsAvailable(int productId, int countProduct)
        {
            var productIngredients = source.ProductIngredients.Where(rec => rec.ProductId == productId);
            if (productIngredients.Count() == 0) return false;
            foreach (var pi in productIngredients)
            {
                var storeHouseIngredient = source.StoreHouseIngredients.Where(rec => rec.IngredientId == pi.IngredientId);
                if (storeHouseIngredient.Sum(rec => rec.Count) < countProduct * pi.Count)
                    return false;
            }
            return true;
        }

        public void SubtractIngredients(int productId, int countProduct)
        {
            var productIngredients = source.ProductIngredients.Where(rec => rec.ProductId == productId);
            foreach (var pi in productIngredients)
            {
                var storeHouseIngredient = source.StoreHouseIngredients.Where(rec => rec.IngredientId == pi.IngredientId);
                int ingredientCount = countProduct * pi.Count;
                foreach (var si in storeHouseIngredient)
                {
                    if (si.Count > ingredientCount)
                    {
                        si.Count -= ingredientCount;
                        break;
                    }
                    ingredientCount -= si.Count;
                    si.Count = 0;
                }
            }
        }
    }
}