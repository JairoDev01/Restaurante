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

namespace restaurante
{
    public partial class Form1 : Form
    {
        Conexion con;
        public Form1()
        {
            InitializeComponent();
            con = new Conexion();
            con.cerrar_conexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hacerLogin();
        }

        private void hacerLogin()
        {
            if(textBoxUsuario.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Ingrese todos los datos. ");
            }
            else
            {
                
                con.cerrar_conexion();
                String sql = "select * from usuarios where usuario = '" + textBoxUsuario.Text + "' and password = '" + textBoxPassword.Text + "'";
                MySqlDataReader dr = con.buscarRegistro(sql).ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Credenciales correctas");
                }
                else
                {
                    MessageBox.Show("Contrase o usuario incorrectas");
                }
            }
        }
    }
}
