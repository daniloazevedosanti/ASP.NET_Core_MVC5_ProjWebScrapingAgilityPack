using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
         //if (ModelState.IsValid)
         //{
            string Url = "http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/";
            //ViewBag.Msg2 = _service.bList1(Url);
            //return RedirectToAction("Listar");
         //}
         //var calenderService = _service.BuscarHtml();
         return View();
      }

      public IActionResult EntrarDados()
      {
         return View();
      }

      [HttpPost]
      public IActionResult EntrarDados(string url)
      {
         if (ModelState.IsValid && url != null)
         {
            return RedirectToAction(nameof(Listar));
         }
         return View();
      }

      public IActionResult Listar()
      {
         string url = "http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/";
         List<CalenderMes> list = new List<CalenderMes>();
         list = _service.Scraping(url, list);
         //Calender Obj = new Calender();
         //Obj.Totals = Obj.ToString();
         //list.Add(Obj);
         return View(list);
      }


      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
