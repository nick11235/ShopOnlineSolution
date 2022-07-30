
using ShopOnline.Api.Data;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories=await this.shopOnlineDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopOnlineDbContext.Products.ToListAsync();
            return products;
        }

        public Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
