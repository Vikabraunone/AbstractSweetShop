namespace AbstractSweetShopFileImplement.Models
{
    /// <summary>
    /// Сколько компонентов требуется при изготовлении изделия
    /// </summary>
    public class ProductIngredient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int IngredientId { get; set; }

        public int Count { get; set; }
    }
}
