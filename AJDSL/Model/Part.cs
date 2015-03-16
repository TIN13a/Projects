using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJDSL {
    class Part {
        int id;
        List<int> parents = new List<int>();
        List<int> childs = new List<int>();
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
        public List<int> Parents { get; set; }
        public List<int> Childs { get; set; }
        public string PartNumber { get; set; }
        public float Mass { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Description { get; set; }
    }
}
