using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Entity.DTOs.CategoryDTO;
using MobileShop.Entity.DTOs.ProductDTO;
using MobileShop.Entity.Models;
using MobileShop.Service;

namespace MobileShop.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] CreateProductRequest product)
        {
            var result = _productService.AddProduct(product);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }

        [HttpGet("get-all-product")]
        public IActionResult GetAllProduct()
        {

            var products = _productService.GetAllProduct();
            if (products != null && products.Count == 0)
            {
                return Ok("Don't have product");
            }
            return Ok(products);
        }

        [HttpGet("get-product-id/{id}")]
        public IActionResult GetAccountById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }

        [HttpGet("get-product-category/{id}")] 
        public IActionResult GetProductsByCategoryId(int id)
        {
            var product = _productService.GetProductsByCategoryId(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }

        [HttpGet("get-product-keyword&category/{keyword}&{cid}")]
        public IActionResult GetProductsByKeywordAndCategoryId(string keyword, int cid)
        {
            var product = _productService.GetProductsByKeywordAndCategoryId(keyword, cid);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }

        [HttpGet("get-product-keyword/{keyword}")]
        public IActionResult GetProductsByKeyword(string keyword)
        {
            var product = _productService.GetProductsByKeyword(keyword);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }



        [HttpPut("put-product")]
        public IActionResult UpdateProduct(UpdateProductRequest product)
        {
            var result = _productService.UpdateProduct(product);
            if (result == null)
            {
                return StatusCode(500);
            }
            return Ok(result);
        }


        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.UpdateDeleteStatusProduct(id);
            if (result == false)
            {
                return StatusCode(500);
            }
            return Ok("Delete product complete");
        }

    }
}
