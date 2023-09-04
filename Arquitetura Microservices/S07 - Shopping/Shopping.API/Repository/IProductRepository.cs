using Shopping.API.Data.ValueObjects;

namespace Shopping.API.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindByName(string productName);
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);    
    }
}