using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class LoginAdmDbContext : DbContext
    {
        public DbSet<AdmLogin> loginAdmin { get; set; }
    }
}