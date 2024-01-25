using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.Models;
using MobileShop.Service;
using MobileShop.Shared.Constants;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;

namespace MobileShop.Management.Hosted.Pages
{
    public class UpdateProductModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string LoginKey = "_login";
        public string message { get; set; }
        public Product product { get; set; }
        public Image image { get; set; }
        public List<Category> Categories { get; set; }
        private IValidateService _validateService;
        private IWebHostEnvironment _environment;
        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public UpdateProductModel(IWebHostEnvironment environment, IValidateService validateService)
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

            var response = await _client.GetAsync(ApiUri + $"category/get-all-category");
            var strData = await response.Content.ReadAsStringAsync();
            Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);

            var accountJson = HttpContext.Session.GetString(LoginKey) ?? string.Empty;
            var account = JsonConvert.DeserializeObject<Account>(accountJson);

            var fileName = string.Empty;

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
                        fileName = FileUpload.FileName;
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
                message = "Update failded, check all infomation";
                return Page();
            }

            Entity.Models.Image newImage = null;
            if (!fileName.Equals(string.Empty))
            {

                try
                {

                    var response4 = await _client.GetAsync(ApiUri + $"image/get-image-link/{fileName}");
                    var strData4 = await response4.Content.ReadAsStringAsync();
                    image = System.Text.Json.JsonSerializer.Deserialize<Entity.Models.Image>(strData4, option);
                }
                catch (Exception ex)
                {
                    var requestImage = new Entity.Models.Image
                    {
                        ImageLink = fileName,
                        CreateDate = DateTime.Now,
                        IsDeleted = false
                    };

                    var json = System.Text.Json.JsonSerializer.Serialize(requestImage);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    await _client.PostAsync(ApiUri + "image/add-image", content);

                    var response5 = await _client.GetAsync(ApiUri + $"image/get-image-link/{fileName}");
                    var strData5 = await response5.Content.ReadAsStringAsync();
                    image = System.Text.Json.JsonSerializer.Deserialize<Entity.Models.Image>(strData5, option);
                }
            }
            else
            {
                var response5 = await _client.GetAsync(ApiUri + $"image/get-image-id/{product.ImageId}");
                var strData5 = await response5.Content.ReadAsStringAsync();
                image = System.Text.Json.JsonSerializer.Deserialize<Entity.Models.Image>(strData5, option);
            }

            var requestProduct = new Product
            {
                ProductId = product.ProductId,
                ProductName = Request.Form["pname"],
                Price = Convert.ToDouble(Request.Form["price"]),
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Description = Request.Form["description"],
                CategoryId = Convert.ToInt32(Request.Form["department"]),
                ImageId = image.ImageId,
                CreateDate = DateTime.Now,
                CreateBy = account.AccountId,
                IsDeleted = false
            };

            var productJson = System.Text.Json.JsonSerializer.Serialize(requestProduct);
            var content2 = new StringContent(productJson, Encoding.UTF8, "application/json");
            await _client.PutAsync(ApiUri + "product/put-product", content2);
            return RedirectToPage("ProductManager");
        }
    }
}