using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppPS.Models
{
    public partial class Klienci
    {
        public Klienci()
        {
            KlienciKontrahenciIdKlientaNavigations = new HashSet<KlienciKontrahenci>();
            KlienciKontrahenciIdKontrahentaNavigations = new HashSet<KlienciKontrahenci>();
        }

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

        public virtual ICollection<KlienciKontrahenci> KlienciKontrahenciIdKlientaNavigations { get; set; }
        public virtual ICollection<KlienciKontrahenci> KlienciKontrahenciIdKontrahentaNavigations { get; set; }
    }
}
