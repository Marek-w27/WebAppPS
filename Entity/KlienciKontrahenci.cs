using System;
using System.Collections.Generic;

#nullable disable

namespace WebAppPS.Models
{
    public partial class KlienciKontrahenci
    {
        public int IdKlienta { get; set; }
        public int IdKontrahenta { get; set; }
        public decimal? LimitNaUmowie { get; set; }

        public virtual Klienci IdKlientaNavigation { get; set; }
        public virtual Klienci IdKontrahentaNavigation { get; set; }
    }
}
