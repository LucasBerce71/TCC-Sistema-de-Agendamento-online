using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TccNovoGrupo.Models
{
    public class LoginProfissionalDbContext : DbContext
    {
        public DbSet<LoginProfissional> loginP { get; set; }
    }
}