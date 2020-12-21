using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class ApodereadoViewModel
    {
        public int idUser { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public int idRol { get; set; }



        public int iduserApoderado { get; set; }
        public int rutApoderado { get; set; }
        public string nombreApoderado { get; set; }

        public string apellidoPaternoApoderado { get; set; }
        public string apellidoMaternoApoderado { get; set; }

        public int rutAlumno { get; set; }
        public string nombreAlumno { get; set; }
        public string apellidoPaternoAlumno { get; set; }
        public string apellidoMaternoAlumno { get; set; }

        public int idcurso { get; set; }


    }
}