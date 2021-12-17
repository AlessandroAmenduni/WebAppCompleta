using ITS.AmenduniA.SampleWebApp.Models;
using ITS.AmenduniA.SampleWebApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITS.AmenduniA.SampleWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsService _productservice; //serve un AddSingleton <nome interfaccia, classe>

        //l'interfaccia passa i metodi tramite costruttore
        public ProductsController(IProductsService productservice)
        {
            _productservice = productservice;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _productservice.GetAll();
            return Ok(list); //200

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prodotto = _productservice.GetById(id);
            if(prodotto == null)
            {
                return NotFound();
            }
            return Ok(prodotto);
        }

        [HttpPost]
        public IActionResult Post(Product p)
        {
            _productservice.Insert(p);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product p)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Product p)
        {
            _productservice.Delete(p);
            return Ok();
        }
    }
}
