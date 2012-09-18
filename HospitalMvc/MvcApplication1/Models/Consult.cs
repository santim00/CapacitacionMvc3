using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity;

namespace HospitalMVC.Models
{
    public class Consult : IValidatableObject
    {
        [Key]
        [DisplayName("Numero de consulta")]
        public int ConsultId { get; set; }
       
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre del paciente")]
        [DisplayName("Nombre del paciente")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un apellido del paciente")]
        [DisplayName("Apellido del paciente")]
        public String Apellido { get; set; }

        [DataType(DataType.Date)] 
        [Required(ErrorMessage = "Se necesita una fecha de consulta")]
        public DateTime Fecha { get; set; } 
        
        [StringLength(5)]
        [Required(ErrorMessage = "Se necesita una hora de consulta")]
        public String Hora { get; set; }
        

       
        public virtual Doctor Doctor { get; set; }

        [Required(ErrorMessage = "Se necesita agregar un precio a la consulta")]
        [Range(1, 500, ErrorMessage = "El precio debe estar entre $1 y $500")]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [DisplayName("Obra social")]
        public string ObraSocial { get; set; }


        /// <summary>
        /// This method is for validate fields of the consult model.
        /// </summary>
       public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            var fieldFecha = new [] {"Fecha"};  
     
         if (Fecha < DateTime.Now)
            {
                yield return new ValidationResult("La fecha de la consulta no puede ser antes de hoy.", fieldFecha);
            } 
            if (Fecha > DateTime.Now.AddYears(1))
            {
                yield return new ValidationResult("La fecha de la consulta no debe superar el año.", fieldFecha);
            }
           
           var fieldHora = new [] {"Hora"};
           String[] partesHora = Hora.Split(':');
           if (partesHora.Length != 2)
           {
               yield return new ValidationResult("el texto ingresado no tiene formato de hora. (Formato de 24hs- hh:mm)", fieldHora);
           }
           else 
           {
               int hora = Convert.ToInt32(partesHora.ElementAt(0));
               Console.WriteLine("hora: {0}", hora);
               int mins = Convert.ToInt32(partesHora.ElementAt(1));

               if (!((hora < 24 && hora >= 0) && (mins >= 0 && mins < 60)))
               {
                   yield return new ValidationResult("La hora de la consulta está mal cargada. (Formato de 24hs - hh:mm)", fieldHora);
               }
           } 
        }
    }

  
}