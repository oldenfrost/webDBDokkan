﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
    /*IdCliente	Nombre	Apellidos	Correo	Clave	Reestablecer	FechaRegistro*/
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }
        public bool Reestablecer { get; set; }
 
    }
}
