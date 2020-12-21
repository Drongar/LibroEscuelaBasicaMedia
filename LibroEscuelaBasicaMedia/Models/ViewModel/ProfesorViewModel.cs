using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class ProfesorViewModel
    {
        public int idUser { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int idRol { get; set; }
        public int idProfesor { get; set; }
        public int rutProfesor { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int idcurso { get; set; }
    }
}