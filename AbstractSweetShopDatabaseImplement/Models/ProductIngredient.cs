using System.ComponentModel.DataAnnotations;

namespace AbstractSweetShopDatabaseImplement.Models
{
    public class ProductIngredient
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int IngredientId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Product Product { get; set; }
    }
}
