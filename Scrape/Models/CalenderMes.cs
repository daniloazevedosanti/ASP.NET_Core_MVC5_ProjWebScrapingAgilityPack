using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrape.Models
{
   public class CalenderMes
   {
      public string Mes { get; set; }
      public Calender calenders { get; set; }
      public string SJson { get; set; }

      public CalenderMes(string mes, string dia, string evento, string descricao)
      {
         this.Mes = mes;
         //calenders = new List<Calender>();
         calenders =new Calender { Dia = dia, Evento = evento, Descricao = descricao };
      }

      public override string ToString()
      {
         return "{" + "\"mes\"" + ":\"" + this.Mes + "\"," + calenders.ToString();
      }
   }
}