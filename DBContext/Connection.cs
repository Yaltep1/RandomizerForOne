
using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
namespace Randomizer2._0
{
//клас зв'язку із базою даних
    public class Connection : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Request> Requests { get; set; }

            public Connection() : base("Name=Connection")
            {
                Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<Connection>(new Initializer());
        }
     
    }
    }

