﻿using System;
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

        /// <summary>
        /// Loads existing Data and send it to form
        /// </summary>
        public List<Part> loadParts() {
            //Load Form Data
            for(int i = 0; i < 5; i++){
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

            return this.setRootNodes();
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


        public List<Part> setRootNodes() {
            return setRootNodes(this._parts);
        }

        public List<Part> setRootNodes(List<Part> parts) {

            List<Part> rootParts = new List<Part>();

            for (int i = 0; i < _parts.Count; i++) {
                Part part = _parts[i];

                if (part.Parents.Count == 0) {
                    rootParts.Add(part);
                }
            }

            this._parts = rootParts;

            return this._parts;
        }
    }
}
