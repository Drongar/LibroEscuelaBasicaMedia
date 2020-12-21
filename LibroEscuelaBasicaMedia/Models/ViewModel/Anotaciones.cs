using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class Anotaciones
    {
        public int idTipo { get; set; }
        public int idAlumno { get; set; }
        public string descripcion { get; set; }


            public Anotaciones() { }
    }
}