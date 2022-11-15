using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppPS.Entity
{
    public partial class Weryfikacja
    {
        public Guid? Id { get; set; }
        public DateTime? DataWysz { set; get; }
        public string WyszNip { get; set; } 
        public string Weryfikacja1 { get; set; }
    }
}
