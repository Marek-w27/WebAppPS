using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPS.Entity.ViewModels
{
    public class WeryfikacjaFaktorant
    {
        public string Nip { get; set; }
        public string NazwaPelna { get; set; }
        public DateTime? Datadodania  { get; set; }
        public string Rola { get; set; }
        public string Profil { get; set; }
        public Decimal? LimitNaUmowie { get; set; }
        public DateTime? DataPodpisaniaUmowy { get; set; }
    }
}
