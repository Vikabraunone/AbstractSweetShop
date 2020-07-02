using System.ComponentModel.DataAnnotations;

namespace AbstractSweetShopDatabaseImplement.Models
{
    public class StoreHouseIngredient
    {
        public int Id { get; set; }

        public int StoreHouseId { get; set; }

        public int IngredientId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual StoreHouse StoreHouse { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
