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
        public ActionResult Detalles
        
            
            public ActionResult Alta()
        {
            return View(new Vehiculo());
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alta(Vehiculo model)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        
        
        }
        
        }

    
     

