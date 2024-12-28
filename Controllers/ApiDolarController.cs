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

                var events = datossismo["events"];
                if (events == null)
                {
                    return View("Error");
                }

                List<dynamic> sismos = new List<dynamic>();

                foreach (var evento in events)
                {
                    sismos.Add(new
                    {
                        Fecha = evento["local_date"]?.ToString(),
                        Ubicacion = evento["geo_reference"]?.ToString(),
                        Magnitud = evento["magnitude"]?["value"]?.ToString()
                    });
                }

                ViewBag.Sismos = sismos;
            }
            return View();
        }
    }
}
