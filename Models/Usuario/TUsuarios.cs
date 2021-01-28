using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Usuario
{
    public class TUsuarios
    {
        [PrimaryKey, Identity]
        public int IdUsuario { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Telefono { set; get; }
        public string Correo { set; get; }
        public string Usuario { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }
        public bool Is_active { set; get; }
        public bool State { set; get; }
    }
}
