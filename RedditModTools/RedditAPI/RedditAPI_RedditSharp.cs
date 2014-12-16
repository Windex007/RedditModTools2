using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;

namespace RedditAPI
{
    public class RedditAPI_RedditSharp
    {
        Reddit rBaseSrv;
        bool isLoggedIn;


        public RedditAPI_RedditSharp()
        { 
            rBaseSrv = null;
            isLoggedIn = false;
        }

        public bool login(string username, string password) 
        {
            rBaseSrv = new Reddit(username, password);
            isLoggedIn = (rBaseSrv.User != null);
            return isLoggedIn;
        }
    }
}
