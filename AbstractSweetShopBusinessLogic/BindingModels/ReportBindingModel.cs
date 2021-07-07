using System;

namespace AbstractSweetShopBusinessLogic.BindingModels
{
    // класс получения данных для отчетов
    public class ReportBindingModel
    {
        public string FileName { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
