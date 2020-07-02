using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кондитерского изделия")]
        public string ProductName { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductIngredients { get; set; }
    }
}