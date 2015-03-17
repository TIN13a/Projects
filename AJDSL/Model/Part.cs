using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJDSL {
    class Part {
        int id;
        List<Part> parents = new List<Part>();
        List<Part> childs = new List<Part>();
        string partNumber;
        float mass;
        float weight;
        float length;
        float width;
        float height;
        string description;

        public Part(int id, string partNr) {
            this.id = id;
            this.PartNumber = partNr;
        }


        public int Id { 
            get { return this.id; } 
            set { this.id = value; } 
        }
        public List<Part> Parents {
            get { return this.parents; }
            set { this.parents = value; }
        }
        public List<Part> Childs {
            get { return this.childs; }
            set { this.childs = value; }
        }
        public string PartNumber {
            get { return this.partNumber; }
            set { this.partNumber = value; }
        }
        public float Mass {
            get { return this.mass; }
            set { this.mass = value; }
        }
        public float Weight {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public float Length {
            get { return this.length; }
            set { this.length = value; }
        }
        public float Width {
            get { return this.width; }
            set { this.width = value; }
        }
        public float Height {
            get { return this.height; }
            set { this.height = value; }
        }
        public string Description {
            get { return this.description; }
            set { this.description = value; }
        }

        public List<Part> getParents() {
            return parents;
        }

        public List<Part> getChilds() {
            return childs;
        }

        public void addParent(Part part) {
            if (parents.IndexOf(part) == -1) {
                parents.Add(part);
            }
        }

        public void addChild(Part part) {
            if (childs.IndexOf(part) == -1) {
                childs.Add(part);
                System.Console.WriteLine(id.ToString());
            }
        }

        public void removeParent(Part part) {
            if (parents.IndexOf(part) != -1) {
                parents.Remove(part);
            }
        }

        public void removeChild(Part part) {
            if (childs.IndexOf(part) != -1) {
                childs.Remove(part);
            }
        }
    }
}
