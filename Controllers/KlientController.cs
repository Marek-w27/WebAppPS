using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppPS.Models;

namespace WebAppPS.Controllers
{
    [Route("api/klient")]
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
        public ActionResult<IEnumerable<KlienciDto>> GetAll()
        {
            var klienci = _dbContext
                .Klienci
                .ToList();



            var klienciDto = _mapper.Map<List<KlienciDto>>(klienci);

            return Ok(klienciDto);
        }




        [HttpGet("{rola}")]
        public ActionResult<KlienciDto> Get([FromRoute] string rola)
        {
            var klienci =_dbContext
                .Klienci
                .FirstOrDefault(x => x.Rola == rola);

            if (klienci is null)
            {
                return NotFound();
            }
            var klienciDto = _mapper.Map<KlienciDto>(klienci);
            return Ok(klienciDto);
        }
    }
}
