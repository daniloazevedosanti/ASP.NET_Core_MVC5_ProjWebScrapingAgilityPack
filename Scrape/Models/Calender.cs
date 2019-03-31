using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrape.Models
{
   public class Calender
   {
      //public string Mes { get; set; }
      public string Dia { get; set; }
      public string Evento { get; set; }
      public string Descricao { get; set; }
      public string Totals { get; set; }

      //{"mes":"janeiro", "dia":"01","evento":"","descricao":""}
      public override string ToString()
      {
         return  "\"dia\"" + ":\"" + this.Dia + "\"," + "\"evento\":\"" + this.Evento
             + "\"," + "\"descricao\":\"" + this.Descricao + "\"}";
      }

   }
}
