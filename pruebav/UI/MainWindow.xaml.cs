using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using System.Data;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ClTienda tienda = new ClTienda();
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                

                case "listViewItem1":
                    grproductos.Height = 700;
                    grventa.Height = 0;
                    grreporte.Height = 0;
                    dgproductos.ItemsSource = tienda.ListaProductos().DefaultView;
                    break;
                case "listViewItem2":

                    grventa.Height = 700;
                    grproductos.Height = 0;
                    grreporte.Height = 0;
                    comboProducto.ItemsSource = tienda.ListaProductos().DefaultView;
                    comboProducto.SelectedValuePath = "Codigo de Barras";
                    comboProducto.DisplayMemberPath = "Descripcion";
                    txfecha.Text = DateTime.Now.ToShortDateString();
                    break;
                case "listViewItem3":
                    grproductos.Height = 0;
                    grventa.Height = 0;
                    grreporte.Height = 700;
                    dgreporte.ItemsSource = tienda.Reportedeldia().DefaultView;
                    break;
            }
        }
        #region genaral
        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;

            try
            {
                this.DragMove();
            }
            catch { }
        }

        private void StackPanel_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;

            try
            {
                this.DragMove();
            }
            catch { }
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
           
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
           
        }
        #endregion 



        //ingreso
        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtcodigo.Text = "";
            txtdescripcion.Text = "";
            txtespecificaciones.Text = "";
            txtpreciocosto.Text = "";
            txtprecioventa1.Text = "";
            txtprecioventa2.Text = "";
        }

        private void Btn_Ingreso_Click(object sender, RoutedEventArgs e)
        {
            if(tienda.IngresarProducto(txtcodigo.Text, txtdescripcion.Text, txtprecioventa1.Text, txtprecioventa2.Text, txtcodigo.Text, txtespecificaciones.Text)== "Ingresado Exitosamente")
            {
                txtcodigo.Text = "";
                txtdescripcion.Text = "";
                txtespecificaciones.Text = "";
                txtpreciocosto.Text = "";
                txtprecioventa1.Text = "";
                txtprecioventa2.Text = "";

                //actualizar grid

                dgproductos.ItemsSource = tienda.ListaProductos().DefaultView;
            }
        }




        //venta
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnborrar_Click(object sender, RoutedEventArgs e)
        {
            ventas = new DataTable();
            dgventa.ItemsSource = ventas.DefaultView;
            ventas = null;
        }

        private void comboProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRow dat = tienda.ObtenerProdu(comboProducto.SelectedValue.ToString());
                comboprecio.Items.Clear();
                comboprecio.Items.Add(decimal.Round(decimal.Parse(dat[2].ToString())));
                comboprecio.Items.Add(decimal.Round(decimal.Parse(dat[3].ToString())));
            }
            catch 
            {
            }
            
        }
        DataTable ventas;
        decimal total;
        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            
            tienda.IngresarEnca(txtCliente.Text, txtobservaciones.Text, total);
            int x = 0;
            foreach (DataRow item in ventas.Rows)
            {
                x++;
                tienda.IngresarVenta(x, item[0].ToString(), int.Parse(item[2].ToString()), item[3].ToString(), decimal.Parse(item[4].ToString()),txfactura.Text);
            }
            ventas = new DataTable();
            dgventa.ItemsSource = ventas.DefaultView;
            ventas = null;
            nfac();
        }

        private void btnagregar_Click(object sender, RoutedEventArgs e)
        {
            if(ventas==null)
            {
                ventas = new DataTable();
                ventas.Columns.Add("Codigo");
                ventas.Columns.Add("Producto");
                ventas.Columns.Add("Cantidad");
                ventas.Columns.Add("Precio");
                ventas.Columns.Add("Subtotal");
            }
                DataRow ro = ventas.NewRow();
                ro[0] = comboProducto.SelectedValue;
                ro[1] = comboProducto.Text;
                ro[2] = txtcantidad.Text;
                ro[3] = comboprecio.Text;
                ro[4] = decimal.Parse(txtcantidad.Text) * decimal.Parse(comboprecio.Text);
                total += decimal.Parse(ro[4].ToString());
                ventas.Rows.Add(ro);

                dgventa.ItemsSource = ventas.DefaultView;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nfac();
        }
        protected void nfac()
        {

            int d = 1001 + tienda.NEncabezado();

            txfactura.Text = d.ToString();
        }
    }
}
