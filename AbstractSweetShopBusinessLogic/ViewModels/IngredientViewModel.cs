using AbstractSweetShopBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>     
    /// Ингредиент, требуемый для изготовления кондитерского изделия 
    /// </summary> 
    public class IngredientViewModel : BaseViewModel
    {

        [Column(title: "Название инредиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string IngredientName { get; set; }

        public override List<string> Properties() => new List<string> { "Id", "IngredientName" };
    }
}
