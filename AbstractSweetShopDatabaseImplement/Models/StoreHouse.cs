using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractSweetShopDatabaseImplement.Models
{
    public class StoreHouse
    {
        public int Id { get; set; }

        [Required]
        public string StoreHouseName { get; set; }

        [ForeignKey("StoreHouseId")]
        public virtual List<StoreHouseIngredient> StoreHouseIngredients { get; set; }
    }
}
