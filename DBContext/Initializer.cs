using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer2._0
{
    //ініціалізатор БД, спрацьовує тільки якщо бд ще не була створена+налаштування міграцій
    public class Initializer: CreateDatabaseIfNotExists<Connection>
    {protected override void Seed(Connection context)
    {
        {
            var Users = new List<User>
            {
                new User{login="1",password="1",},
                new User{login="admin",password="admin",}

            };
            Users.ForEach(t => context.Users.Add(t));
            context.SaveChanges();
            var Requests = new List<Request>
            {
                new Request{user_id=1,start=1,finish=1,date="1"},

            };
            Requests.ForEach(t => context.Requests.Add(t));
            context.SaveChanges();
        }


    }
    }
    
}
