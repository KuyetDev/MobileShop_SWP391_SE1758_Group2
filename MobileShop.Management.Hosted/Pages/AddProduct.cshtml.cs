using Microsoft.AspNetCore.Http.HttpResults;
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
using static System.Net.Mime.MediaTypeNames;

namespace MobileShop.Management.Hosted.Pages
{
    public class AddProductModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string LoginKey = "_login";
        public string message { get; set; }
        public List<Product>? Products { get; set; }
        public List<Category> Categories { get; set; }
        private IValidateService _validateService;
        private IWebHostEnvironment _environment;
        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public AddProductModel(IWebHostEnvironment environment, IValidateService validateService)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUri = $"{UrlConstant.ApiBaseUrl}/api/";
            _environment = environment;
            _validateService = validateService;
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

            var response = await _client.GetAsync(ApiUri + $"category/get-all-category");
            var strData = await response.Content.ReadAsStringAsync();
            Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var response = await _client.GetAsync(ApiUri + $"category/get-all-category");
            var strData = await response.Content.ReadAsStringAsync();
            Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);

            var filename = string.Empty;
            if (FileUploads != null)
            {
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                foreach (var FileUpload in FileUploads)
                {
                    var extension = Path.GetExtension(FileUpload.FileName);
                    if (allowedExtensions.Contains(extension.ToLower()))
                    {
                        var basepath = _environment.ContentRootPath.Substring(0, _environment.ContentRootPath.IndexOf("MobileShop.Management.Hosted"));
                        var fileadmin = basepath + "MobileShop.Management.Hosted\\wwwroot\\image\\" + FileUpload.FileName;
                        var fileuser = basepath + "MobileShop.User.Hosted\\wwwroot\\image\\" + FileUpload.FileName;
                        filename = FileUpload.FileName;
                        using (var fileSream = new FileStream(fileadmin, FileMode.Create))
                        {
                            await FileUpload.CopyToAsync(fileSream);
                        }
                        using (var fileSream = new FileStream(fileuser, FileMode.Create))
                        {
                            await FileUpload.CopyToAsync(fileSream);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Only the following file types are allowed: {string.Join(", ", allowedExtensions)}");
                    }
                }
            }

            if (Request.Form["pname"].Equals(string.Empty)
                || Request.Form["department"].Equals(string.Empty)
                || Request.Form["quantity"].Equals(string.Empty)
                || Request.Form["price"].Equals(string.Empty)
                || Request.Form["description"].Equals(string.Empty))
            {
                message = "Add failded, check all infomation";
                return Page();
            }

            Entity.Models.Image newImage = null;
            try
            {

                var response3 = await _client.GetAsync(ApiUri + $"image/get-image-link/{filename}");
                var strData3 = await response3.Content.ReadAsStringAsync();
                newImage = System.Text.Json.JsonSerializer.Deserialize<Entity.Models.Image>(strData3, option);
            }
            catch (Exception ex)
            {
                var requestImage = new Entity.Models.Image
                {
                    ImageLink = filename,
                    CreateDate = DateTime.Now,
                    IsDeleted = false
                };

                var json = System.Text.Json.JsonSerializer.Serialize(requestImage);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await _client.PostAsync(ApiUri + "image/add-image", content);

                var response2 = await _client.GetAsync(ApiUri + $"image/get-image-link/{filename}");
                var strData2 = await response2.Content.ReadAsStringAsync();
                newImage = System.Text.Json.JsonSerializer.Deserialize<Entity.Models.Image>(strData2, option);
            }

            var accountJson = HttpContext.Session.GetString(LoginKey) ?? string.Empty;
            var account = JsonConvert.DeserializeObject<Account>(accountJson);

            var requestProduct = new Product
            {
                ProductName = Request.Form["pname"],
                Price = Convert.ToDouble(Request.Form["price"]),
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Description = Request.Form["description"],
                CategoryId = Convert.ToInt32(Request.Form["department"]),
                ImageId = newImage.ImageId,
                CreateDate = DateTime.Now,
                CreateBy = account.AccountId,
                IsDeleted = false
            };

            var productJson = System.Text.Json.JsonSerializer.Serialize(requestProduct);
            var content2 = new StringContent(productJson, Encoding.UTF8, "application/json");
            await _client.PostAsync(ApiUri + "product/add-product", content2);
            return RedirectToPage("ProductManager");
        }
    }
}
