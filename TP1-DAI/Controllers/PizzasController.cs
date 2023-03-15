using Microsoft.AspNetCore.Mvc;
using Pizzas.Models;
namespace Pizzas.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase{
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pizza> lista = BD.ListarPizzas();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            if (Id < 1)
            {
                return BadRequest ();
            }
            Pizza pizzas = BD.VerInfoPizza (Id);
            if (pizzas == null)
            {
                return NotFound();
            }
            return Ok(pizzas);

        }

        [HttpPost]
        public IActionResult Create (Pizza pizzas)
        {
            BD.CrearPizza(pizzas);
            return Ok();
        }

        
    }
    

    
}