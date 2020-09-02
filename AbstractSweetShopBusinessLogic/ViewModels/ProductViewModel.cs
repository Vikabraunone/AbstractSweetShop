using AbstractSweetShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    [DataContract]
    public class ProductViewModel : BaseViewModel
    {
        [Column(title: "Название кондитерского изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string ProductName { get; set; }

        [Column(title: "Цена", gridViewAutoSize: GridViewAutoSize.AllCells)]
        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ProductIngredients { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "ProductName", "Price" };
    }
}