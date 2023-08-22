using GeekShopping.CartAPI.Data.Converter.Contract;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Data.Converter.Implementation
{
    public class CartConverter : IParser<CartVO, Cart>, IParser<Cart, CartVO>
    {
        public CartVO Parse(Cart origin)
        {
            throw new NotImplementedException();

        }

        public Cart Parse(CartVO origin)
        {
            throw new NotImplementedException();
        }

        public List<CartVO> Parse(List<Cart> origin)
        {
            throw new NotImplementedException();
        }

        public List<Cart> Parse(List<CartVO> origin)
        {
            throw new NotImplementedException();
        }
    }
}
