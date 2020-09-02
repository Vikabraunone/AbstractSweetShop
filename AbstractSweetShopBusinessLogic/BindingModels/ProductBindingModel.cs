using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.BindingModels
{
    /// <summary>     
    /// Изделие, изготавливаемое в кондитерской     
    /// </summary> 
    public class ProductBindingModel
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> ProductIngredients { get; set; }
    }
}