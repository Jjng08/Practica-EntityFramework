using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

        public async Task<IActionResult> Sismo() 
        {
            string apiurl = $"https://api.xor.cl/sismo/recent";

            using (HttpClient newclient = new HttpClient())
            {
                JObject datossismo = JObject.Parse(await newclient.GetStringAsync(apiurl));

                var events = datossismo["events"]!;

                List<string> fechas = new List<string>();
                List<string> ubicaciones = new List<string>();
                List<string> magnitudes = new List<string>();

                foreach (var evento in events)
                {
                    fechas.Add(evento["local_date"]?.ToString());
                    ubicaciones.Add(evento["geo_reference"]?.ToString());
                    magnitudes.Add(evento["magnitude"]!["value"]?.ToString());
                }

                ViewBag.fechas = fechas;
                ViewBag.ubicaciones = ubicaciones;
                ViewBag.magnitudes = magnitudes;
            }
            return View();
        }
    }
}
