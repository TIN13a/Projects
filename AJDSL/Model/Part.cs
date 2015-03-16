using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJDSL {
    class Part {
        int id;
        int[] parents;
        int[] childs;
        string partNumber;
        float mass;
        float weight;
        float length;
        float width;
        float height;
        string description;
        public int ID { get; set; }
        public string PartNumber { get; set; }
        public float Mass { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Description { get; set; }
    }
}
