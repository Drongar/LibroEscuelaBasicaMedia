using LibroEscuelaBasicaMedia.Models;
using LibroEscuelaBasicaMedia.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibroEscuelaBasicaMedia.Controllers
{
    public class ApoderadoController : Controller
    {
        private LibroDBEntities db = new LibroDBEntities();
        // GET: Apoderado
        //NO FUNCIONA
        public ActionResult Index()
        {
            ViewBag.idRol = new SelectList(db.RolDB, "idRol", "nombreRol");
            return View();
        }
        //No FUNCIONA+
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UsuarioDB model)
        {

            Usuario usuario = new Usuario();
            UsuarioDB user = db.UsuarioDB.Find(model.idUser);
            usuario.contraseña = user.contraseña;
            usuario.correo = user.correo;
            usuario.idRol = user.idRol;
        

            List<Apoderado> apoderados = new List<Apoderado>();

            foreach (var item in user.ApoderadoDB.Where(x => x.idUser == user.idUser).ToList())
            {
                Apoderado oapoderado = new Apoderado();
                oapoderado.iduserApoderado = item.idApoderado;
                oapoderado.nombreApoderado = item.nombreApoderado;
                oapoderado.rutApoderado = item.rutApoderado;
                oapoderado.apellidoPaternoApoderado = item.apellidoPaterno;
                oapoderado.apellidoMaternoApoderado = item.apellidoMaterno;
                
                apoderados.Add(oapoderado);
            };
            usuario.Apoderadol = apoderados;

            Apoderado apoderado = new Apoderado();
            ApoderadoDB apod = db.ApoderadoDB.FirstOrDefault();
            
            apoderado.iduserApoderado = apod.idApoderado;
            apoderado.nombreApoderado = apod.nombreApoderado;
            apoderado.rutApoderado = apod.rutApoderado;
            apoderado.apellidoPaternoApoderado = apod.apellidoPaterno;
            apoderado.apellidoMaternoApoderado = apod.apellidoMaterno;

            List<Alumno> alumno = new List<Alumno>();
            foreach (var item in apod.AlumnoDB.Where(x => x.idApoderado == apod.idApoderado).ToList())
            {
                Alumno oalumno = new Alumno();
                oalumno.idAlumno = item.idAlumno;
                oalumno.rutAlumno = item.rutAlumno;
                oalumno.nombreAlumno = item.nombreAlumno;
                oalumno.apellidoPaternoAlumno = item.apellidoPaterno;
                oalumno.apellidoMaternoAlumno = item.apellidoMaterno;


            }
            apoderado.Alumnol = alumno;


            ViewBag.idRol = new SelectList(db.RolDB, "idRol", "nombreRol", model.idRol).ToList();
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.idcurso = new SelectList(db.CursosDB, "idCurso", "cursos");
            ViewBag.idRol = new SelectList(db.RolDB, "idRol", "nombreRol");

            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public ActionResult Create(ApodereadoViewModel model)
        {
            try
            {
                using (LibroDBEntities db = new LibroDBEntities())
                {
                    UsuarioDB oUsuarioDB = new UsuarioDB();
                    oUsuarioDB.contraseña = model.contraseña;
                    oUsuarioDB.correo = model.correo;
                    oUsuarioDB.idRol = model.idRol;

                    db.UsuarioDB.Add(oUsuarioDB);
                    db.SaveChanges();


                    ApoderadoDB oApoderadoDB = new ApoderadoDB();
                    oApoderadoDB.rutApoderado = model.rutApoderado;
                    oApoderadoDB.nombreApoderado = model.nombreApoderado;
                    oApoderadoDB.apellidoPaterno = model.apellidoPaternoApoderado;
                    oApoderadoDB.apellidoMaterno = model.apellidoMaternoApoderado;
                    oApoderadoDB.idUser = oUsuarioDB.idUser;
                    db.ApoderadoDB.Add(oApoderadoDB);
                    db.SaveChanges();

                    AlumnoDB oAlumnoDB = new AlumnoDB();
                    oAlumnoDB.rutAlumno = model.rutAlumno;
                    oAlumnoDB.nombreAlumno = model.nombreAlumno;
                    oAlumnoDB.apellidoPaterno = model.apellidoPaternoAlumno;
                    oAlumnoDB.apellidoMaterno = model.apellidoMaternoAlumno;
                    oAlumnoDB.idCurso = model.idcurso;
                    oAlumnoDB.idApoderado = oApoderadoDB.idApoderado;
                    db.AlumnoDB.Add(oAlumnoDB);
                    db.SaveChanges();


                    ViewBag.idcurso = new SelectList(db.CursosDB, "idCurso", "cursos", model.idcurso).ToList();




                    ViewBag.idRol = new SelectList(db.RolDB, "idRol", "nombreRol", model.idRol).ToList();



                }


                ViewBag.Message = "Registro insertado";
                return View();
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(string correo, string Pass)

        {
            try
            {
                
                ApoderadoDB apoderado = new ApoderadoDB();
                UsuarioDB usuario = new UsuarioDB();
                usuario = db.UsuarioDB.Where(z => z.correo == correo && z.contraseña == Pass && z.idRol == 3).FirstOrDefault();
                apoderado = db.ApoderadoDB.Where(x => x.idUser == usuario.idUser).FirstOrDefault();
                return RedirectToAction("Index", "Apoderado", new { idUser = usuario.idUser });
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public ActionResult Index2()
        {
            List<Usuario> lst;
            {
                lst = (from d in db.UsuarioDB
                       join ap in db.ApoderadoDB on d.idUser equals ap.idUser
                       join al in db.AlumnoDB on ap.idApoderado equals al.idApoderado

                       select new Usuario
                       {
                           idUser = d.idUser,




                       }).ToList();
            }
            return View(lst);
        }


    }
}