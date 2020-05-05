using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class LoginRecepcaoDbContext : DbContext
    {
        public DbSet<LoginRecepcao> loginR { get; set; }
    }
}