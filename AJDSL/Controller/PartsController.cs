using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AJDSL {
    class PartsController {
        private PartsModel myModel = new PartsModel("(local)", "Parts");
        private List<Part> _parts = new List<Part>();

        public List<Part> getParts() {
            return this._parts;
        }


        public string printPart(string partNumber) {
            string partValues = "";
            Part part = new Part(-1, "");
            part = myModel.getPart(partNumber);
            partValues += part.Id.ToString() + "\n";
            partValues += part.PartNumber.ToString() + "\n";
            partValues += part.Mass.ToString() + "\n";
            partValues += part.Weight.ToString() + "\n";
            partValues += part.Length.ToString() + "\n";
            partValues += part.Width.ToString() + "\n";
            partValues += part.Height.ToString() + "\n";
            //partValues += part.Description.ToString() + "\n";
            return partValues;
        }

        /// <summary>
        /// Loads existing Data and send it to form
        /// </summary>
        public List<Part> loadParts() {
            //Load Form Data
            for (int i = 0; i < 5; i++) {
                _parts.Add(new Part(i, "Test" + i));
            }

            //Add some info to part 0
            _parts[0].Description = "Heihoblublub";

            _parts[0].addChild(_parts[1]);
            _parts[0].addChild(_parts[2]);

            _parts[4].addChild(_parts[2]);

            _parts[1].addParent(_parts[0]);
            _parts[2].addParent(_parts[0]);
            _parts[2].addParent(_parts[4]);

            List<Part> rootParts = new List<Part>();

            for (int i = 0; i < _parts.Count; i++) {
                Part part = _parts[i];

                if (part.Parents.Count == 0) {
                    rootParts.Add(part);
                }
            }

            //unset list
            _parts = rootParts;

            return _parts;
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

        public bool savePart(Part part) {
            return myModel.updatePart(part);
        }

        public float convertStringToFloat(string stringNumber) {
            float floatNumber;
            floatNumber = float.Parse(stringNumber, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            return floatNumber;
        }

        public void showMessageInfo(string content, string title) {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void showMessageWarning(string content, string title) {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void showMessageError(string content, string title) {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
