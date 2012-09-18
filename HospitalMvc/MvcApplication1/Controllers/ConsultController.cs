using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalMVC.Controllers
{
    public class ConsultController : Controller
    {

        private ConsultDbContext _db = new ConsultDbContext();

  
        /// <summary>
        /// Allows generate a List of SelectListItems and put it in the ViewBag for utilization in the view.
        /// </summary>
   private void GenerateDoctorSelect()
        {
            List<SelectListItem> itemsDoc = new List<SelectListItem>();
            List<Doctor> listDoc = _db.Doctors.ToList();
            itemsDoc = listDoc.Select(d => new SelectListItem() { Text = d.Especialidad + ": " + d.Apellido + "," + d.Nombre, Value = "" + d.Matricula }).ToList();

            ViewBag.doctorList = itemsDoc;
        } 
        
        
        private void GenerateEspecialitySelect()
        {
            List<SelectListItem> itemsEsp = new List<SelectListItem>();

            var lisEsp = from d in _db.Doctors
                         select d.Especialidad;
            var listDoc = new List<string>();
            listDoc.AddRange(lisEsp.Distinct());

            itemsEsp = listDoc.Select(d => new SelectListItem() { Text = d, Value = d }).ToList();

            ViewBag.areaList = itemsEsp.Distinct();
        } 




     

        public ActionResult IndexList(String doctorList, String areaList )
        {
           
            GenerateDoctorSelect();
            GenerateEspecialitySelect();
        
            List<Consult> consultas = _db.Consults.OrderBy(d => d.Fecha).ToList();

  
            if (!String.IsNullOrEmpty(doctorList) && String.IsNullOrEmpty(areaList))
            {
                consultas = consultas.Where(s => s.Doctor.Matricula == Convert.ToInt32(doctorList)).ToList();
            }
            if (String.IsNullOrEmpty(doctorList) && !String.IsNullOrEmpty(areaList))
            {
                consultas = consultas.Where(s => s.Doctor.Especialidad.Equals(areaList)).ToList();
            }
                     
            
            return View(consultas);
        }

      
        public ActionResult Details(int id)
        {
            Consult consAux = _db.Consults.Find(id);
            consAux.Doctor = _db.Doctors.Find(consAux.DoctorId);
            return View(consAux);
        }

       

        public ActionResult Create()
        {
            GenerateDoctorSelect();

            return View();
        }

       

    
        [HttpPost]
        public ActionResult Create( Consult consulta, String doctorList)
        { 
            int matriculaDoc = Convert.ToInt32(doctorList);
            if (ModelState.IsValid)
            {
                 Doctor doc = _db.Doctors.Single(d => d.Matricula == matriculaDoc);
                 consulta.Doctor = doc;
                 _db.Consults.Add(consulta);
                _db.SaveChanges();
                return RedirectToAction("IndexList");
            }

            return View(consulta);
           
        }


        public ActionResult Delete(int id)
        {
            Consult consAux = _db.Consults.Find(id);
            return View(consAux);
        }



        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Consult consAux = _db.Consults.Find(id);
                _db.Consults.Remove(consAux);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

 
       
      
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }

      
}
