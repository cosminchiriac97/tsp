using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ServiceReference;

namespace Library
{
    public class WcfClient
    {
        private static BiblioWcfClient client;
        public static BiblioWcfClient GetInstance()
        {
            if (client == null)
            {
                client = new BiblioWcfClient("BasicHttpBinding_IBiblioWcf");
            }

            return client;
        }
    }
}
