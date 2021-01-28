using Models.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;

namespace Sistema_punto_de_ventas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private LoginVM login;
        private void buttoniniciar_sesion_Click(object sender, EventArgs e)
        {
            var textBox = new List<TextBox>
            {
                textBoxusuario,
                textBoxpassword
            };
            var label = new List<Label>
            {
                labelusuario,
                labelpassword
            };
            login = new LoginVM(textBox, label);
            object[] objects = login.Login();
            var listUsario = (List<TUsuarios>)objects[0];
            if(0 < listUsario.Count)
            {
                Form1 form1 = new Form1(listUsario);
                form1.Show();
                Visible = false;
            }

        }

        private void textBoxusuario_TextChanged(object sender, EventArgs e)
        {
            if (textBoxusuario.Text.Equals(""))
            {
                labelusuario.ForeColor = Color.Black;
            }
            else
            {
                labelusuario.Text = "Correo";
                labelusuario.ForeColor = Color.Green;
            }
        }

        private void textBoxpassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxpassword.Text.Equals(""))
            {
                labelpassword.ForeColor = Color.Black;
            }
            else
            {
                labelpassword.Text = "Contraseña";
                labelpassword.ForeColor = Color.Green;
            }
        }
    }
}
