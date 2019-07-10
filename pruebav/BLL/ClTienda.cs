using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.TiendaTableAdapters;
using System.Data;

namespace BLL
{
    public class ClTienda
    {
        private ProductoTableAdapter producto;
        private DetalleTableAdapter detalle;
        private EncabezadoTableAdapter encabezado;
      


        private ProductoTableAdapter Producto
        {
            get
            {
                if (producto == null)
                    producto = new ProductoTableAdapter();
                return producto;
            }

        }

        private DetalleTableAdapter Detalle
        {
            get
            {
                if (detalle == null)
                    detalle = new DetalleTableAdapter();
                return detalle;
            }

       
        }

        private EncabezadoTableAdapter Encabezado
        {
            get
            {

                if (encabezado == null)
                    encabezado = new EncabezadoTableAdapter();
                return encabezado;
            }

            
        }



        public string IngresarProducto(string codigo,string descri, string venta1,string venta2, string costo,string observa)
        {
            string resultado;
            try
            {
                Producto.InsertProducto(codigo, descri, decimal.Parse(venta1), decimal.Parse(venta2), decimal.Parse(costo), observa);
                resultado = "Ingresado Exitosamente";
            }
            catch
            {
                resultado = "Error Al Ingresar";
            }
            return resultado;
        }

        public string IngresarEnca(string cliente, string Observ, decimal total)
        {
            string resultado;
            try
            {
                Encabezado.InsertEnca(cliente, total, Observ);
                resultado = "Ingresado Exitosamente";
            }
            catch
            {
                resultado = "Error Al Ingresar";
            }
            return resultado;
        }
       

        public string IngresarVenta(int num,string idProducto, int cantidad, string precioventa,decimal subtotal, string codigofact)
        {
            string resultado;
            try
            {
                string x = codigofact + "-" + num;
                Detalle.InsertDetalle(x, idProducto, cantidad,decimal.Parse(precioventa),subtotal);
                resultado = "Ingresado Exitosamente";
            }
            catch
            {
                resultado = "Error Al Ingresar";
            }
            return resultado;
        }





        public DataTable ListaProductos()
        {
            DataTable ta = new DataTable();
            ta = Producto.GetData();

            return ta;
        }
        public DataRow ObtenerProdu(string codigo)
        {
            DataTable ta = new DataTable();
            ta = Producto.GetDataByObtener(codigo);

            return ta.Rows[0];
        }

        public int NEncabezado()
        {
            return int.Parse(Encabezado.ScalarNEncabezado().ToString());
        }


        public DataTable Reportedeldia()
        {
            DataTable ta = new DataTable();
            ta = Encabezado.GetData();

            return ta;
        }
    }
}
