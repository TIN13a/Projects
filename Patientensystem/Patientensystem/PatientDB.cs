using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class PatientDB
    {
        private static PatientDB instance;

        internal IList<PData> pDatas { get; set; }

        private PatientDB()
        {
            pDatas = new List<PData>();
        }

        // Patienten Datenbank Check
        public static PatientDB getInstance()
        {
            if (instance == null) {
                instance = new PatientDB();
            }
            return instance;
        }
    }
}
