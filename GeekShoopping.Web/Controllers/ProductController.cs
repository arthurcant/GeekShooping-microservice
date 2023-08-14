using GeekShoopping.Web.Models;
using GeekShoopping.Web.Services.IServices;
using GeekShoopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productServices.FindAllProducts();
            return View(products);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productServices.CreateProduct(model);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var model = await _productServices.FindProductById(id);

            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productServices.UpdateProduct(model);

                if (response != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }

            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _productServices.FindProductById(id);

            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
          
            var response = await _productServices.DeleleProductById(model.Id);

            if (response)
            {
                return RedirectToAction(nameof(ProductIndex));
            }

            return View(model);
        }


    }
}
