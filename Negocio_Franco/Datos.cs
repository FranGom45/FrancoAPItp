
using Negocio_Franco.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Franco
{
    internal class Datos
    {
        static public List<Products> listaProductos = new List<Products>();

        static public void agregar(Products product)
        {
            listaProductos.Add(product);
        }
       
    }
}