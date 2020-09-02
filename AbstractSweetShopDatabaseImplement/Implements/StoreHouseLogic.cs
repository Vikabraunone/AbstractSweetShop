using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using AbstractSweetShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopDatabaseImplement.Implements
{
    public class StoreHouseLogic : IStoreHouseLogic
    {
        public void CreateOrUpdate(StoreHouseBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                StoreHouse element = context.StoreHouses.FirstOrDefault(rec => rec.StoreHouseName == model.StoreHouseName && rec.Id != model.Id);
                if (element != null)
                    throw new Exception("Уже есть склад с таким названием");
                if (model.Id.HasValue)
                {
                    element = context.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                        throw new Exception("Склад не найден");
                }
                else
                {
                    element = new StoreHouse();
                    context.StoreHouses.Add(element);
                }
                element.StoreHouseName = model.StoreHouseName;
                context.SaveChanges();
            }
        }

        public void Delete(StoreHouseBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаляем записи по ингредиентам при удалении склада
                        context.StoreHouseIngredients.RemoveRange(context.StoreHouseIngredients.Where(rec => rec.StoreHouseId == model.Id));
                        StoreHouse element = context.StoreHouses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.StoreHouses.Remove(element);
                            context.SaveChanges();
                        }
                        else
                            throw new Exception("Склад не найден");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<StoreHouseViewModel> Read(StoreHouseBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                return context.StoreHouses
                     .Where(rec => model == null || rec.Id == model.Id)
                     .ToList()
                     .Select(rec => new StoreHouseViewModel
                     {
                         Id = rec.Id,
                         StoreHouseName = rec.StoreHouseName
                     })
                     .ToList();
            }
        }

        public StoreHouseViewModel ReadStoreHouse(int id)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                StoreHouse element = context.StoreHouses.FirstOrDefault(rec => rec.Id == id);
                if (element == null)
                    throw new Exception("Склад не найден");
                return new StoreHouseViewModel
                {
                    Id = id,
                    StoreHouseName = element.StoreHouseName,
                    StoreHouseIngredients = context.StoreHouseIngredients
                    .Include(recSI => recSI.Ingredient)
                    .Where(recSI => recSI.StoreHouseId == id)
                    .ToDictionary(recSI => recSI.IngredientId, recSI => (recSI.Ingredient?.IngredientName, recSI.Count))
                };
            }
        }

        public void AddIngredient(StoreHouseIngredientBindingModel model)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                StoreHouseIngredient si = context.StoreHouseIngredients.FirstOrDefault(rec => rec.StoreHouseId == model.StoreHouseId
                    && rec.IngredientId == model.IngredientId);
                if (si != null)
                    si.Count += model.Count;
                else
                {
                    si = new StoreHouseIngredient
                    {
                        IngredientId = model.IngredientId,
                        StoreHouseId = model.StoreHouseId,
                        Count = model.Count
                    };
                    context.StoreHouseIngredients.Add(si);
                }
                context.SaveChanges();
            }
        }

        public void SubtractIngredients(int productId, int countProduct)
        {
            using (var context = new AbstractSweetShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<ProductIngredient> productIngredients = context.ProductIngredients.Where(rec => rec.ProductId == productId).ToList();
                        foreach (var ingredient in productIngredients)
                        {
                            var storeHouseIngredients = context.StoreHouseIngredients.Where(rec => rec.IngredientId == ingredient.IngredientId);
                            if (storeHouseIngredients.Sum(rec => rec.Count) < ingredient.Count * countProduct)
                                throw new Exception("Недостаточно ингредиентов для выполнения заказа");
                            int totalCount = ingredient.Count * countProduct;
                            foreach (var si in storeHouseIngredients)
                                if (totalCount > si.Count)
                                {
                                    totalCount -= si.Count;
                                    si.Count = 0;
                                }
                                else
                                {
                                    si.Count -= totalCount;
                                    break;
                                }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}