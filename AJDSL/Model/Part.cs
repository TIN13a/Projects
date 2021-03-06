﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJDSL {
    class Part : IEquatable<Part> {
        int id;
        List<Part> parents = new List<Part>();
        List<Part> childs = new List<Part>();
        string partNumber;
        double mass;
        double weight;
        double length;
        double width;
        double height;
        string description;

        public Part() {
            this.id = -1;
        }

        /// <summary>
        /// Construct a new part object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="partNr"></param>
        public Part(int id, string partNr) {
            this.id = id;
            this.PartNumber = partNr;
        }

        //Geter and Setter
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
        public double Mass {
            get { return this.mass; }
            set { this.mass = value; }
        }
        public double Weight {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public double Length {
            get { return this.length; }
            set { this.length = value; }
        }
        public double Width {
            get { return this.width; }
            set { this.width = value; }
        }
        public double Height {
            get { return this.height; }
            set { this.height = value; }
        }
        public string Description {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Add part as parent.
        /// </summary>
        /// <param name="part"></param>
        public void addParent(Part part) {
            if (parents.IndexOf(part) == -1) {
                parents.Add(part);
            }
        }

        /// <summary>
        /// Add part as child.
        /// </summary>
        /// <param name="part"></param>
        public void addChild(Part part) {
            if (childs.IndexOf(part) == -1) {
                childs.Add(part);
            }
        }

        /// <summary>
        /// Remove part from parents.
        /// </summary>
        /// <param name="part"></param>
        public void removeParent(Part part) {
            if (parents.IndexOf(part) != -1) {
                parents.Remove(part);
            }
        }

        /// <summary>
        /// Remove part from childs.
        /// </summary>
        /// <param name="part"></param>
        public void removeChild(Part part) {
            if (childs.IndexOf(part) != -1) {
                childs.Remove(part);
            }
        }


        public override string ToString() {
            return this.partNumber;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode() {
            return this.id;
        }
        public bool Equals(Part other) {
            if (other == null) return false;
            return (this.id.Equals(other.Id));
        }
    }
}
