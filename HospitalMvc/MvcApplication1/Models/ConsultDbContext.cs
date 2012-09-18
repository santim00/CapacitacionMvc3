using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HospitalMVC.Models
{
    public class ConsultDbContext : DbContext
    {
        public DbSet<Consult> Consults { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
      
    }
}