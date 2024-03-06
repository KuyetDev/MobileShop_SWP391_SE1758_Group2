using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MobileShop.Entity.Models;
using MobileShop.Shared.Constants;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using MobileShop.Shared.VNPay;

namespace MobileShop.User.Hosted.Pages
{
    public class VNPayModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpClient _client;
        private string ApiUri = string.Empty;
        private string LoginKey = "_login";

        public VNPayModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUri = $"{UrlConstant.ApiBaseUrl}/api/";
        }
        public async Task<IActionResult> OnGet()
        {
            var service = string.Empty;
            var json = HttpContext.Session.GetString(LoginKey) ?? string.Empty;
           
            Account account = null;

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };



                string url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
                string returnUrl = "https://localhost:7166/VNPay?fstore=paymentconfirm";
                string tmnCode = "JF3JL0X5";
                string hashSecret = "HEGRFWKYJRWZZYNMRQJZJDSSCSDARYTQ";
                PayLib pay = new PayLib();
                double price = 0;
                var products = string.Empty;


                pay.AddRequestData("vnp_Version", "2.1.0");
                pay.AddRequestData("vnp_Command", "pay");
                pay.AddRequestData("vnp_TmnCode", tmnCode);
                pay.AddRequestData("vnp_Amount", "");
                pay.AddRequestData("vnp_BankCode", "");
                pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                pay.AddRequestData("vnp_CurrCode", "VND");
                pay.AddRequestData("vnp_IpAddr", GetIpAddress());
                pay.AddRequestData("vnp_Locale", "vn");
                pay.AddRequestData("vnp_OrderInfo", $"Payment order {products}");
                pay.AddRequestData("vnp_OrderType", "other");
                pay.AddRequestData("vnp_ReturnUrl", returnUrl);
                pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString());

                string paymentUrl = pay.CreateRequestUrl(url, hashSecret);



            if (service.Equals("paymentconfirm"))
            {
                if (Request.Query.Count > 0)
                {
                    string hashSecrets = "HEGRFWKYJRWZZYNMRQJZJDSSCSDARYTQ";
                    var vnpayData = Request.Query;
                    PayLib pay1 = new PayLib();

                    foreach (var kvp in vnpayData)
                    {
                        string key = kvp.Key;
                        string value = kvp.Value;

                        if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                        {
                            pay.AddResponseData(key, value);
                        }
                    }

                    long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef"));
                    long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo"));
                    string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode");
                    string vnp_SecureHash = Request.Query["vnp_SecureHash"];

                    bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret);

                    if (checkSignature)
                    {
                        if (vnp_ResponseCode == "00")
                        {
                            

                            return RedirectToPage("Purchase");

                        }
                        else
                        {
                            return RedirectToPage("Checkout");
                        }
                    }
                    else
                    {
                        return RedirectToPage("Checkout");
                    }
                }

            }
            return Page();

        }

        public string GetIpAddress()
        {
            string ipAddress;
            try
            {
                ipAddress = HttpContext.Request.Headers["X-Forwarded-For"];

                if (string.IsNullOrEmpty(ipAddress) || ipAddress.ToLower() == "unknown")
                {
                    ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                }
            }
            catch (Exception ex)
            {
                ipAddress = "Invalid IP: " + ex.Message;
            }

            return ipAddress;
        }

    }
}
