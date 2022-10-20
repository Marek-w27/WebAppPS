using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebAppPS.Models;

namespace WebAppPS
{
    public class KlientMappingProfile : Profile
    {
        public KlientMappingProfile()
        {
            CreateMap<Klienci, KlienciDto>()
                .ForMember(m => m.Id, c => c.MapFrom(s => s.Id))
                .ForMember(m => m.NazwaPelna, c => c.MapFrom(s => s.NazwaPelna))
                .ForMember(m => m.Rola, c => c.MapFrom(s => s.Rola))
                .ForMember(m => m.Profil, c => c.MapFrom(s => s.Profil));
        }
    }
}
