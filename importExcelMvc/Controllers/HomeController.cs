using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using importExcelMvc.Models;

namespace importExcelMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sua aplicação é descrita aqui, ou não.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Sua página de contatos.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public string Welcome(string nome, int ID = 1)
        //{
        //    return $"Olá {nome}, numero de vezes é: {ID}";
        //}

        public IActionResult Welcome(string nome, int numVezes = 1)
        {
            ViewData["Mensagem"] = "Olá " + nome;
            ViewData["Vezes"] = numVezes;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
