using LinqToDB;
using LinqToDB.Data;
using Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Conexion
{
    public class Conexion : DataConnection
    {
        public Conexion() : base("PDHN1") { }
        public ITable<TClientes> TClientes { get { return GetTable<TClientes>(); } }

        public ITable<TUsuarios> TUsuarios => GetTable<TUsuarios>();
     }
}
