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

        public ReportLogic(IProductLogic productLogic, IOrderLogic orderLogic)
        {
            this.productLogic = productLogic;
            this.orderLogic = orderLogic;
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
        /// Сохранение кондитерских изделий c расшифровкой по ингредиентам в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductComponentToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список кондитерских изделий с расшифровкой по ингредиентам",
                ProductIngredient = GetProductIngredient()
            });
        }
    }
}