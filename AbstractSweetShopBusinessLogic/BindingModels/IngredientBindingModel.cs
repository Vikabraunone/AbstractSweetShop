namespace AbstractSweetShopBusinessLogic.BindingModels
{
    /// <summary>
    ///  Ингредиент, требуемый для изготовления кондитерского изделия 
    /// </summary>
    public class IngredientBindingModel
    {
        public int? Id { get; set; }

        public string IngredientName { get; set; }
    }
}