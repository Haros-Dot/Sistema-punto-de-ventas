using LinqToDB;
using Models;
using Models.Conexion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels.Library;

namespace ViewModels
{
    public class ClientesVM : Conexion
    {
        private List<TextBox> _textBoxCliente;
        private List<Label> _LabelCliente;
        private TextBoxEvent evento;
        private string _accion = "insert";
        private PictureBox _imagePictureBox;
        private static DataGridView _dataGridView1;
        private int _reg_por_pagina = 10, _num_pagina = 1;

        public ClientesVM(Object[] objetos, List<TextBox> textBoxCliente, List<Label> labelCliente)
        {
            _textBoxCliente = textBoxCliente;
            _LabelCliente = labelCliente;
            _dataGridView1 = (DataGridView)objetos[0]; 
            evento = new TextBoxEvent();
            restablecer();
        }

        public void GuardarCliente()
        {
            if (_textBoxCliente[0].Text.Equals(""))
            {
                _LabelCliente[0].Text = "Este campo es requerido";
                _LabelCliente[0].ForeColor = Color.Red;
                _textBoxCliente[0].Focus();
            }
            else
            {
                if (_textBoxCliente[1].Text.Equals(""))
                {
                    _LabelCliente[1].Text = "Este campo es requerido";
                    _LabelCliente[1].ForeColor = Color.Red;
                    _textBoxCliente[1].Focus();
                }
                else
                {
                    if (_textBoxCliente[2].Text.Equals(""))
                    {
                        _LabelCliente[2].Text = "Este campo es requerido";
                        _LabelCliente[2].ForeColor = Color.Red;
                        _textBoxCliente[2].Focus();
                    }
                    else
                    {
                        if (_textBoxCliente[3].Text.Equals(""))
                        {
                            _LabelCliente[3].Text = "Este campo es requerido";
                            _LabelCliente[3].ForeColor = Color.Red;
                            _textBoxCliente[3].Focus();
                        }
                        else
                        {
                            if (evento.comprobarFormatocorreo(_textBoxCliente[3].Text))
                            {
                                if (_textBoxCliente[4].Text.Equals(""))
                                {
                                    _LabelCliente[4].Text = "Este campo es requerido";
                                    _LabelCliente[4].ForeColor = Color.Red;
                                    _textBoxCliente[4].Focus();
                                }
                                else
                                {
                                    var cliente1 = TClientes.Where(p => p.Nid.Equals(_textBoxCliente[0].Text)).ToList();
                                    var cliente2 = TClientes.Where(p => p.Correo.Equals(_textBoxCliente[3].Text)).ToList();
                                    var list = cliente1.Union(cliente2).ToList();
                                    switch (_accion)
                                    {
                                        case "insert":
                                            if (list.Count.Equals(0))
                                            {
                                                SaveData();
                                            }
                                            else
                                            {
                                                if (0 < cliente1.Count)
                                                {
                                                    _LabelCliente[0].Text = "el ID ya esta registrado";
                                                    _LabelCliente[0].ForeColor = Color.Red;
                                                    _textBoxCliente[0].Focus();
                                                }
                                                //list[0].Correo.Equals(_textBoxCliente[3].Text)
                                                if (0 < cliente2.Count)
                                                {
                                                    _LabelCliente[3].Text = "el correo ya esta registrado";
                                                    _LabelCliente[3].ForeColor = Color.Red;
                                                    _textBoxCliente[3].Focus();
                                                }
                                            }
                                            break;
                                        case "update":
                                            if (list.Count.Equals(2)) 
                                            {
                                                if (cliente1[0].ID.Equals(_idCliente) && cliente2[0].ID.Equals(_idCliente)) 
                                                {
                                                    SaveData();
                                                }
                                                else
                                                {
                                                    if(cliente1[0].ID != _idCliente)
                                                    {
                                                        _LabelCliente[0].Text = "El nid ya esta registrado";
                                                        _LabelCliente[0].ForeColor = Color.Red;
                                                        _textBoxCliente[0].Focus();
                                                    }
                                                    if (cliente2[0].ID != _idCliente)
                                                    {
                                                        _LabelCliente[3].Text = "El correo ya esta registrado";
                                                        _LabelCliente[3].ForeColor = Color.Red;
                                                        _textBoxCliente[3].Focus();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (list.Count.Equals(0))
                                                {
                                                    SaveData();
                                                }
                                                else
                                                {
                                                    if (0 != cliente1.Count )
                                                    {
                                                        if (cliente1[0].ID.Equals(_idCliente))
                                                        {
                                                            SaveData();
                                                        }
                                                        else
                                                        {
                                                            if (cliente1[0].ID != _idCliente)
                                                            {
                                                                _LabelCliente[0].Text = "El nid ya esta registrado";
                                                                _LabelCliente[0].ForeColor = Color.Red;
                                                                _textBoxCliente[0].Focus();
                                                            }
                                                          
                                                        }
                                                    }
                                                    if (0 != cliente2.Count)
                                                    {
                                                        if  (cliente2[0].ID.Equals(_idCliente))
                                                        {
                                                            SaveData();
                                                        }
                                                        else
                                                        {
                                                            
                                                            if (cliente2[0].ID != _idCliente)
                                                            {
                                                                _LabelCliente[3].Text = "El correo ya esta registrado";
                                                                _LabelCliente[3].ForeColor = Color.Red;
                                                                _textBoxCliente[3].Focus();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                _LabelCliente[3].Text = "Correo no valido";
                                _LabelCliente[3].ForeColor = Color.Red;
                                _textBoxCliente[3].Focus();
                            }


                        }
                    }
                }
            }
        }
        private void SaveData()
        {
            BeginTransactionAsync();
            try
            {
                //var srcImage = Object.uploadimage.ResizeImage(_imagePictureBox.Image, 165, 100);
                switch (_accion)
                {
                    case "insert":
                        TClientes.Value(u => u.Nombre, _textBoxCliente[0].Text)
                            .Value(u => u.Apellido, _textBoxCliente[1].Text)
                            .Value(c => c.Nid, _textBoxCliente[2].Text)
                            .Value(u => u.Correo, _textBoxCliente[3].Text)
                            .Value(u => u.Telefono, _textBoxCliente[4].Text)
                            .Value(u => u.Fecha, DateTime.Now.ToString("dd/MMM/yyy"))
                            .Insert();

                        var cliente = TClientes.ToList().Last();

                        break;
                    case "update":
                        TClientes.Where(u => u.ID.Equals(_idCliente))
                            .Set(u => u.Nid, _textBoxCliente[0].Text)
                            .Set(u => u.Nombre, _textBoxCliente[1].Text)
                            .Set(u => u.Apellido, _textBoxCliente[2].Text)
                            .Set(u => u.Correo, _textBoxCliente[3].Text)
                            .Set(u => u.Telefono, _textBoxCliente[4].Text)
                            .Update(); 
                        break;

                }
                CommitTransaction();
                restablecer();
            }
            catch(Exception ex)
            {
                RollbackTransaction();
                MessageBox.Show(ex.Message);
            }
        }
        public async Task SearchClienteAsync(string campo)
        {
            List<TClientes> query;
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = await TClientes.ToListAsync();
            }
            else
            {
                query = await TClientes.Where(c => c.Nid.StartsWith(campo) || c.Nombre.StartsWith(campo) || c.Apellido.StartsWith(campo)).ToListAsync();
            }
            _dataGridView1.DataSource = query.Skip(inicio).Take(_reg_por_pagina).ToList();
            _dataGridView1.Columns[0].Visible = false;
            _dataGridView1.Columns[7].Visible = false;
            _dataGridView1.Columns[8].Visible = false;
            _dataGridView1.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            _dataGridView1.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            _dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            _dataGridView1.Columns[7].DefaultCellStyle.BackColor = Color.WhiteSmoke;
        }
        private int _idCliente = 0;
        public void GetCliente()
        {
            _accion = "update";
            _idCliente = Convert.ToInt16(_dataGridView1.CurrentRow.Cells[0].Value);
            _textBoxCliente[0].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[1].Value);
            _textBoxCliente[1].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[2].Value);
            _textBoxCliente[2].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[3].Value);
            _textBoxCliente[3].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[4].Value);
            _textBoxCliente[4].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[6].Value);
            //_textBoxCliente[5].Text = Convert.ToString(_dataGridView1.CurrentRow.Cells[5].Value);
        }
        public void restablecer()
        {
            _accion = "insert";
            _num_pagina = 1;
            _textBoxCliente[0].Text = "";
            _textBoxCliente[1].Text = "";
            _textBoxCliente[2].Text = "";
            _textBoxCliente[3].Text = "";
            _textBoxCliente[4].Text = "";
            _LabelCliente[0].Text = "Nid";
            _LabelCliente[0].ForeColor = Color.Black;
            _LabelCliente[1].Text = "Nombre";
            _LabelCliente[1].ForeColor = Color.Black;
            _LabelCliente[2].Text = "Apellido";
            _LabelCliente[2].ForeColor = Color.Black;
            _LabelCliente[3].Text = "Correo";
            _LabelCliente[3].ForeColor = Color.Black;
            _LabelCliente[4].Text = "Telefono";
            _LabelCliente[4].ForeColor = Color.Black;
            _ = SearchClienteAsync("");
        }
    }
}
