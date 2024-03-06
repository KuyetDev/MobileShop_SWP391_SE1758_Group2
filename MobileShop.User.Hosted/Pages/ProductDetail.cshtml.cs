using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.Models;
using MobileShop.Shared.Constants;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MobileShop.User.Hosted.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string ProductIdKey = "_productid";
        private string LoginKey = "_login";
        public string message { get; set; }
        public Product Product { get; set; }
        public Image Image { get; set; }

        public ProductDetailModel()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUri = $"{UrlConstant.ApiBaseUrl}/api/";
        }

        public async Task<IActionResult> OnGet()
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            try
            {
                var productid = Convert.ToInt32(Request.Query["idp"].ToString());
                HttpContext.Session.SetString(ProductIdKey, productid.ToString());

                var response = await _client.GetAsync(ApiUri + $"product/get-product-id/{productid}");
                var strData = await response.Content.ReadAsStringAsync();
                Product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData, option);

                var response2 = await _client.GetAsync(ApiUri + $"image/get-image-id/{Product.ImageId}");
                var strData2 = await response2.Content.ReadAsStringAsync();
                Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData2, option);
            }
            catch (Exception ex)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var json = HttpContext.Session.GetString(LoginKey) ?? string.Empty;
            var productId = Convert.ToInt32(HttpContext.Session.GetString(ProductIdKey));
            var quantity = Convert.ToInt32(Request.Form["quantity"]);

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var response = await _client.GetAsync(ApiUri + $"product/get-product-id/{productId}");
            var strData = await response.Content.ReadAsStringAsync();
            Product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData, option);

            var response2 = await _client.GetAsync(ApiUri + $"image/get-image-id/{Product.ImageId}");
            var strData2 = await response2.Content.ReadAsStringAsync();
            Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData2, option);

            if (quantity > Product.Quantity)
            {
                message = "Quantity very big!";
                return Page();
            }

            if (!string.IsNullOrEmpty(json))
            {
                var account = JsonConvert.DeserializeObject<Account>(json);
                await _client.GetAsync(ApiUri + $"shopping/addtocart/{account.AccountId}&{productId}&{quantity}");
                message = "Add to cart complete!";
            }
            else
            {

            }
            return Page();
        }
    }
}
