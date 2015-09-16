using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_DataWarehouse.Model {
    class TransformHelper {
        public static double EUR = 1.08;
        // ... 

        /**
         * Make a shwallow copy of original
         */
        public static Sales CreateCopyOfSales(Sales original) {
            Sales copy = new Sales();

            copy.sum        = original.sum;

            copy.Branches = new Branches();
            copy.Branches.name   = original.Branches.name;

            copy.Categories = new Categories();

            copy.Countries = new Countries();
            copy.Countries.name = original.Countries.name;

            copy.Day = new SA_DataWarehouse.Model.Day();
            copy.Day.name = original.Day.name;

            copy.Month = new Month();
            copy.Month.name = original.Month.name;

            copy.Year = new Year();
            copy.Year.name = original.Year.name;

            return copy;
        }
    }
}
