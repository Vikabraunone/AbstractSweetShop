using AbstractSweetShopBusinessLogic.Enums;
using AbstractSweetShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AbstractSweetShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string IngredientFileName = "Ingredient.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string ProductFileName = "Product.xml";

        private readonly string ProductIngredientFileName = "ProductIngredient.xml";

        private readonly string StoreHouseFileName = "StoreHouse.xml";

        private readonly string StoreHouseIngredientFileName = "StoreHouseIngredient.xml";

        public List<Ingredient> Ingredients { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; }

        public List<ProductIngredient> ProductIngredients { get; set; }

        public List<StoreHouse> StoreHouses { get; set; }

        public List<StoreHouseIngredient> StoreHouseIngredients { get; set; }

        private FileDataListSingleton()
        {
            Ingredients = LoadIngredients();
            Orders = LoadOrders();
            Products = LoadProducts();
            ProductIngredients = LoadProductIngredients();
            StoreHouses = LoadStoreHouses();
            StoreHouseIngredients = LoadStoreHouseIngredient();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
                instance = new FileDataListSingleton();
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveIngredients();
            SaveOrders();
            SaveProducts();
            SaveProductIngredients();
            SaveStoreHouses();
            SaveStoreHouseIngredients();
        }

        private List<Ingredient> LoadIngredients()
        {
            var list = new List<Ingredient>();
            if (File.Exists(IngredientFileName))
            {
                XDocument xDocument = XDocument.Load(IngredientFileName);
                var xElements = xDocument.Root.Elements("Ingredient").ToList();
                foreach (var elem in xElements)
                    list.Add(new Ingredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IngredientName = elem.Element("IngredientName").Value
                    });
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
            }
            return list;
        }

        private List<Product> LoadProducts()
        {
            var list = new List<Product>();
            if (File.Exists(ProductFileName))
            {
                XDocument xDocument = XDocument.Load(ProductFileName);
                var xElements = xDocument.Root.Elements("Product").ToList();
                foreach (var elem in xElements)
                    list.Add(new Product
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductName = elem.Element("ProductName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
            }
            return list;
        }

        private List<ProductIngredient> LoadProductIngredients()
        {
            var list = new List<ProductIngredient>();
            if (File.Exists(ProductIngredientFileName))
            {
                XDocument xDocument = XDocument.Load(ProductIngredientFileName);
                var xElements = xDocument.Root.Elements("ProductIngredient").ToList();
                foreach (var elem in xElements)
                    list.Add(new ProductIngredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ProductId = Convert.ToInt32(elem.Element("ProductId").Value),
                        IngredientId = Convert.ToInt32(elem.Element("IngredientId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
            }
            return list;
        }

        private List<StoreHouseIngredient> LoadStoreHouseIngredient()
        {
            var list = new List<StoreHouseIngredient>();
            if (File.Exists(StoreHouseIngredientFileName))
            {
                XDocument xDocument = XDocument.Load(StoreHouseIngredientFileName);
                var xElements = xDocument.Root.Elements("StoreHouseIngredient").ToList();
                foreach (var elem in xElements)
                    list.Add(new StoreHouseIngredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StoreHouseId = Convert.ToInt32(elem.Element("StoreHouseId").Value),
                        IngredientId = Convert.ToInt32(elem.Element("IngredientId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
            }
            return list;
        }

        private List<StoreHouse> LoadStoreHouses()
        {
            var list = new List<StoreHouse>();
            if (File.Exists(StoreHouseFileName))
            {
                XDocument xDocument = XDocument.Load(StoreHouseFileName);
                var xElements = xDocument.Root.Elements("StoreHouse").ToList();
                foreach (var elem in xElements)
                    list.Add(new StoreHouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StoreHouseName = elem.Element("StoreHouseName").Value
                    });
            }
            return list;
        }

        private void SaveIngredients()
        {
            if (Ingredients != null)
            {
                var xElement = new XElement("Ingredients");
                foreach (var ingredient in Ingredients)
                {
                    xElement.Add(new XElement("Ingredient",
                    new XAttribute("Id", ingredient.Id),
                    new XElement("IngredientName", ingredient.IngredientName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IngredientFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("ProductId", order.ProductId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveProducts()
        {
            if (Products != null)
            {
                var xElement = new XElement("Products");
                foreach (var product in Products)
                    xElement.Add(new XElement("Product",
                        new XAttribute("Id", product.Id),
                        new XElement("ProductName", product.ProductName),
                        new XElement("Price", product.Price)));
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductFileName);
            }
        }
        private void SaveProductIngredients()
        {
            if (ProductIngredients != null)
            {
                var xElement = new XElement("ProductIngredients");
                foreach (var productIngredient in ProductIngredients)
                    xElement.Add(new XElement("ProductIngredient",
                        new XAttribute("Id", productIngredient.Id),
                        new XElement("ProductId", productIngredient.ProductId),
                        new XElement("IngredientId", productIngredient.IngredientId),
                        new XElement("Count", productIngredient.Count)));
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ProductIngredientFileName);
            }
        }

        private void SaveStoreHouseIngredients()
        {
            if (StoreHouseIngredients != null)
            {
                var xElement = new XElement("StoreHouseIngredients");
                foreach (var storeHouseIngredient in StoreHouseIngredients)
                    xElement.Add(new XElement("StoreHouseIngredient",
                        new XAttribute("Id", storeHouseIngredient.Id),
                        new XElement("StoreHouseId", storeHouseIngredient.StoreHouseId),
                        new XElement("IngredientId", storeHouseIngredient.IngredientId),
                        new XElement("Count", storeHouseIngredient.Count)));
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StoreHouseIngredientFileName);
            }
        }

        private void SaveStoreHouses()
        {
            if (StoreHouses != null)
            {
                var xElement = new XElement("StoreHouses");
                foreach (var storeHouse in StoreHouses)
                    xElement.Add(new XElement("StoreHouse",
                        new XAttribute("Id", storeHouse.Id),
                        new XElement("StoreHouseName", storeHouse.StoreHouseName)));
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StoreHouseFileName);
            }
        }
    }
}