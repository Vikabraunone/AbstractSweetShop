using AbstractSweetShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractSweetShopDatabaseImplement
{
    public class AbstractSweetShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2ACH9S6\SQLEXPRESS;Initial Catalog=AbstractSweetShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Ingredient> Ingredients { set; get; }

        public virtual DbSet<Product> Products { set; get; }

        public virtual DbSet<ProductIngredient> ProductIngredients { set; get; }

        public virtual DbSet<Order> Orders { set; get; }
    }
}