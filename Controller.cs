using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//це проміжний клас між інтерфейсом і классами, що пов'язані з бд, у клієнт-серверному застосунку я перероблю його під роутер
namespace Randomizer2._0
{
        class Controller
        {private int user_ID;
            private Connection con;
           
            public Controller()
            {
            
            user_ID = -1;
                con = new Connection();
           
            //con.Database.Initialize(false);
        }
            public bool loginUser(string log, string pass)
            {
              
            foreach (User user in con.Users)
                {
                if ((user.login).TrimEnd().Equals(log.TrimEnd()) && user.password.TrimEnd().Equals(pass.TrimEnd())) {
                    user_ID = user.Id; return true;
                    
                }
                }
                return false;
            }

        public void logout() { user_ID = -1; }

            public ArrayList getRequests()
            {
                ArrayList list = new ArrayList();

                foreach (Request req in con.Requests)
                {
                    if (req.user_id == user_ID)
                    {

                        list.Add("Nums: " + "(" + req.start + ") - (" + req.finish + "); Date: " + req.date + " ;");
                    }
                }
                return list;
            }

           public Stack<string> randomize(string start,string end)
        {
            int s;
            int e;
            Int32.TryParse(start, out s);
            Int32.TryParse(end, out e);
            RandomNums rn=new RandomNums(s,e);
            return rn.doRandom();
        }

            public bool tryIncertReq(string start, string end)
            {
            int s;
            int e;
            if (Int32.TryParse(start, out s) && Int32.TryParse(end, out e)) {
                if (e >= s)
                {
                    Request req = new Request();
                    req.start = s;
                    req.finish = e;
                    req.user_id = user_ID;
                    req.date = DateTime.Now.ToShortDateString();
                   con.Requests.Add(req);
                     con.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            }
        }
    }


