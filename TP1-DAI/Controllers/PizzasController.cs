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
        public IActionResult Create (Pizza pizza)
        {
            BD.CrearPizza(pizza);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizzaNueva)
        {
            if(id != pizzaNueva.Id)
            {
                return BadRequest();
            }
            Pizza pizzaVieja = BD.VerInfoPizza(id);
            if(pizzaVieja == null)
            {
                return NotFound();
            }
            BD.ActualizarPizza(id, pizzaNueva);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            if(id<1)
            {
                return BadRequest();
            }
            if(BD.EliminarPizza(id)==0)
            {
                return NotFound();
            }
            BD.EliminarPizza(id);
            return Ok();

        }

        
    }
    

    
}