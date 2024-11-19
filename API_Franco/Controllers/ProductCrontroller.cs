using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio_Franco;
using Negocio_Franco.Modelos;
using Org.BouncyCastle.X509;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace API_Franco.Controllers
{
    //controller hace referencia a al Product de ProductController
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCrontroller : ControllerBase
    {
        ProductsAPI api = new ProductsAPI();
        [HttpGet("products")]
        public IActionResult Get()
        {
            try
            {
                var products = api.GetAll();
                if (products == null || !products.Any())
                {
                    //204 NoContent indica que no hay productos:
                    return NoContent(); 
                }
                return Ok(products); // 200 ok
            }
            catch (Exception ex)
            {
                // Devuelve 400 BadRequest con el mensaje de la excepción:
                return BadRequest(ex.Message); 
            }
        }




        // GET: api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var products = api.GetById(id);
                if (products == null)
                {
                    //404 not found no se encontró el producto con esa id:
                    return NotFound(); 
                }
                // 200 ok:
                return Ok(products); 
            }
            catch (Exception ex)
            {
                // Devuelve 400 BadRequest con el mensaje de la excepción:
                return BadRequest(ex.Message); 
            }
        }








        [HttpPost("products")]


        public IActionResult Post([FromBody] Products products)
        {
            Products productoFran;

            try
            {
                productoFran = api.Post(products);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return StatusCode(201, productoFran);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("products/{id}")]

        public IActionResult Put(int id, [FromBody] Products product)
        {
            try
            {
                product.id = id;
                var ActualizacionProd = api.Put(product);
                if (ActualizacionProd == null)
                {
                    return NotFound();
                }
                return Ok(ActualizacionProd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Products prod = api.Put(product);
        //return StatusCode(StatusCodes.Status200OK, prod);
        //        }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "");
        //    }
        //}

        // DELETE api/<ValuesController>/5
        [HttpDelete("products/{id}")]


        public IActionResult Delete(int id)
        {
            try
            {
                var EliminacionProd = api.Delete(id);
                    if (EliminacionProd == 0) // Si no borró nada, EliminacionProd debería ser 0.
                {
                    // 404 not found si el producto no existe
                    return NotFound(); 

                }
                // 204 NoContent si funcionó correctamente:
                return NoContent(); 
                                   
            }
            catch (Exception ex)
            {
                // Devuelve 400 BadRequest con el mensaje de la excepción:
                return BadRequest(ex.Message); 
            }

            //if (api.Delete(id) == 0)
            //{
            //    return StatusCode(StatusCodes.Status200OK);
            //}
        }
    }
}

