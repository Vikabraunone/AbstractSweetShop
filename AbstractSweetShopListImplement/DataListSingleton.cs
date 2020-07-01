using AbstractSweetShopListImplement.Models;
using System.Collections.Generic;

namespace AbstractSweetShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Ingredient> Ingredients { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; }

        public List<ProductIngredient> ProductIngredients { get; set; }

        public List<StoreHouse> StoreHouses { get; set; }

        public List<StoreHouseIngredient> StoreHouseIngredients { get; set; }

        private DataListSingleton()
        {
            Ingredients = new List<Ingredient>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductIngredients = new List<ProductIngredient>();
            StoreHouses = new List<StoreHouse>();
            StoreHouseIngredients = new List<StoreHouseIngredient>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
                instance = new DataListSingleton();
            return instance;
        }
    }
}