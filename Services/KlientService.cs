using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using WebAppPS.Entity;
using WebAppPS.Models;

namespace WebAppPS.Services
{
    public interface IKlientService
    {
        IEnumerable<WeryfikacjaDto> PobierzListeWeryfikacji();
        KlienciDto NowaWeryfikacja(string nip);

    }


    public class KlientService : IKlientService
    {
        private readonly RekrutacjaContext _dbContext;
        private readonly IMapper _mapper;
        public KlientService(RekrutacjaContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

       

        public IEnumerable<WeryfikacjaDto> PobierzListeWeryfikacji()
        {
           
            var weryfikacja = _dbContext
                .Weryfikacja
                .ToList();
 

            var weryfikacjaDto = _mapper.Map<List<WeryfikacjaDto>>(weryfikacja);

            return weryfikacjaDto;
        }



        public KlienciDto NowaWeryfikacja(string nip)
        {
            Weryfikacja weryfikacja = new Weryfikacja();
          

            var klienci = _dbContext
                            .Klienci
                            .Include(x => x.KlienciKontrahenciIdKlientaNavigations)
                            .FirstOrDefault(x => x.Nip.Equals(nip));

            if (klienci is null) return null;


            weryfikacja.Id = Guid.NewGuid();
            weryfikacja.WyszNip = nip;
            weryfikacja.DataWysz = DateTime.Now;
            weryfikacja.Weryfikacja1 = "BasicWeryf";
            _dbContext.SaveChanges();




            if (klienci.Rola.Equals("Faktorant"))

            {
                Weryfikacja weryfikacja1 = new Weryfikacja();

                weryfikacja1.Id = Guid.NewGuid();
                weryfikacja1.WyszNip = nip;
                weryfikacja1.DataWysz = DateTime.Now;
                weryfikacja1.Weryfikacja1 = "FacWeryf";
                _dbContext.SaveChanges();

              
                var facVer = _dbContext.Database.ExecuteSqlRaw("INSERT INTO Weryfikacja ( id,WyszNip,DataWysz,weryfikacja ) VALUES(NEWID(), @nip, GETDATE(), 'BasicWeryf')");

            }


            if (klienci.NazwaPelna.Contains("P"))
            {
                Weryfikacja weryfikacja2 = new Weryfikacja();
                weryfikacja2.Id = Guid.NewGuid();
                weryfikacja2.WyszNip = nip;
                weryfikacja2.DataWysz = DateTime.Now;
                weryfikacja2.Weryfikacja1 = "NameWeryf";
                _dbContext.SaveChanges();
            }

           
            var result1 = _mapper.Map<KlienciDto>(klienci);
            return result1;
        }

       
        void SprawdzWeryfikacje(string weryf)
        {
            Weryfikacja weryfikacja = new Weryfikacja();




            if (weryf.Equals("BasicWeryf"))
            {
              
            }

            if (weryf.Equals("FacWeryf"))
            {

            }

            if (weryf.Equals("NameWeryf"))
            {

            }


        }
       
    }
}