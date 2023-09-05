using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data.ValueObjects;
using Shopping.API.Repository;

namespace Shopping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #region Find
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }
        #endregion

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO productVO)
        {
            if(productVO == null) return BadRequest();    
            var product = await _productRepository.Create(productVO);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var product = await _productRepository.Update(productVO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
