using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Franco.Modelos
{
    public class Products
    {
        //genero un nuevo constructor vacío para que lo pueda llama Dapper para crear la clase:
        public Products() { }   


        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        
        
        
        
        
        //public  Products (int id, string title, decimal price)
        //{
        //    this.id = id;
        //    this.title = title;
        //    this.price = price;
        //}
        

    }
}
