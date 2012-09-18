using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{ 
    public class DoctorsController : Controller
    {
        private ConsultDbContext _db = new ConsultDbContext();

      

        public ViewResult IndexList()
        {
            return View(_db.Doctors.ToList());
        }

       
        public ViewResult Details(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);
            return View(doctor);
        }

       

        public ActionResult Create()
        {
            return View();
        } 

        

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Doctors.Add(doctor);
                _db.SaveChanges();
                return RedirectToAction("IndexList");  
            }

            return View(doctor);
        }
        
        
 
        public ActionResult Edit(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);
            return View(doctor);
        }

       
        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(doctor).State = EntityState.Modified;
                Doctor doc= _db.Doctors.Find(doctor.DoctorId);
                doc = doctor;
                _db.SaveChanges();
                return RedirectToAction("IndexList");
            }
            return View(doctor);
        }

       
 
        public ActionResult Delete(int id)
        {
            Doctor doctor = _db.Doctors.Find(id);
            return View(doctor);
        }

       

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Doctor doctor = _db.Doctors.Find(id);
            _db.Doctors.Remove(doctor);
            _db.SaveChanges();
            return RedirectToAction("IndexList");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}