using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HospitalMVC.Models
{
    public class ConsultInitializer : CreateDatabaseIfNotExists<ConsultDbContext>
    {
        protected override void Seed(ConsultDbContext context)
        {
            base.Seed(context);
            InitializeDatabase(context);

            var doctores = new List<Doctor> {
                new Doctor{
                Matricula = 55432,
                Nombre = "Jorge",
                Apellido = "Hané",
                Especialidad="Nutrición"
               },
                new Doctor{
                Matricula = 55428,
                Nombre = "Ricardo",
                Apellido = "Mastropierro",
                Especialidad="Dermatología"
               }, 
                new Doctor{
                Matricula = 55465,
                Nombre = "Rogelio",
                Apellido = "Funes Mori",
                Especialidad="Ginecología"
               },
                
               new Doctor{
                Matricula = 55411,
                Nombre = "Dario",
                Apellido = "Perez Salerno",
                Especialidad="Pediatría"
               },
                 new Doctor{
                Matricula =55413,
                Nombre = "Nestor Daniel",
                Apellido = "Manfuert",
                Especialidad="Traumatología"
               },
                 new Doctor{
                Matricula =55414,
                Nombre = "Oscar",
                Apellido = "Desiate",
                Especialidad="Traumatología"
               },
                new Doctor{
                Matricula =55417,
                Nombre = "Ignacio",
                Apellido = "Socoliski",
                Especialidad="Pediatría"
               },
                new Doctor{
                Matricula =55489,
                Nombre = "Ricardo",
                Apellido = "Fuentealba",
                Especialidad="Neurologia"
               },

               new Doctor{
                Matricula =55405,
                Nombre = "Jorge ",
                Apellido = "Del Potro",
                Especialidad="Gastroenterología"
               },


            };
            doctores.ForEach(d => context.Doctors.Add(d));
            context.SaveChanges();

          
          
            var consultas = new List<Consult> {  
  
                 new Consult{
                Nombre = " Celeste",
                Apellido = "Cid",
                Fecha = DateTime.Parse("15/10/2012"),
                Hora="18:20",
                Doctor = doctores.Single( s => s.Matricula == 55465),   
                ObraSocial = "OSDE",
                Precio = 200
                },  

                new Consult{
                Nombre = "Santiago",
                Apellido = "Murgolo",
                Fecha = DateTime.Parse("12/10/2012"),
                Hora= "10:40",
                Doctor =  doctores.Single( s =>(s.Nombre == "Ricardo" && s.Apellido == "Mastropierro") ),  
                ObraSocial = "Swiss Medical Group",
                Precio = 80
                }, 

                new Consult{
                Nombre = "Sergio",
                Apellido = "López",
                Fecha = DateTime.Parse("03/10/2012"),
                Hora="19:00",
                Doctor =  doctores.Single( s => s.Matricula == 55432), 
                ObraSocial = "O.S.E.C.A.C",
                Precio = 250
                }, 

                new Consult{
                Nombre = "Jose",
                Apellido = "Ortuzan",
                Fecha = DateTime.Parse("01/10/2012"),
                Hora="17:40",
                Doctor =  doctores.Single( s => s.Matricula == 55417), 
                ObraSocial = "O.S.E.C.A.C",
                Precio = 150
                }, 

                new Consult{
                Nombre = "Jose",
                Apellido = "Ortuzan",
                Fecha = DateTime.Parse("12/10/2012"),
                Hora="18:20",
                Doctor =  doctores.Single( s => s.Matricula == 55417),
                ObraSocial = "O.S.E.C.A.C",
                Precio = 150
                }, 

                new Consult{
                Nombre = "Pedro",
                Apellido = "Roman",
                Fecha = DateTime.Parse("12/10/2012"),
                Hora="09:00",
                Doctor =  doctores.Single( s => s.Matricula == 55413), 
                ObraSocial = "no tiene",
                Precio = 100
                }, 

                 new Consult{
                Nombre = "Sofia",
                Apellido = "Rojas",
                Fecha = DateTime.Parse("05/10/2012"),
                Hora="09:30",
                Doctor =  doctores.Single( s => s.Matricula == 55413), 
                ObraSocial = "OSDE",
                Precio = 100
                }, 
                
                new Consult{
                Nombre = "Laura",
                Apellido = "Scwhitz",
                Fecha = DateTime.Parse("03/10/2012"),
                Hora="10:30",
                Doctor =  doctores.Single( s => s.Matricula == 55465), 
                ObraSocial = "Medifé",
                Precio = 150
                }, 

                new Consult{
                Nombre = "Emilia",
                Apellido = "Arnatou",
                Fecha = DateTime.Parse("03/10/2012"),
                Hora="19:20",
                Doctor =  doctores.Single( s => s.Matricula == 55432), 
                ObraSocial = "no tiene",
                Precio = 150
                } 
    

             };
           
            consultas.ForEach(d => context.Consults.Add(d));
        
          
            context.SaveChanges();
            
           
        }
    }
}