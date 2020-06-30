namespace AbstractSweetShopBusinessLogic.BindingModels
{
    public class StoreHouseIngredientBindingModel
    {
        public int Id { get; set; }

        public int StoreHouseId { get; set; }

        public int IngredientId { get; set; }

        public int Count { get; set; }
    }
}