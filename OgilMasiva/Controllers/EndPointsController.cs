using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceOgil;
using Models;
using ModelsOgil;

namespace OgilMasiva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndPointsController : Controller
    {
        private IRoulette rouletteInterface;
        public EndPointsController(IRoulette rouletteInterface)
        {
            this.rouletteInterface = rouletteInterface;
        }
        [HttpPost]//EndPoints 1
        public IActionResult NewRulette()
        {
            Roulette roulette = rouletteInterface.create();
            return Ok(roulette.Id);
        }
        [HttpPut("{id}/open")] //EndPoints 2
        public IActionResult Open([FromRoute(Name = "id")] string id)
        {
            try
            {
                rouletteInterface.Open(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }
        [HttpPost("{id}/bet")]//EndPoints 3
        public IActionResult BetDoard([FromHeader(Name = "user-id")] string UserId, [FromRoute(Name = "id")] string id,
            [FromBody] Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }

            try
            {
                Roulette roulette = new Roulette();
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }

        }

        [HttpPut("{id}/close")]//EndPoints 4
        public IActionResult Close([FromRoute(Name = "id")] string id)
        {
            try
            {
                Roulette roulette = rouletteInterface.Close(id);
                return Ok(roulette);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }
        [HttpGet] //EndPoints 5
        public IActionResult GetAll()
        {
            return Ok(rouletteInterface.GetAll());
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
