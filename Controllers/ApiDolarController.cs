using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ClaseNosePeroClase.Controllers
{
    public class ApiDolarController : Controller
    {
        public async Task<IActionResult> ObtenerDolar()
        {
            string apiurl = $"https://mindicador.cl/api";
            using (HttpClient client = new HttpClient()) 
            {
                JObject datosdolar = JObject.Parse(await client.GetStringAsync(apiurl));
                if (datosdolar["serie"] != null && datosdolar["serie"]!.Any()) 
                {
                    var serie = datosdolar["serie"]![0];
                    if (serie != null) 
                    {
                        ViewBag.fecha = serie["fecha"]?.ToString();
                        ViewBag.dolar = serie["valor"]?.ToString();
                    }
                }
            }
            return View();
        }
    }
}
