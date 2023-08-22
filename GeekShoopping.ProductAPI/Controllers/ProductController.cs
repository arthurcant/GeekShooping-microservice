using GeekShoopping.ProductAPI.Data.ValueObjects;
using GeekShoopping.ProductAPI.Model;
using GeekShoopping.ProductAPI.Repository;
using GeekShoopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository) {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var product = await _repository.FindAll();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if (product.Id <= 0)
            {
                return NotFound();
            }
             
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }
            
            var product = await _repository.Create(productVO);


            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] ProductVO productVO)
        {
            if (productVO == null)
            {
                return BadRequest();
            }

            var product = await _repository.Update(productVO);


            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete (long id)
        {
            var status = await _repository.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
        }

    }
}
