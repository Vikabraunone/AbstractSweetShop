using AbstractSweetShopBusinessLogic.Enums;
using System;

namespace AbstractSweetShopBusinessLogic.BindingModels
{
    /// <summary>     
    /// Заказ     
    /// </summary>    
    public class OrderBindingModel
    {
        public int? Id { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
        public string ProductName { get; set; }
    }
}
