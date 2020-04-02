namespace AbstractSweetShopListImplement.Models
{
    public class StoreHouseIngredient
    {
        public int? Id { get; set; }

        public int StoreHouseId { get; set; }

        public int IngredientId { get; set; }

        public int Count { get; set; }
    }
}
