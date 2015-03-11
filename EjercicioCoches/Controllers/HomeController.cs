using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjercicioCoches.Models;

namespace EjercicioCoches.Controllers
{
    public class HomeController : Controller
    {
       VehiculosEntities db = new VehiculosEntities();


        // GET: Home
        public ActionResult Index()
        {
            
            return View(db.Vehiculo);

        }

        public ActionResult Alta()
        {
            ViewBag.idConductores = new MultiSelectList(db.Conductor, "idConductor", "nombre");
            
            return View(new Vehiculo());
        }

        public ActionResult Detalles(int id)
        {
            var vehiculo = db.Vehiculo.Find(id);
            return View();
        }
        
            
            
       
        [HttpPost]
        

        public ActionResult Alta(Vehiculo model)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(model);
                foreach (var idConductor in model.idConductores)
                {
                    var o = db.Conductor.Find(idConductor);
                    model.Conductor.Add(o);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        public ActionResult Modificar(int id)
        {
            var v = db.Vehiculo.Find(id);
            ViewBag.idConductores = new MultiSelectList(db.Conductor, "idConductor", "nombre",
                v.Conductor);

            return View();
        }

        [HttpPost]
        public ActionResult Modificar(Vehiculo v)
        {
            if (ModelState.IsValid)
            {
                var va = db.Vehiculo.Find(v.id);
                va.marca = v.marca;
                va.modelo = v.modelo; 
                va.matricula = v.matricula;
            }

        }


    }
        
        }

    
     

