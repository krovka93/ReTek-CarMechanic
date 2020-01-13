using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTek_CarMechanical.Helpers
{
    class BussinessLayer
    {

        private static BussinessLayer instance = null;
        private static readonly object padlock = new object();

        BussinessLayer()
        {
        }

        public static BussinessLayer Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BussinessLayer();
                    }
                    return instance;
                }
            }
        }

        public string Test()
        {
            return "Tesztszöveg a BussinessLayer-en keresztül";
        }
    }
}

