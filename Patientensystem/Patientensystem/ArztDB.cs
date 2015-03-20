using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class ArztDB
    {
        // Arzt Datenbank instanzieren
        private static ArztDB instance;

        // Liste anlegen
        internal IList<PData> pDatas { get; set; }

        // Liste abfüllen
        private ArztDB()
        {
            pDatas = new List<PData>();
        }

        // Arzt DB Check
        public static ArztDB getInstance()
        {
            if (instance == null) 
            {
                instance = new ArztDB();
            }
            return instance;
        }
    }
}
