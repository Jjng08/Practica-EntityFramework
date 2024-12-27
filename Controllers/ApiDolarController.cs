using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ClaseNosePeroClase.Controllers
{
    public class ApiDolarController : Controller
    {

        public async Task<IActionResult> ObtenerDolar()
        {
            string apiurl = $"https://mindicador.cl/api/dolar";
            using (HttpClient client = new HttpClient()) 
            {
                JObject datosdolar = JObject.Parse(await client.GetStringAsync(apiurl));
                
                    var serie = datosdolar["serie"]![0];
                    
                        ViewBag.fecha = serie["fecha"]?.ToString();
                        ViewBag.dolar = serie["valor"]?.ToString();
                    
                
            }
            return View();
        }
    }
}
