using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.BindingModels
{
    public class StoreHouseBindingModel
    {
        public int? Id { get; set; }

        public string StoreHouseName { get; set; }

        public Dictionary<int, (string, int)> StoreHouseIngredients { get; set; }
    }
}