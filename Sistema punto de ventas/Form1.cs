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
using ViewModels.Library;

namespace Sistema_punto_de_ventas
{
    public partial class Form1 : Form
    {
        public Form1(List<TUsuarios> listUsuarios)
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

       

        private void label5cliente_nombre_Click(object sender, EventArgs e)
        {

        }
        /* *********************************
         * 
         *      Codigo Cliente
         *      
         * *********************************/
        #region
        private ClientesVM clientes;
        private void btncliente_Click(object sender, EventArgs e)
        {
            var textBoxCliente = new List<TextBox>();
            textBoxCliente.Add(textBoxnombre_cliente);
            textBoxCliente.Add(textBoxapellido_cliente);
            textBoxCliente.Add(textBoxnid_cliente);
            textBoxCliente.Add(textBoxcorreo_cliente);
            textBoxCliente.Add(textBoxtelefono_cliente);

            var LabelCliente = new List<Label>();
            LabelCliente.Add(labelnombre_cliente);
            LabelCliente.Add(labelapellido_cliente);
            LabelCliente.Add(labelnid_cliente);
            LabelCliente.Add(labelcorreo_cliente);
            LabelCliente.Add(labeltelefono_cliente);

            object[] objetos =
            {
                 dataGridView_clientes
            };
            clientes = new ClientesVM(objetos, textBoxCliente, LabelCliente);
            tabControlPrincipal.SelectedIndex = 1;
        }

        private void pictureBoxClientes_Click(object sender, EventArgs e)
        {
            Objects.uploadImage.CargarImagen(pictureBoxClientes);
        }

        private void textBox2cliente_nombre_TextChanged(object sender, EventArgs e)
        {
            if(textBoxnombre_cliente.Text.Equals(""))
            {
                labelnombre_cliente.ForeColor = Color.Black;
            }
            else
            {
                labelnombre_cliente.Text = "Nid";
                labelnombre_cliente.ForeColor = Color.Green;
            }
        }

        private void textBox2cliente_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.numberKeyPress(e);
        }

        private void textBox1cliente_apellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxapellido_cliente.Text.Equals(""))
            {
                labelapellido_cliente.ForeColor = Color.Black;
            }
            else
            {
                labelapellido_cliente.Text = "Nombre";
                labelapellido_cliente.ForeColor = Color.Green;
            }
        }

        private void textBox1cliente_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void textBoxcliente_id_TextChanged(object sender, EventArgs e)
        {
            if (textBoxnid_cliente.Text.Equals(""))
            {
                labelnid_cliente.ForeColor = Color.Black;
            }
            else
            {
                labelnid_cliente.Text = "Apellido";
                labelnid_cliente.ForeColor = Color.Green;
            }
        }

        private void textBoxcliente_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void textBox2cliente_email_TextChanged(object sender, EventArgs e)
        {
            if (textBoxcorreo_cliente.Text.Equals(""))
            {
                labelcorreo_cliente.ForeColor = Color.Black;
            }
            else
            {
                labelcorreo_cliente.Text = "Correo";
                labelcorreo_cliente.ForeColor = Color.Green;
            }
        }

        private void textBox1cliente_telefono_TextChanged(object sender, EventArgs e)
        {
            if (textBoxtelefono_cliente.Text.Equals(""))
            {
                labeltelefono_cliente.ForeColor = Color.Black;
            }
            else
            {
                labeltelefono_cliente.Text = "Telefono";
                labeltelefono_cliente.ForeColor = Color.Green;
            }
        }

        private void textBox1cliente_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.numberKeyPress(e);
        }

        private void button2cliente_agregar_Click(object sender, EventArgs e)
        {
            clientes.GuardarCliente();
        }

        private void button3cliente_cancelar_Click(object sender, EventArgs e)
        {
            clientes.restablecer();
        }
        private void dataGridView_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView_clientes.Rows.Count != 0)
            clientes.GetCliente();
        }

        private void dataGridView_clientes_KeyUp(object sender, KeyEventArgs e)
        {
            if(dataGridView_clientes.Rows.Count != 0)
            clientes.GetCliente();
        }

        private void textBoxBuscar_Cliente_TextChanged(object sender, EventArgs e)
        {
            clientes.SearchClienteAsync(textBoxBuscar_Cliente.Text);
        }

        #endregion

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
