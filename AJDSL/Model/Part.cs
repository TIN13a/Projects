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


        public int ID { get; set; }
        public List<Part> Parents { get; set; }
        public List<Part> Childs { get; set; }
        public string PartNumber { get; set; }
        public float Mass { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Description { get; set; }

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
