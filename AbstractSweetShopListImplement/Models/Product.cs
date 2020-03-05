namespace AbstractSweetShopListImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в кондитерской
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
