using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
   class Rascunho
   {

      /*
       
       using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeTesting
{
   class Program
   {
      struct Calender
      {
         public string Dia;
         public string Evento;
         public string simbolo;
         public string Descricao;
      };

      static void Main(string[] args)
      {
         string url = "http://www.b3.com.br/pt_br/solucoes/plataformas/puma-trading-system/para-participantes-e-traders/calendario-de-negociacao/feriados/";
         HtmlWeb cliente = new HtmlWeb();
         var htmlDoc = new HtmlAgilityPack.HtmlDocument();
         htmlDoc = cliente.Load(url);

         var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='large-12 columns']/ul[@class='accordion']");
         HtmlNode temp = null;

         foreach (var aux in node.SelectNodes("li[@class='accordion-navigation']"))
         {
            //str = "###" + aux.OuterHtml;
            temp = aux;
            imprimeScrape(temp);
         }
      }

      public static void imprimeScrape(HtmlNode temp)
      {
         List<Calender> reg = new List<Calender>();
         int k = 0;
         //string strMes = temp.Element("a").InnerHtml;
         string[] strReg = new string[4];
         //Console.WriteLine(strMes);
         Console.WriteLine("######################################################################");
         foreach (var aux in temp.Descendants("tbody"))
         {
            string strMes = temp.Element("a").InnerHtml;
            Console.WriteLine(strMes);
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
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
               reg.Add(new Calender { Dia = strReg[0], Evento = strReg[1], simbolo = strReg[2], Descricao = strReg[3] });
               k = 0;
            }

            foreach (var objt in reg)
            {
               Console.Write("Dia: " + WebUtility.HtmlDecode(objt.Dia));
               Console.Write(", Evento: " + WebUtility.HtmlDecode(objt.Evento).Replace("\t", "").Replace("\n", ""));
               Console.WriteLine("");
               string Descricao = objt.Descricao.Replace("\n", "");
               Console.Write("Descricao: " + WebUtility.HtmlDecode(Descricao).Replace("\t", ""));
               Console.WriteLine("");
               Console.WriteLine("------------=========================================================================----------");
            }

         }
      }
   }
}





       
       */
   }
}
