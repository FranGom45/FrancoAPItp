using Negocio_;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class API_Conexion
    { 
        RestClient client;
    public API_Conexion(string url)
    {
            client = new RestClient("https://fakestoreapi.com");
    }
        public List<apiProducts> GetProducts(string url)
        {

            var cliente = new RestClient(url);
            var request = new RestRequest("products", Method.Get);
            List<apiProducts> products = cliente.Get<List<apiProducts>>(request);


            //Es lo mismo que un if pero en una sola línea
            //Con los dos signos de pregunta, evalúo si es nulo

            return products; 
                //?? new List<apiProducts>();

            //if(products == null)
            //{
            //  products = new List<apiProducts>();
            //} else
            //  return products;
            //}
            public void AddProducts()
            {
                var request = new RestRequest("products", Method.Post);

                string producto = " { title: 'test product', price: 13.5, description: 'lorem ipsum set', category: 'electronic'}";

                request.AddJsonBody(producto, ContentType);

                var response = cliente.Post(request);


            }


        }
    }
}
