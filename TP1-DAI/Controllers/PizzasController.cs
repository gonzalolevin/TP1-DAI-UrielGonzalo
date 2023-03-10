using Microsoft.AspNetCore.Mvc;
using Pizzas.Models;
namespace Pizzas.API.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase{
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pizzas> lista = BD.ListarPizzas();
            return Ok(lista);
        }

        [HttpGet("{id}")]
         public IActionResult GetById(int id)
         {
            
         }
    }
    

    
}