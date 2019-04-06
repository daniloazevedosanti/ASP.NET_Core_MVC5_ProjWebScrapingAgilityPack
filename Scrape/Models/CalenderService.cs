using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Scrape.Models
{
   public class CalenderService
   {
      //Serviço de solicitação do scraping - carregamento e captura dos elementos HTML 
      public List<Calender> DoScraping(string url, List<Calender> calenderMes)
      {
         //Carregamento e lógica de captura.
         try
         {
            HtmlWeb client = new HtmlWeb();
            var htmlDoc = new HtmlDocument();
            htmlDoc = client.Load(url);

            var pagina = htmlDoc.DocumentNode.Descendants("li")
            .Where(no => no.GetAttributeValue("class", "")
            .Equals("accordion-navigation")).ToList();

            foreach (var aux in pagina)
            {
               calenderMes = PrintScrape(aux.Descendants("tr").ToList(), calenderMes, aux);
            }
            return calenderMes;
         }
         catch (Exception e)
         { 
            throw new Exception(e.Message);
         }
      }
      //FIM METODO

      //Serviço de lógica de preenchimento das listas/Models
      public List<Calender> PrintScrape(List<HtmlNode> node, List<Calender> calenderMes, HtmlNode noMes)
      {
         string strMes = noMes.Element("a").InnerHtml;
         Calender Obj = null ;
         for (int i = 1; i < node.Count; i++)
         {
            var eventList = node[i].Descendants("td").ToList();
            if (eventList.Count == 4)
            {
               HtmlNode[] htmlNodes = eventList.ToArray();
               Obj = new Calender(strMes, htmlNodes);
            }
            Obj.FormatJson = Obj.ToString();
            calenderMes.Add(Obj);
         }
         return calenderMes;
      }
      //FIM METODO
   }
}
