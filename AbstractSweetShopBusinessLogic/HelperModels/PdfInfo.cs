﻿using AbstractSweetShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSweetShopBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportProductIngredientViewModel> ProductIngredients { get; set; }

        public List<ReportStoreHouseIngredientViewModel> ReportIngredientStoreHouse { get; set; }
    }
}