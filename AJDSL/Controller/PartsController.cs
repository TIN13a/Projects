using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJDSL {
    class PartsController {
        private List<Part> _parts = new List<Part>();

        /// <summary>
        /// Loads existing Data and send it to form
        /// </summary>
        public void loadForm() {
            //Load Form Data
            for(int i = 0; i < 5; i++){
                _parts.Add(new Part(i, "Test" + i));
            }

            _parts[0].Childs.Add(1);
            _parts[0].Childs.Add(2);

            _parts[1].Parents.Add(0);
            _parts[2].Parents.Add(0);

            foreach (Part part in _parts) {

                TreeNode node = new TreeNode(part.PartNumber);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>bool true if added, false if not</returns>
        public bool addPart() {

            

            return true;
        }

        public bool editPart() {
            return true;
        }
    }
}
