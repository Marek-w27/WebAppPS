using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Data.Common;

namespace WebAppPS.Models
{
    public class AddInfo 
    {
        private readonly RekrutacjaContext _dbContext;
        public AddInfo(RekrutacjaContext dbcontext)
    {
            dbcontext = _dbContext;
    }
    


      void basicVerif(string nip)
        {
            var p1 = new DbParameter("@nip");
            var facVer = _dbContext.Database.ExecuteSqlRaw("INSERT INTO Weryfikacja ( id,WyszNip,DataWysz,weryfikacja ) VALUES(NEWID(), @nip, GETDATE(), 'BasicWeryf')");
        }


    }
}
