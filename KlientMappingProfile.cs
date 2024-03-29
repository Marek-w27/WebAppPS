﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebAppPS.Entity;
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



            CreateMap<Weryfikacja, WeryfikacjaDto>()
                .ForMember(m => m.WyszNip, c => c.MapFrom(s => s.WyszNip))
                .ForMember(m => m.Weryfikacja1, c => c.MapFrom(s => s.Weryfikacja1))
                .ForMember(m => m.Wynik, c => c.MapFrom(s => s.Wynik));


        }

    }


}
