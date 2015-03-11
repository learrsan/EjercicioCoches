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
        private VehiculosEntities db = new VehiculosEntities();


        // GET: Home
        public ActionResult Index()
        {
            var db = new VehiculosEntities();
            return View(db.Vehiculo.ToList());

        }

        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(model);
                foreach (var idvehiculo in model.IdVehiculo)
                {
                    var c = db.Conductor.Find(idvehiculo);
                    model.Conductor.Add(c);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        }

    }
     

