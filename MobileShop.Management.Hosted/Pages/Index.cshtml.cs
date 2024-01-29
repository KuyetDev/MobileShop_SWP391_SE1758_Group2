using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Entity.Models;
using MobileShop.Shared.Constants;
using MobileShop.Entity.DTOs.AccountDTO;
using MobileShop.Entity.Models;
using MobileShop.Shared.Constants;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MobileShop.Management.Hosted.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string LoginKey = "_login";
        public List<Account>? Accounts { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
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

            var account = JsonConvert.DeserializeObject<Account>(json);


            var service = string.Empty;

            if (!Request.Query["fstore"].ToString().Equals(string.Empty))
            {
                service = Request.Query["fstore"].ToString();
            }

            if (service.Equals("disable"))
            {
                var id = Convert.ToInt32(Request.Query["aid"].ToString());

                var response = await _client.GetAsync(ApiUri + $"account/get-account-id/{id}");
                var strData = await response.Content.ReadAsStringAsync();

                var accountPut = System.Text.Json.JsonSerializer.Deserialize<UpdateAccountRequest>(strData, option);
                if (accountPut != null)
                {
                    accountPut.Active = false;

                    var jsonAccount = System.Text.Json.JsonSerializer.Serialize(accountPut);
                    var content = new StringContent(jsonAccount, Encoding.UTF8, "application/json");

                    await _client.PutAsync(ApiUri + $"account/put-account", content);
                }

            }

            if (service.Equals("enable"))
            {
                var id = Convert.ToInt32(Request.Query["aid"].ToString());

                var response = await _client.GetAsync(ApiUri + $"account/get-account-id/{id}");
                var strData = await response.Content.ReadAsStringAsync();

                var accountPut = System.Text.Json.JsonSerializer.Deserialize<UpdateAccountRequest>(strData, option);
                if (accountPut != null)
                {
                    accountPut.Active = true;

                    var jsonAccount = System.Text.Json.JsonSerializer.Serialize(accountPut);
                    var content = new StringContent(jsonAccount, Encoding.UTF8, "application/json");

                    await _client.PutAsync(ApiUri + $"account/put-account", content);
                }

            }

            var response2 = await _client.GetAsync(ApiUri + $"account/get-all-accounts");
            var strData2 = await response2.Content.ReadAsStringAsync();
            Accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(strData2, option);
            return Page();

        }

        public async Task<IActionResult> OnPostFillter()
        {
            var accountname = Request.Form["fname"];
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (accountname.Equals(string.Empty))
            {
                var response = await _client.GetAsync(ApiUri + $"account/get-all-accounts");
                var strData = await response.Content.ReadAsStringAsync();
                Accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(strData, option);
                return Page();
            }

            var response2 = await _client.GetAsync(ApiUri + $"account/get-accounts-keyword/{accountname}");
            var strData2 = await response2.Content.ReadAsStringAsync();
            Accounts = System.Text.Json.JsonSerializer.Deserialize<List<Account>>(strData2, option);

            return Page();
        }
    }
}