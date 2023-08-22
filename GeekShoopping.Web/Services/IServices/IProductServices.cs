using GeekShoopping.Web.Models;

namespace GeekShoopping.Web.Services.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductViewModel>> FindAllProducts(string token);
        Task<ProductViewModel> FindProductById(long id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel model, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token);
        Task<bool> DeleleProductById(long id, string token);
    }
}
