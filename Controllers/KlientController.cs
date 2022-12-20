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
using WebAppPS.Services;

namespace WebAppPS.Controllers
{
    [Route("api/Weryfication")]
    public class KlientController : ControllerBase
    {

        private readonly IKlientService _klientService;


        public KlientController(IKlientService klientService )
        {
            _klientService = klientService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Weryfikacja>> GetAll()
        {
            var WeryfikacjaDto = _klientService.PobierzListeWeryfikacji();

            return Ok(WeryfikacjaDto);
        }




    [HttpGet("{nip}")]
        public ActionResult<WeryfikacjaAll> Get([FromRoute] string nip)
        {
            var WeryfikacjaNowa = _klientService.NowaWeryfikacja(nip);

            return Ok(WeryfikacjaNowa);
        }
    }
}
