using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Scrape.Models
{
   public class CalenderService
   {
      public Calender calender { get; set; }

      public List<Calender> BuscarHtml()
      {
         List<Calender> _callService = new List<Calender>();
         var cliente = new WebClient();
         string page = cliente.DownloadString("http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/");

         var htmlDoc = new HtmlAgilityPack.HtmlDocument();
         htmlDoc.LoadHtml(page);
         //variaveis temporarias
         string test = string.Empty;
         foreach (HtmlNode item in htmlDoc.GetElementbyId("panel1a").ChildNodes)
         {
            if (item.Attributes.Count > 0)
            {
               test = item.Attributes["tr"].Value;
               calender.Descricao = test;
               _callService.Add(calender);

            }
         }
         return _callService;
      }
      //FIM METODO

      public List<CalenderMes> Scraping(string url, List<CalenderMes> calenderMes)
      {
         //string url = "http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/";
         HtmlWeb cliente = new HtmlWeb();
         var htmlDoc = new HtmlAgilityPack.HtmlDocument();
         htmlDoc = cliente.Load(url);

         var pagina = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='large-12 columns']/ul[@class='accordion']");
         HtmlNode node = null;

         foreach (var aux in pagina.SelectNodes("li[@class='accordion-navigation']"))
         {
            //str = "###" + aux.OuterHtml;
            node = aux;
            calenderMes = imprimeScrape(node, calenderMes);
         }
         return calenderMes;
      }
      //FIM metodo

      public List<CalenderMes> imprimeScrape(HtmlNode node, List<CalenderMes> calenderMes)
      {
         int k = 0;
         string[] strReg = new string[4];
         foreach (var aux in node.Descendants("tbody"))
         {
            string strMes = node.Element("a").InnerHtml;
            foreach (var nodes in aux.Descendants("tr"))
            {
               foreach (var nos in nodes.Descendants("td"))
               {
                  switch (k)
                  {
                     case 0:
                        strReg[k] = nos.InnerText;
                        break;
                     case 1:
                        strReg[k] = nos.InnerText;
                        break;
                     case 2:
                        strReg[k] = nos.InnerText;
                        break;
                     case 3:
                        strReg[k] = nos.InnerText;
                        break;
                  }
                  k++;
               }
               var Obj = new CalenderMes(strMes, strReg[0], strReg[1], strReg[3]);
               Obj.SJson = Obj.ToString();
               calenderMes.Add(Obj);
               k = 0;
            }

         }
         return calenderMes;
      }
   }
}
