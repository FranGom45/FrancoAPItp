using Dapper;
using MySql.Data.MySqlClient;
using Negocio_Franco;
using Negocio_Franco.Modelos;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.Json.Nodes;

namespace Negocio_Franco
{
    public class ProductsAPI
    {
        string connStr = "Server=db4free.net;Database=lasnieves110424;Uid=lasnieves110424;Pwd=lasnieves110424;";

        public List<Products> GetAll()
        {
            //Datos.agregar(new Products(1, "2", 5));

            List<Products> listaProductos = new List<Products>();

            //Quitamos el using al MySqlConnection:

            MySqlConnection conn = new MySqlConnection(connStr);
            
                conn.Open();
                string sql = "SELECT Id, Description, Name, Price FROM  `´Products´";


                //Indico que es lo que quiero devolver(Products) y desde donde(sql):

                listaProductos = conn.Query<Products>(sql).ToList();

                //While (reader.Read())
                //{
                //   int id = reader.GetInt32("id");
                //   string name = reader.GetString("name");
                //   decimal price = reader.GetDecimal("price");

                //   Products p = new Products(id, name, price);

                //   listaProductos.Add(p);
                //}
            

            //return Datos.listaProductos.OrderBy(item => item.id).ToList();

            return listaProductos;


        }

        public Products Post(Products producto)
        {
            

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            
            string sql = "INSERT INTO Products (`price´, `Name´) VALUES (@price,@nombre)";

            int insertados = conn.Execute(sql, new { price = producto.price, name = producto.name});

            return producto;


            //using (MySqlConnection conn = new MySqlConnection(connStr))
            //{  conn.Open();
            //    MySqlCommand cmd = conn.CreateCommand();
            //    //cmd.CommandText = $"INSERT INTO Products(`Description´, `Name´, `price´) VALUES (\"{""}\", \"{producto.title}\",{producto.}

            //    int resultado = cmd.ExecuteNonQuery();

            //}
            //Datos.listaProductos.Add(producto);
            //producto.id = Datos.listaProductos.Count + 1;
            //Datos.listaProductos.Add(producto);

        }

        public Products GetById(int _Id)
        {
            //El .id hace referencia al objeto de la lista que estoy recorriendo en ese momento.

            //Con el first especifico que sea el primero.
            //La condición a cumplir es item.id == Id de la lista de elemntos. Con el item identifico al elemento.
            //Me devuelve un solo producto de ese posible filtro que hagamos sobre la lista de productos:

            //var product = Datos.listaProductos.FirstOrDefault(item => item.id == Id);


            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();

            //Filtro:
            string sql = "SELECT Id, Name, Price FROM  `Products´ where id = @id";

            Products producto = conn.QueryFirst<Products>(sql, new { id = _Id });


            return producto;

        }
        public void Update(Products producto) {

            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();


            string sql = "update Products set `price´ = @price where id = @id";

            int insertados = conn.Execute(sql, new { price = producto.price, name = producto.id});

            

        }



        public int Delete(int id)
        {
            //Expresión lambda
            if (Datos.listaProductos.Any(p => p.id == id))
            {
                return Datos.listaProductos.RemoveAll(item => item.id == id);
            }
            else
            {
                return 0;
            }

        }

        public Products Put(Products prod)
        {
            var product = Datos.listaProductos.FirstOrDefault(item => item.id == prod.id);
            //Datos.listaProductos.Remove(product);
            //Datos.listaProductos.Add(prod);

            if (product == null)
            {
                //return new Products(0, "", 0);
                //return new Products(-1, "", 0);
                //return new Products();

            }
            Datos.listaProductos.Remove(product);
            Datos.listaProductos.Add(prod);
            return prod;
        }




    }
}
