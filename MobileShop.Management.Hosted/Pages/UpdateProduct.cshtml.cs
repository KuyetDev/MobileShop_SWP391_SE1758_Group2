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
    public class UpdateProductModel : PageModel
    {
        private readonly HttpClient _client;
        private string _apiUri;
        public const string LoginKey = "_login";
        public string Message { get; set; }
        public Product? Product { get; set; }
        public Image? Image { get; set; }
        public List<Category>? Categories { get; set; }
        private IWebHostEnvironment _environment;

        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public UpdateProductModel(IWebHostEnvironment environment, IValidateService validateService,
            ILogger<IndexModel> logger, string message, List<Category> categories, IFormFile[] fileUploads)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _apiUri = $"{UrlConstant.ApiBaseUrl}/api/";
            _environment = environment;
            Message = message;
            Categories = categories;
            FileUploads = fileUploads;
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
                Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);

                var response2 = await _client.GetAsync(_apiUri + $"product/get-product-id/{idp}");
                var strData2 = await response2.Content.ReadAsStringAsync();
                Product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData2, option);

                if (Product != null)
                {
                    var response3 = await _client.GetAsync(_apiUri + $"image/get-image-id/{Product.ImageId}");
                    var strData3 = await response3.Content.ReadAsStringAsync();
                    Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData3, option);
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
            Product = System.Text.Json.JsonSerializer.Deserialize<Product>(strData2, option);

            var response = await _client.GetAsync(_apiUri + $"category/get-all-category");
            var strData = await response.Content.ReadAsStringAsync();
            Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(strData, option);

            var accountJson = HttpContext.Session.GetString(LoginKey) ?? string.Empty;
            var account = JsonConvert.DeserializeObject<Account>(accountJson);

            var fileName = string.Empty;

            {
                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".gif" };
                foreach (var fileUpload in FileUploads)
                {
                    var extension = Path.GetExtension(fileUpload.FileName);
                    if (allowedExtensions.Contains(extension.ToLower()))
                    {
                        var basePath = _environment.ContentRootPath[
                            .._environment.ContentRootPath.IndexOf("MobileShop.Management.Hosted",
                                StringComparison.Ordinal)];
                        var fileAdmin = basePath + @"MobileShop.Management.Hosted\wwwroot\image\" +
                                        fileUpload.FileName;
                        var fileUser = basePath + @"MobileShop.User.Hosted\wwwroot\image\" + fileUpload.FileName;
                        fileName = fileUpload.FileName;
                        await using (var fileStream = new FileStream(fileAdmin, FileMode.Create))
                        {
                            await fileUpload.CopyToAsync(fileStream);
                        }

                        await using (var fileStream = new FileStream(fileUser, FileMode.Create))
                        {
                            await fileUpload.CopyToAsync(fileStream);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
                            $"Only the following file types are allowed: {string.Join(", ", allowedExtensions)}");
                    }
                }
            }


            if (Request.Form["pname"].Equals(string.Empty)
                || Request.Form["department"].Equals(string.Empty)
                || Request.Form["quantity"].Equals(string.Empty)
                || Request.Form["price"].Equals(string.Empty)
                || Request.Form["description"].Equals(string.Empty))
            {
                Message = "Update failded, check all infomation";
                return Page();
            }

            if (!fileName.Equals(string.Empty))
            {
                try
                {
                    var response4 = await _client.GetAsync(_apiUri + $"image/get-image-link/{fileName}");
                    var strData4 = await response4.Content.ReadAsStringAsync();
                    Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData4, option);
                }
                catch (Exception)
                {
                    var requestImage = new Image
                    {
                        ImageLink = fileName,
                        CreateDate = DateTime.Now,
                        IsDeleted = false
                    };

                    var json = System.Text.Json.JsonSerializer.Serialize(requestImage);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    await _client.PostAsync(_apiUri + "image/add-image", content);

                    var response5 = await _client.GetAsync(_apiUri + $"image/get-image-link/{fileName}");
                    var strData5 = await response5.Content.ReadAsStringAsync();
                    Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData5, option);
                }
            }
            else
            {
                if (Product != null)
                {
                    var response5 = await _client.GetAsync(_apiUri + $"image/get-image-id/{Product.ImageId}");
                    var strData5 = await response5.Content.ReadAsStringAsync();
                    Image = System.Text.Json.JsonSerializer.Deserialize<Image>(strData5, option);
                }
            }

            if (account == null) return RedirectToPage("ProductManager");
            if (Product == null) return RedirectToPage("ProductManager");
            if (Image == null) return RedirectToPage("ProductManager");
            var requestProduct = new Product
            {
                ProductId = Product.ProductId,
                ProductName = Request.Form["pname"].ToString(),
                Price = Convert.ToDouble(Request.Form["price"]),
                Quantity = Convert.ToInt32(Request.Form["quantity"]),
                Description = Request.Form["description"],
                CategoryId = Convert.ToInt32(Request.Form["department"]),
                ImageId = Image.ImageId,
                CreateDate = DateTime.Now,
                CreateBy = account.AccountId,
                IsDeleted = false
            };

            var productJson = System.Text.Json.JsonSerializer.Serialize(requestProduct);
            var content2 = new StringContent(productJson, Encoding.UTF8, "application/json");
            await _client.PutAsync(_apiUri + "product/put-product", content2);

            return RedirectToPage("ProductManager");
        }
    }
}