using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class PatientWriter : IWriteController
    {

        private PatientDB dataBase = PatientDB.getInstance();

        //In Patienten Datenbank schreiben
        public bool writePData(PData pData)
        {
            dataBase.pDatas.Add(pData);
            return true;
        }
    }
}
