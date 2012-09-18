using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalMVC.Models
{
    public class Doctor
    {
        [Key]      
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un número de matricula del doctor")]
        [DisplayName("Numero de matricula")]
        public int Matricula { get; set; }

   
        [DisplayName("Nombre del doctor")]
        public String Nombre { get; set; }

    
        [DisplayName("Apellido del doctor")]
        public String Apellido { get; set; }

  
        public string Especialidad { get; set; }

        public virtual List<Consult> Consultas { get; set; }

               
    }
}