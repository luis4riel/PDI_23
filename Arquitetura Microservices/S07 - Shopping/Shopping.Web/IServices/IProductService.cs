using Shopping.Web.Models;

namespace Shopping.Web.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductModel>> FindAllProducts();
        public Task<ProductModel> FindProductById(int id);
        public Task<ProductModel> CreateProduct(ProductModel model);
        public Task<ProductModel> UpdateProduct(ProductModel model);
        public Task<bool> DeleteProductById(int id);
    }
}
