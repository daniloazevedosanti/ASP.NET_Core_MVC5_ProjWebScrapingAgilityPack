using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrape.Models;

namespace Scrape.Controllers
{
   public class HomeController : Controller
   {

      private readonly CalenderService _service = new CalenderService();
      // private readonly Address address = new Address();

      //[HttpPost] or GET 'default': services
      public IActionResult Index()
      {

         return View();
      }

      public IActionResult EntrarDados()
      {
         return View();
      }

      //'View' EntrarDados(url)
      [HttpPost]
      public IActionResult EntrarDados(Address address)
      {
         if (ModelState.IsValid && address.Url != null)
         {
            return RedirectToAction(nameof(Consulta));
         }
         return View();
      }

      //Listagem indireta sem entrada de dados : URL
      public IActionResult Listar()
      {
         string url = "http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/";
         List<CalenderMes> list = new List<CalenderMes>();
         list = _service.Scraping(url, list);
         return View(list);
      }

      //Listagem direta com entrada de dados via a 'View' EntrarDados(url) : URL
      public IActionResult Consulta(Address address)
      {
         List<CalenderMes> list = new List<CalenderMes>();
         list = _service.Scraping(address.Url, list);
         return View(list);
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
