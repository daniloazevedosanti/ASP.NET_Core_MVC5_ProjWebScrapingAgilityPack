using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;

namespace Scrape.Models
{
   public class CalenderService
   {
      //Serviço de solicitação do scraping - carregamento e captura dos elementos HTML 
      public List<CalenderMes> Scraping(string url, List<CalenderMes> calenderMes)
      {
         //Tentar carregar e capturar a pagina,
         //Bem como o manejo da lógica de captura.
         try
         {
            HtmlWeb cliente = new HtmlWeb();
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc = cliente.Load(url);

            var pagina = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='large-12 columns']/ul[@class='accordion']");
            HtmlNode node = null;

            foreach (var aux in pagina.SelectNodes("li[@class='accordion-navigation']"))
            {
               node = aux;
               calenderMes = imprimeScrape(node, calenderMes);
            }
            return calenderMes;
         }
         catch (Exception e)
         {
            
            throw new Exception(e.Message);
         }
      }
      //FIM metodo

      //Serviço de lógica de preenchimento das listas/Models
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
                        strReg[k] = WebUtility.HtmlDecode(nos.InnerText);
                        break;
                     case 1:
                        strReg[k] = WebUtility.HtmlDecode(nos.InnerText);
                        break;
                     case 2:
                        strReg[k] = WebUtility.HtmlDecode(nos.InnerText);
                        break;
                     case 3:
                        strReg[k] = WebUtility.HtmlDecode(nos.InnerText);
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
      //FIM metodo
   }
}
