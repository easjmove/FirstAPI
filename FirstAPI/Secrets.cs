using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI
{
    public class Secrets
    {
        public static string ConnectionsString = 
            "Server=tcp:firstapi.database.windows.net,1433;Initial Catalog=firstapi;" +
            "Persist Security Info=False;User ID=move;Password=numseGOJ1;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;" +
            "Connection Timeout=30;";
    }
}
