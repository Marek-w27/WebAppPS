using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var klienci = _dbContext
                            .Klienci
                            .Include(x => x.KlienciKontrahenciIdKlientaNavigations)
                            .FirstOrDefault(x => x.Nip.Equals(nip));

            if (klienci is null) return null;






            var result1 = _mapper.Map<KlienciDto>(klienci);
            return result1;
        }



    }
}