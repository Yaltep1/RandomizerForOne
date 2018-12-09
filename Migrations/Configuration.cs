namespace Randomizer2._0.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
   
    internal sealed class Configuration : DbMigrationsConfiguration<Connection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Connection context) { 
       
        }
    }
    }

