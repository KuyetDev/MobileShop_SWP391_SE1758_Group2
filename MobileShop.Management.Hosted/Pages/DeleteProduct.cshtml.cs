using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.Models;
using MobileShop.Service;
using MobileShop.Shared.Constants;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MobileShop.Management.Hosted.Pages
{
    public class DeleteProductModel : PageModel
    {
        private readonly HttpClient _client;
        private string _apiUri;
        private const string LoginKey = "_login";
        public string Message { get; set; }
        public Product? Product { get; set; }
        public Image? Image { get; set; }
        public List<Category>? Categories { get; set; }

        public DeleteProductModel(IWebHostEnvironment environment, IValidateService validateService, string message,
            Image image, List<Category> categories)
        {
            Message = message;
            Image = image;
            Categories = categories;
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _apiUri = $"{UrlConstant.ApiBaseUrl}/api/";
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
                var idp = Convert.ToInt32(Request.Query["idp"].ToString());

                var response = await _client.GetAsync(_apiUri + $"category/get-all-category");
                var strData = await response.Content.ReadAsStringAsync();
                Categories = JsonSerializer.Deserialize<List<Category>>(strData, option);

                var response2 = await _client.GetAsync(_apiUri + $"product/get-product-id/{idp}");
                var strData2 = await response2.Content.ReadAsStringAsync();
                Product = JsonSerializer.Deserialize<Product>(strData2, option);

                if (Product != null)
                {
                    var response3 = await _client.GetAsync(_apiUri + $"image/get-image-id/{Product.ImageId}");
                    var strData3 = await response3.Content.ReadAsStringAsync();
                    Image = JsonSerializer.Deserialize<Image>(strData3, option);
                }
            }
            catch (Exception)
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

            var response2 = await _client.GetAsync(_apiUri + $"product/get-product-id/{idp}");
            var strData2 = await response2.Content.ReadAsStringAsync();
            Product = JsonSerializer.Deserialize<Product>(strData2, option);

            if (Product == null) return RedirectToPage("ProductManager");
            Product.IsDeleted = true;

            var productJson = JsonSerializer.Serialize(Product);
            var content = new StringContent(productJson, Encoding.UTF8, "application/json");
            await _client.PutAsync(_apiUri + "product/put-product", content);

            return RedirectToPage("ProductManager");
        }
    }
}