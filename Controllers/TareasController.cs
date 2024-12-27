using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClaseNosePeroClase.Controllers
{
    public class TareasController : Controller
    {
        [HttpPost]
        public IActionResult Tarea(int n1, int n2)
        {
            ViewBag.suma = n1 + n2;
            ViewBag.resta = n1 - n2;
            ViewBag.factorial1 = FactorialCalc(n1);
            ViewBag.ParEimpar = ParEimpart(n1, n2);
            ViewBag.mayor = MayorMenor(n1, n2);
            return View("/Views/Tareas/Tareas.cshtml");
        }

        [HttpGet]
        public IActionResult Tareas()
        {
            return View();
        }

        [HttpPost]

        private int FactorialCalc(int number)
        {
            if (number <= 1) return 1;
            return number * FactorialCalc(number - 1);
        }

        private string ParEimpart(int n1, int n2)
        {
            string resultado = "";
            resultado += $"{n1} es {(n1 % 2 == 0 ? "par" : "impar")}. ";
            resultado += $"{n2} es {(n2 % 2 == 0 ? "par" : "impar")}.";
            return resultado;
        }

        private string MayorMenor(int n1, int n2)
        {
            string resultado = "";
            resultado += $"{n1} es {(n1 > n2 ? "mayor" : "menor")} que {n2}.  ";
            resultado += $"{n2} es {(n2 > n1 ? "mayor" : "menor")} que {n1}.";
            return resultado;
        }
    }
}
