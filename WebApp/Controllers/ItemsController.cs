using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using System.Net.Http;
using System.Net.Http.Headers;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ItemsController : Controller
    {
       
        // GET: Items
        public async Task<IActionResult> Index(int sku = 0)
        {
            IEnumerable<Items> items = null;
            HttpClient client = new HttpClient();
            //dejo hardcode el token del admin para realizar pruebas mas rapido.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwicm9sSWQiOiJBRE0iLCJleHAiOjE1Nzk1ODc0OTksImlzcyI6InBnczMwLmNvbSIsImF1ZCI6InBnczMwLmNvbSJ9.fnEo2iWDgufAMmifJms1_RMSNr2V_K4FCgWySVhOt0A");
            client.BaseAddress = new Uri("https://localhost:44386/api/Inventory/GetListItems?sku=" + sku);
            var responseTask = client.GetAsync(client.BaseAddress);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Items>>();
                readTask.Wait();

                items = readTask.Result;
            }
            return View(items);
        }

    }
}
