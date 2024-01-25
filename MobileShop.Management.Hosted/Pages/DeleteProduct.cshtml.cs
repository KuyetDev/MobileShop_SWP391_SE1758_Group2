using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.Models;
using MobileShop.Service;
using MobileShop.Shared.Constants;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MobileShop.Management.Hosted.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string LoginKey = "_login";
        public string message { get; set; }
        public Product product { get; set; }
        public Image image { get; set; }
        public List<Category> Categories { get; set; }

        public DeleteProductModel(IWebHostEnvironment environment, IValidateService validateService)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUri = $"{UrlConstant.ApiBaseUrl}/api/";

        }
        public async Task<IActionResult> OnGet()
        {

            var json = HttpContext.Session.GetString(LoginKey) ?? string.Empty;

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (string.IsNullOrEmpty(json))
            {
                return RedirectToPage("Login");
            }

            try
            {

                int idp = Convert.ToInt32(Request.Query["idp"].ToString());

                var response = await _client.GetAsync(ApiUri + $"category/get-all-category");
                var strData = await response.Content.ReadAsStringAsync();
                Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);

                var response2 = await _client.GetAsync(ApiUri + $"product/get-product-id/{idp}");
                var strData2 = await response2.Content.ReadAsStringAsync();
                product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData2, option);

                var response3 = await _client.GetAsync(ApiUri + $"image/get-image-id/{product.ImageId}");
                var strData3 = await response3.Content.ReadAsStringAsync();
                image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData3, option);
            }
            catch (Exception e)
            {
                return RedirectToPage("ProductManager");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var idp = Convert.ToInt32(Request.Form["pid"]);

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var response2 = await _client.GetAsync(ApiUri + $"product/get-product-id/{idp}");
            var strData2 = await response2.Content.ReadAsStringAsync();
            product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData2, option);

            product.IsDeleted = true;

            var productJson = System.Text.Json.JsonSerializer.Serialize(product);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");
            await _client.PutAsync(ApiUri + "product/put-product", content);

            return RedirectToPage("ProductManager");
        }
    }
}