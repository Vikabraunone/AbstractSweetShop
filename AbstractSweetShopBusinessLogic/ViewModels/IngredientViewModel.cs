using System.ComponentModel;

namespace AbstractSweetShopBusinessLogic.ViewModels
{
    /// <summary>     
    /// Ингредиент, требуемый для изготовления кондитерского изделия 
    /// </summary> 
    public class IngredientViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название ингредиента")] 
        public string IngredientName { get; set; }
    }
}
