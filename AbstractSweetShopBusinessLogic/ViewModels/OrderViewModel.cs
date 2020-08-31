using AbstractSweetShopBusinessLogic.Attributes;
using AbstractSweetShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int? ClientId { get; set; }

        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        [DataMember]
        public string ClientFIO { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [Column(title: "Кондитерское изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Кондитерское изделие")]
        [DataMember]
        public string ProductName { get; set; }

        public int? ImplementerId { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Количество", gridViewAutoSize: GridViewAutoSize.ColumnHeader)]
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }

        [Column(title: "Сумма", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        [DisplayName("Статус")]
        [DataMember]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        [DataMember]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        [DataMember]
        public DateTime? DateImplement { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ClientFIO", "ProductName",
            "ImplementerFIO",  "Count", "Sum", "Status",  "DateCreate", "DateImplement" };
    }
}