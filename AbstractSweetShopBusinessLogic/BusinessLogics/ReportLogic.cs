using AbstractSweetShopBusinessLogic.BindingModels;
using AbstractSweetShopBusinessLogic.HelperModels;
using AbstractSweetShopBusinessLogic.Interfaces;
using AbstractSweetShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSweetShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IProductLogic productLogic;

        private readonly IOrderLogic orderLogic;

        private readonly IStoreHouseLogic storeHouseLogic;

        public ReportLogic(IProductLogic productLogic, IOrderLogic orderLogic, IStoreHouseLogic storeHouseLogic)
        {
            this.productLogic = productLogic;
            this.orderLogic = orderLogic;
            this.storeHouseLogic = storeHouseLogic;
        }

        /// <summary>
        /// Получение списка кондитерских изделий с расшифровкой по ингредиентам
        /// </summary>
        /// <returns></returns>
        public List<ReportProductIngredientViewModel> GetProductIngredient()
        {
            var products = productLogic.Read(null);
            var reportList = new List<ReportProductIngredientViewModel>();
            foreach (var product in products)
            {
                reportList.Add(new ReportProductIngredientViewModel
                {
                    ProductName = product.ProductName
                });
                foreach (var ingredient in product.ProductIngredients)
                    reportList.Add(new ReportProductIngredientViewModel
                    {
                        IngredientName = ingredient.Value.Item1,
                        TotalCount = ingredient.Value.Item2
                    });
            }
            return reportList;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var orders = orderLogic.Read(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo });
            return orders
                .GroupBy(x => x.DateCreate.Date)
                .ToList();
        }

        /// <summary>
        /// Ингредиенты на складах
        /// </summary>
        /// <returns></returns>
        public List<ReportStoreHouseIngredientViewModel> GetIngredientStoreHouse()
        {
            var storeHouses = storeHouseLogic.Read(null);
            var storeHouseIngredients = new List<StoreHouseViewModel>();
            var reportStoreHouseIngredient = new List<ReportStoreHouseIngredientViewModel>();
            // считываем ингредиенты с каждого склада
            foreach (var storeHouse in storeHouses)
                storeHouseIngredients.Add(storeHouseLogic.ReadStoreHouse(storeHouse.Id));
            foreach (var storeHouse in storeHouseIngredients)
                foreach (var ingredient in storeHouse.StoreHouseIngredients)
                    reportStoreHouseIngredient.Add(new ReportStoreHouseIngredientViewModel
                    {
                        StoreHouseName = storeHouse.StoreHouseName,
                        IngredientName = ingredient.Value.Item1,
                        Count = ingredient.Value.Item2
                    });
            var groupList = reportStoreHouseIngredient.GroupBy(x => x.IngredientName).ToList();
            var result = new List<ReportStoreHouseIngredientViewModel>();
            foreach (var group in groupList)
            {
                result.Add(new ReportStoreHouseIngredientViewModel { IngredientName = group.Key });
                foreach (var e in group)
                    result.Add(new ReportStoreHouseIngredientViewModel { StoreHouseName = e.StoreHouseName, Count = e.Count });
                result.Add(new ReportStoreHouseIngredientViewModel { StoreHouseName = "Итого:", Count = group.Sum(x => x.Count) });
            }
            return result;
        }

        /// <summary>
        /// Загруженность склада
        /// </summary>
        /// <returns></returns>
        public List<ReportStoreHouseIngredientViewModel> GetStoreHouseIngrediens()
        {
            var storeHouses = storeHouseLogic.Read(null);
            var reportList = new List<ReportStoreHouseIngredientViewModel>();
            foreach (var storeHouse in storeHouses)
            {
                reportList.Add(new ReportStoreHouseIngredientViewModel
                {
                    StoreHouseName = storeHouse.StoreHouseName
                });
                var ingredients = storeHouseLogic.ReadStoreHouse(storeHouse.Id).StoreHouseIngredients;
                foreach (var ingredient in ingredients)
                    reportList.Add(new ReportStoreHouseIngredientViewModel
                    {
                        IngredientName = ingredient.Value.Item1,
                        Count = ingredient.Value.Item2
                    });
                reportList.Add(new ReportStoreHouseIngredientViewModel
                {
                    IngredientName = "Итого:",
                    Count = ingredients.Values.Sum(x => x.Item2)
                });
            }
            return reportList;
        }

        /// <summary>
        /// Сохранение кондитерских изделий с ценой в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductsToWord(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список кондитерских изделий",
                Products = productLogic.Read(null)
            });
        }

        /// <summary>
        /// Сохранение списка складов
        /// </summary>
        /// <param name="model"></param>
        public void SaveStoreHousesToWord(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                StoreHouses = storeHouseLogic.Read(null)
            });
        }

        /// <summary>
        /// Сохранение информации о заказах
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                Orders = GetOrders(model)
            });
        }

        /// <summary>
        /// Сохранение информации о загруженности складов
        /// </summary>
        /// <param name="model"></param>
        public void SaveStoreHouseIngredientToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Загруженность складов",
                ReportStoreHouseIngredient = GetStoreHouseIngrediens()
            });
        }

        /// <summary>
        /// Сохранение кондитерских изделий c расшифровкой по ингредиентам в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductIngredientToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кондитерских изделий с расшифровкой по ингредиентам",
                ProductIngredients = GetProductIngredient()
            });
        }

        /// <summary>
        /// Сохранение ингредиентов на складах в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveIngredientStoreHouseToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Ингредиенты по складам",
                ReportIngredientStoreHouse = GetIngredientStoreHouse()
            });
        }
    }
}
