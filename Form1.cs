using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DesayunoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        int idproducto = 0;
        private void button1_MouseHover(object sender, EventArgs e)
        {
            UsRegistrar.Image = DesayunoProject.Properties.Resources.registro;
            UsRegistrar.BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            UsRegistrar.Image = DesayunoProject.Properties.Resources.registroblanco;
            UsRegistrar.BackColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Image = DesayunoProject.Properties.Resources.buscarcolor;
            button2.BackColor = Color.LightGreen;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = DesayunoProject.Properties.Resources.buscar1;
            button2.BackColor = Color.White;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.LightYellow;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Image = DesayunoProject.Properties.Resources.registrado;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = DesayunoProject.Properties.Resources.registradoblanco;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Image = DesayunoProject.Properties.Resources.metodo_de_pago_color;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Image = DesayunoProject.Properties.Resources.metodo_de_pago;
        }

        private void UsRegistrar_Click(object sender, EventArgs e)
        {
            String Nombre = UsNombre.Text;
            int edad = int.Parse(UsEdad.Text);
            int Numcontrol = int.Parse(UsNumControl.Text);

            string sql = "INSERT INTO usuarios (Nombre, Edad, Numcontrol) VALUES ('"+Nombre+ "','" + edad + "','" + Numcontrol + "')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
                limpiarUsuario();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        private void limpiarUsuario()
        {
            UsNombre.Text = "";
            UsEdad.Text = "";
            UsNumControl.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string Nombre = Pnombre.Text;
            double precio = double.Parse(Pprecio.Text);
            string clave= Pclave.Text;

            string sql = "INSERT INTO productos (Nombre, Precio, Clave) VALUES ('" + Nombre + "','" + precio + "','" + clave + "')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int control = int.Parse(Ubuscar.Text);
            MySqlDataReader reader = null;

            string sql = "SELECT Nombre, Edad, NumControl FROM Usuarios WHERE NumControl LIKE '" + control + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ubuscar.Text = reader.GetString(2);
                        UsNombre.Text = reader.GetString(0);
                        UsEdad.Text = reader.GetString(1);
                        UsNumControl.Text = reader.GetString(2);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            idproducto = idproducto - 1;
            string sql = "SELECT Nombre, Precio, Clave FROM productos WHERE idproductos LIKE '" + idproducto + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PinfoNom.Text = reader.GetString(0);
                        PinfoPrecio.Text = reader.GetString(1);
                        Pinfoclave.Text = reader.GetString(2);
                    }
                }

                else
                {
                    idproducto = +1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ha llegado al limite" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            idproducto = idproducto+1;
            string sql = "SELECT Nombre, Precio, Clave FROM productos WHERE idproductos LIKE '" + idproducto + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PinfoNom.Text = reader.GetString(0);
                        PinfoPrecio.Text = reader.GetString(1);
                        Pinfoclave.Text = reader.GetString(2);
                    }
                }

                else
                {
                    idproducto = idproducto-1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int control = int.Parse(Ubuscar.Text);

            string sql = "DELETE FROM Usuarios WHERE NumControl LIKE '" + control + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteReader();
                MessageBox.Show("Usuario Eliminado");
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Eliminar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clave = Pclave.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT Nombre, Precio, Clave FROM productos WHERE Clave LIKE '" + clave + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Pnombre.Text = reader.GetString(0);
                        Pprecio.Text = reader.GetString(1);
                        Pclave.Text = reader.GetString(2);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string clave = Pclave.Text;

            string sql = "DELETE FROM Productos WHERE Clave LIKE '" + clave + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteReader();
                MessageBox.Show("Producto Eliminado");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al Eliminar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (UsNombre.Text == "" || UsEdad.Text == ""  || UsNumControl.Text == "")
            {
                MessageBox.Show("Registre un Usuario o Busque alguno");
            }
            else
            {
                int control = int.Parse(UsNumControl.Text);
                if (UsuarioExiste(control) == true)
                {
                    Cunombre.Text = UsNombre.Text;
                    Cuedad.Text = UsEdad.Text;
                    cucontrol.Text = UsNumControl.Text;
                }
                else
                {
                    MessageBox.Show("El ususario No existe");
                }
            }

            if (PinfoNom.Text == "Nombre" || PinfoPrecio.Text == "Precio" || Pinfoclave.Text == "clave")
            {
                MessageBox.Show("Registre un Producto o Busque alguno");
            }
            else
            {
                if (ProductoExiste(Pinfoclave.Text) == true)
                {
                    Cpnombre.Text = PinfoNom.Text;
                    Cpprecio.Text = PinfoPrecio.Text;
                }
                else
                {
                    MessageBox.Show("El producto No existe");
                }
            }
            fecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private static Boolean UsuarioExiste(int NumControl)
        {
            int control = NumControl;
            MySqlDataReader reader = null;

            string sql = "SELECT Nombre, Edad, NumControl FROM Usuarios WHERE NumControl LIKE '" + control + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexionDB);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }

            conexionDB.Close();
        }

        private static Boolean ProductoExiste(string clave)
        {
            MySqlDataReader reader = null;

            string sql = "SELECT Nombre, Precio, Clave FROM productos WHERE clave LIKE '" + clave + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();
            MySqlCommand comando = new MySqlCommand(sql, conexionDB);
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }

            conexionDB.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String producto = PinfoNom.Text;
            double precio = double.Parse(Cpprecio.Text);
            string Cfecha = fecha.Text;
            int controlusuario = int.Parse(cucontrol.Text);

            string sql = "INSERT INTO compras (Nombre, Precio, Fecha, ControlUsuario) VALUES ('" + producto + "','" + precio + "','" + Cfecha + "','" + controlusuario + "')";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Compra registrada");
                limpiarUsuario();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        int idcompra = 0;
        private void button10_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            idcompra = idcompra -1;
            string sql = "SELECT Nombre, Precio, fecha, ControlUsuario FROM compras WHERE idcompras LIKE '" + idcompra + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mostrarCompras.Text = reader.GetString(0) +" "+ reader.GetString(1) +" "+ reader.GetString(2) +" "+ reader.GetString(3);
                       
                    }
                }

                else
                {
                    idcompra = idcompra + 1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            idcompra = idcompra + 1;
            string sql = "SELECT Nombre, Precio, fecha, ControlUsuario FROM compras WHERE idcompras LIKE '" + idcompra + "'";

            MySqlConnection conexionDB = Conexion.conexion();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        mostrarCompras.Text = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);

                    }
                }

                else
                {
                    idcompra = idcompra - 1;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
