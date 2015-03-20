using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patientensystem
{
    interface IWriteController
    {
        bool writePData(PData pData);
    }
}
