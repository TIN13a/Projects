using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class ArztWriter : IWriteController
    {
        // Arzt Datenbank instanzieren
        private ArztDB dataBase = ArztDB.getInstance();

        // in Arzt Datenbank schreiben über PData
        public bool writePData(PData pData)
        {
            dataBase.pDatas.Add(pData);
            return true;
        }
    }
}
