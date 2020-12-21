using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibroEscuelaBasicaMedia.Models.ViewModel
{
    public class Apoderado
    {

    
    public int iduserApoderado { get; set; }
    public int rutApoderado { get; set; }
    public string nombreApoderado { get; set; }

    public string apellidoPaternoApoderado { get; set; }
    public string apellidoMaternoApoderado { get; set; }

     public List<Alumno> Alumnol { get; set; }


        public Apoderado() 
        { 

        }
    }
}