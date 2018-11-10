using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Lab.OAuthWeb.API.DataAccess
{
    // This class inherits from “IdentityDbContext” class, you can think about this class as special version of the traditional “DbContext” Class,
    // it will provide all of the Entity Framework code-first mapping and DbSet properties needed to manage the identity tables in SQL Server
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext() : base("DefaultConnection")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }
    }
}