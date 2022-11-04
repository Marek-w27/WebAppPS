using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPS.Models
{
    public class KlienciDto
    {
        public int Id { get; set; }
        public string Nip { get; set; }
        public string Rola { get; set; }
        public string NazwaPelna { get; set; }
        public string NazwaSkrocona { get; set; }
        public DateTime? DataDodania { get; set; }
        public string Profil { get; set; }
        public string NumerUmowy { get; set; }
        public decimal? LimitNaUmowie { get; set; }
        public DateTime? DataPodpisaniaUmowy { get; set; }

    }

}
