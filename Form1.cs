using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesayunoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.Image = DesayunoProject.Properties.Resources.registro;
            button1.BackColor = Color.LightGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = DesayunoProject.Properties.Resources.registroblanco;
            button1.BackColor = Color.White;
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

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
