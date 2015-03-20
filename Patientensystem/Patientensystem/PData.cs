using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patientensystem
{
    class PData
    {
        public PData(string befund)
        {
            this.befund = befund;
        }

        public string befund { get; set; }
    }
}
