using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class PatientReader : IReadController
    {

        private PatientDB dataBase = PatientDB.getInstance();

        // von Patienten Datenbank lesen
        public IList<PData> readPData()
        {
            return dataBase.pDatas;
        }
    }
}
