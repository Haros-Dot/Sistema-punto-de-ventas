using LinqToDB;
using Models.Conexion;
using Models.Usuario;
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
    public class LoginVM : Conexion
    {
        private List<TextBox> _textBox;
        private List<Label> _label;

        public LoginVM() { }
        public LoginVM(List<TextBox> textBox, List<Label> label)
        {
            _textBox = textBox;
            _label = label;
        }
        public object[] Login()
        {
            List<TUsuarios> listUsuarios = new List<TUsuarios>();
            if (_textBox[0].Text.Equals(""))
            {
                _label[0].Text = "Este campo es requerido";
                _label[0].ForeColor = Color.Red;
                _textBox[0].Focus();
            }
            else if (_textBox[1].Text.Equals(""))
            {
                _label[1].Text = "Este campo es requerido";
                _label[1].ForeColor = Color.Red;
                _textBox[1].Focus();
            }
            else
            {
                listUsuarios = TUsuarios.Where(u => u.Correo.Equals(_textBox[0].Text)).ToList();
                if (!listUsuarios.Count.Equals(0))
                {
                    if (listUsuarios[0].Password.Equals(_textBox[1].Text))
                    {
                        BeginTransactionAsync();
                        try
                        {
                            var hdd = Ordenador.Serial();
                            TUsuarios.Where(u => u.IdUsuario.Equals(listUsuarios[0].IdUsuario))
                                .Set(u => u.Is_active, true)
                                .Update();
                        }
                        catch (Exception ex)
                        {
                            RollbackTransaction();
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        _label[1].Text = "Contraseña Incorrecta";
                        _label[1].ForeColor = Color.Red;
                        _textBox[1].Focus();
                        listUsuarios.Clear();
                    }
                }
                else
                {
                    _label[0].Text = "El correo no esta registrado";
                    _label[0].ForeColor = Color.Red;
                    _textBox[0].Focus();
                    listUsuarios.Clear();
                }
            }
            object[] objects = { listUsuarios };
            return objects;
        }
    }
}
