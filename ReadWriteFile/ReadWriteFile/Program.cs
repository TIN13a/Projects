using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteFile {
    class Program {
        static void Main(string[] args) {
            string path = getPath();
            string filename = getFilename();

        }




        // get Path
        static string getPath() {
            Console.WriteLine("Please specify the directory you want to work with.");
            Console.WriteLine("Leave empty to keep the default Path \"%homepath%/documents\".");
            string path = Console.ReadLine();
            if (path.Equals("")) {
                path = "%homepath%documents";
            }
            return path;
        }

        // get Filename
        static string getFilename() {
            Console.WriteLine("Please specify the name of a file.");
            Console.WriteLine("Leave empty to keep the default Filename \"test.txt\".")
            string filename = Console.ReadLine();
            if (filename.Equals("")) {
                filename = "test.txt";
            }
            return filename;
        }
    }
}
