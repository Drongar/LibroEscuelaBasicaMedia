using LibroEscuelaBasicaMedia.Models;
using LibroEscuelaBasicaMedia.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibroEscuelaBasicaMedia.Controllers
{
    public class ProfesorController : Controller
    {
        private LibroDBEntities db = new LibroDBEntities();
        // GET: Profesor
        public ActionResult Index()
        {
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


        public ActionResult Create(ProfesorViewModel model)
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


                    ProfesorDB oProfesorDB = new ProfesorDB();

                    oProfesorDB.rutProfesor = model.rutProfesor;
                    oProfesorDB.nombreProfesor = model.nombre;
                    oProfesorDB.apellidoPaterno = model.apellidoPaterno;
                    oProfesorDB.apellidoMaterno = model.apellidoMaterno;
                    oProfesorDB.idCurso = model.idcurso;

                    oProfesorDB.idUser = oUsuarioDB.idUser;

                    db.ProfesorDB.Add(oProfesorDB);



                    db.SaveChanges();

                    ViewBag.idcurso = new SelectList(db.CursosDB, "idCurso", "cursos", model.idcurso).ToList();
                    ViewBag.idRol = new SelectList(db.RolDB, "idRol", "nombreRol", model.idRol).ToList();

                }




                ViewBag.Message = "Registro insertado";
                return View();

            }
            catch (Exception ex)
            {
                return View();
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

                ProfesorDB profesor = new ProfesorDB();
                UsuarioDB usuario = new UsuarioDB();
                usuario = db.UsuarioDB.Where(z => z.correo == correo && z.contraseña == Pass && z.idRol == 2).FirstOrDefault();
                profesor = db.ProfesorDB.Where(x => x.idUser == usuario.idUser).FirstOrDefault();
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}