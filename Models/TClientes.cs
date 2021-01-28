﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TClientes
    {
        [PrimaryKey, Identity]
        public int ID { set; get;}
        public string Nid { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Correo { set; get; }
        public string Telefono { set; get; }
        public string Fecha { set; get; }

    }
}
