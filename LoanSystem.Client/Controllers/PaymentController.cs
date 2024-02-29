using LoanSystem.Client.Models.Payments;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LoanSystem.Client.Controllers
{
    public class PaymentController : Controller
    {
        private const string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjOTg5NWNlYS00ODNlLTQ4M2MtNzYyMy0wOGRiYjI5ZTJkNWYiLCJ1bmlxdWVfbmFtZSI6ImM5ODk1Y2VhLTQ4M2UtNDgzYy03NjIzLTA4ZGJiMjllMmQ1ZiIsImp0aSI6ImI0ZGFiMDY1LTg2ZmQtNGJjZS1hNzM0LWMzOTFkMzUwZjUwMCIsImlhdCI6IjE3MDkyMTE2NzM2NjQiLCJuYmYiOjE3MDkyMTE2NzMsImV4cCI6MTcwOTIxMTcxOCwiaXNzIjoiTG9hblN5c3RlbSIsImF1ZCI6IkxvYW5TeXN0ZW0ifQ.SCbvH_P7rcHVbNzgsYkF62adFDpnQ3kL56qJzKJ3rjQ";

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            List<PaymentViewModel> paymentList = new();

            using(var client = new HttpClient())
            {
                var endpoint = new Uri("https://localhost:7035/api/v1/payments?Page=1&PageSize=2");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.GetAsync(endpoint);

                if(result.IsSuccessStatusCode)
                {
                    var json = result.Content.ReadAsStringAsync().Result;

                    paymentList = JsonConvert.DeserializeObject<List<PaymentViewModel>>(json)!;
                }
            }



            return this.View(paymentList);
        }
    }
}
