using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class ArztReader : IReadController
    {
        // Arzt Datenbank instanzieren
        private ArztDB dataBase = ArztDB.getInstance();

        //Von Arzt Datenbank lesen
        public IList<PData> readPData()
        {
            return dataBase.pDatas;
        }
    }
}
