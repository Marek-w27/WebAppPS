using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPS.Entity;
using WebAppPS.Entity.ViewModels;
using WebAppPS.Models;

namespace WebAppPS.Controllers
{
    [Route("api/Weryfication")]
    public class KlientController : ControllerBase
    {
        private readonly RekrutacjaContext _dbContext;
        private readonly IMapper _mapper;

        public KlientController(RekrutacjaContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Weryfikacja>> GetAll()
        {
            var klienci = _dbContext
                .Weryfikacja
                .ToList();



            

            return Ok(klienci);
        }




    [HttpGet("{nip}")]
        public ActionResult<WeryfikacjaAll> Get([FromRoute] string nip)
        {
            Weryfikacja weryfikacja = new Weryfikacja()
            {
                Id = Guid.NewGuid(),
                WyszNip = nip,
                DataWysz = DateTime.Now,
                
            };


            var klienci = _dbContext
                .ViewWeryfikacjaAlls
                .FirstOrDefault(x => x.Nip == nip);



            if (klienci != null)

            {
                if (klienci.Rola.Equals("Faktorant"))
                {
                    var klienci2 = _dbContext
                   .ViewWeryfikacjaFaktorants
                   .FirstOrDefault(x => x.Nip == nip);




                    if (klienci2 is null)
                    {
                        return NotFound();
                    }

                    weryfikacja.Weryfikacja1 = "WeryfikacjaFaktorant";


                    _dbContext.Weryfikacja.Add(weryfikacja);
                    _dbContext.SaveChanges();

                    return Ok(klienci2);
                }
                else
                {

                    if (klienci is null)
                    {
                        return NotFound();
                    }



                    weryfikacja.Weryfikacja1 = "WeryfikacjaAll";

                    _dbContext.Weryfikacja.Add(weryfikacja);
                    _dbContext.SaveChanges();


                    return Ok(klienci);
                }
            }
            else return NotFound();
        }
    }
}
