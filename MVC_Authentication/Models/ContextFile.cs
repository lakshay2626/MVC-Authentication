using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Authentication.Models
{
    public class ContextFile : DbContext
    {
        public DbSet<LoginUser> loginUsers { get; set; }
    }
}