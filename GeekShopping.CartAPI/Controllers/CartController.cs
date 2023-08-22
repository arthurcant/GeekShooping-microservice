using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

       

        [HttpGet("find-cart/{userId}")]
        public async Task<IActionResult> FindById(string userId)
        {
            var cart = await _repository.FindCartByUserId(userId);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<IActionResult> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<IActionResult> UpdateCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);

            if (!status)
            {
                return BadRequest();
            }

            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCoupon(CartVO vo)
        {
            var status = await _repository.ApplyCoupon(vo.CartHeader.UserId, vo.CartHeader.CouponCode);
            if (!status)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<IActionResult> ApplyCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart == null) return NotFound();
            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            //TASK RabbitMQ logic comes here!!!

            return Ok(vo);
        }

    }
}