using AbstractSweetShopBusinessLogic.Enums;
using System;
using System.ComponentModel;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    // вернуть данные для отчета по заказам
    public class ReportOrdersViewModel
    {
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Кондитерское изделие")]
        public string ProductName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }

        [DisplayName("Сумма")]
        public decimal? Sum { get; set; }

        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
    }
}