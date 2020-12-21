using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class Alumno
    {
        public int idAlumno { get; set; }
        public int rutAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public string apellidoPaternoAlumno { get; set; }
        public string apellidoMaternoAlumno { get; set; }
        public int idApoderado { get; set; }
        public int idcurso { get; set; }
        public List<Anotaciones> Anotacionesl { get; set; }

        public Alumno() { }
    }
}