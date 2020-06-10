using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement.Implements
{
    public class StoreHouseLogic : IStoreHouseLogic
    {
        private readonly DataListSingleton source;

        public StoreHouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(StoreHouseBindingModel model)
        {
            StoreHouse tempStoreHouse = model.Id.HasValue ? null : new StoreHouse { Id = 1 };
            foreach (var storeHouse in source.StoreHouses)
            {
                if (storeHouse.StoreHouseName == model.StoreHouseName && storeHouse.Id != model.Id)
                    throw new Exception("Уже есть склад с таким названием");
                if (!model.Id.HasValue && storeHouse.Id >= tempStoreHouse.Id)
                    tempStoreHouse.Id = storeHouse.Id + 1;
                else if (model.Id.HasValue && storeHouse.Id == model.Id)
                    tempStoreHouse = storeHouse;
            }
            if (model.Id.HasValue)
            {
                if (tempStoreHouse == null)
                    throw new Exception("Элемент не найден");
                CreateModel(model, tempStoreHouse);
            }
            else
                source.StoreHouses.Add(CreateModel(model, tempStoreHouse));
        }

        public List<StoreHouseViewModel> Read(StoreHouseBindingModel model)
        {
            List<StoreHouseViewModel> result = new List<StoreHouseViewModel>();
            foreach (var storeHouse in source.StoreHouses)
            {
                if (model != null)
                {
                    if (storeHouse.Id == model.Id)
                    {
                        result.Add(CreateViewModel(storeHouse));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(storeHouse));
            }
            return result;
        }

        public void Delete(StoreHouseBindingModel model)
        {
            // удаляем записи по ингредиентам при удалении склада
            for (int i = 0; i < source.StoreHouseIngredients.Count; ++i)
                if (source.StoreHouseIngredients[i].StoreHouseId == model.Id)
                    source.StoreHouseIngredients.RemoveAt(i--);
            for (int i = 0; i < source.StoreHouses.Count; ++i)
                if (source.StoreHouses[i].Id == model.Id)
                {
                    source.StoreHouses.RemoveAt(i);
                    return;
                }
            throw new Exception("Элемент не найден");
        }

        public void AddIngredient(StoreHouseIngredientBindingModel model)
        {
            foreach (var storeHouse in source.StoreHouseIngredients)
            {
                if (storeHouse.StoreHouseId == model.StoreHouseId && storeHouse.IngredientId == model.IngredientId)
                {
                    storeHouse.Count += model.Count;
                    return;
                }
            }
            source.StoreHouseIngredients.Add(new StoreHouseIngredient
            {
                Id = source.StoreHouseIngredients.Count + 1,
                IngredientId = model.IngredientId,
                StoreHouseId = model.StoreHouseId,
                Count = model.Count
            });
        }

        private StoreHouseViewModel CreateViewModel(StoreHouse storeHouse)
        {
            // требуется дополнительно получить список ингредиентов на складе с названиями и их количество
            Dictionary<int, (string, int)> storeHouseIngredient = new Dictionary<int, (string, int)>();

            foreach (var si in source.StoreHouseIngredients)
                if (si.StoreHouseId == storeHouse.Id)
                {
                    string ingredientName = string.Empty;
                    foreach (var ingredient in source.Ingredients)
                        if (si.IngredientId == ingredient.Id)
                        {
                            ingredientName = ingredient.IngredientName;
                            break;
                        }
                    storeHouseIngredient.Add(si.IngredientId, (ingredientName, si.Count));
                }
            return new StoreHouseViewModel
            {
                Id = storeHouse.Id,
                StoreHouseName = storeHouse.StoreHouseName,
                StoreHouseIngredients = storeHouseIngredient
            };
        }

        private StoreHouse CreateModel(StoreHouseBindingModel model, StoreHouse storeHouse)
        {
            storeHouse.StoreHouseName = model.StoreHouseName;
            return storeHouse;
        }

        public StoreHouseViewModel ReadStoreHouse(int id)
        {
            // требуется дополнительно получить список ингредиентов с названиями и их количество
            Dictionary<int, (string, int)> ingredients = new Dictionary<int, (string, int)>();
            foreach (var si in source.StoreHouseIngredients)
                if (si.StoreHouseId == id)
                {
                    string ingredientName = string.Empty;
                    foreach (var ingredient in source.Ingredients)
                        if (si.IngredientId == ingredient.Id)
                        {
                            ingredientName = ingredient.IngredientName;
                            break;
                        }
                    ingredients.Add(si.IngredientId, (ingredientName, si.Count));
                }
            string storeHouseName = "";
            foreach (var s in source.StoreHouses)
                if (s.Id == id)
                {
                    storeHouseName = s.StoreHouseName;
                    break;
                }
            return new StoreHouseViewModel
            {
                Id = id,
                StoreHouseName = storeHouseName,
                StoreHouseIngredients = ingredients
            };
        }
    }
}