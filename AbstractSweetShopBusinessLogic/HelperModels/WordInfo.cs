using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public List<StoreHouseViewModel> StoreHouses { get; set; }
    }
}
