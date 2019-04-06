using HtmlAgilityPack;
using System.Net;

namespace Scrape.Models
{
   public class Calender
   {
      public string Mes { get; set; }
      public string FormatJson { get; set; }
      public HtmlNode[] Propriedades { get; set; } = new HtmlNode[4];

      public Calender(string mes, HtmlNode[] propriedades)
      {
         Mes = mes;
         Propriedades = propriedades;
      }

      public override string ToString()
      {
         return "{" + "\"mes\"" + ":\"" + Mes + "\","
            + "\"dia\"" + ":\"" + WebUtility.HtmlDecode(Propriedades[0].InnerText)
            + "\"," + "\"evento\":\"" + WebUtility.HtmlDecode(Propriedades[1].InnerText)
            + "\"," + "\"descricao\":\"" + WebUtility.HtmlDecode(Propriedades[3].InnerText) + "\"}";
      }
   }
}
