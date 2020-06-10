using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    public class StoreHouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название склада")]
        public string StoreHouseName { get; set; }

        public Dictionary<int, (string, int)> StoreHouseIngredients { get; set; }
    }
}
