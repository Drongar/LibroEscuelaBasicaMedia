using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class Usuario
    {

        public int idUser { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int idRol { get; set; }

        public List<Apoderado> Apoderadol { get; set; }

        public Usuario() { }
    }
}