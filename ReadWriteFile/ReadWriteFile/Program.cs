using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteFile {
    class Program {
        static void Main(string[] args) {
            string path = getPath();
            string filename = getFilename();
            // verify that the dir separator is set at the end of path.
            string file = path + filename;
            string fileContent = getFileContent(file);
            if (fileContent.Equals("")) {

            }

        }

        // read file
        static string getFileContent(string file) {
            string fileContent = "";
            try {
                fileContent = File.ReadAllText(file);
            }
            catch (IOException ex) {
                Console.WriteLine("The following Error occured:\n" + ex);
            }
            Console.WriteLine("\n\n" + fileContent + "\n\n");
            return fileContent;
        }

        // get line count
        static int getLineCount(string fileContent) {
            int lineCount = 0;

            return lineCount;
        }

        // get word count
        static int getWordCount(string fileContent) {
            int wordCount = 0;

            return wordCount;
        }

        // get phrase count
        static int getPhraseCount(string fileContent) {
            int phraseCount = 0;

            return phraseCount;
        }

        // get Path
        static string getPath() {
            Console.WriteLine("Please specify the directory you want to work with.");
            Console.WriteLine("Leave empty to keep the default Path \"%homepath%/documents/\".");
            string path = Console.ReadLine();
            if (path.Equals("")) {
                path = "%homepath%documents";
            }
            return path;
        }

        // get Filename
        static string getFilename() {
            Console.WriteLine("Please specify the name of a file.");
            Console.WriteLine("Leave empty to keep the default Filename \"test.txt\".");
            string filename = Console.ReadLine();
            if (filename.Equals("")) {
                filename = "test.txt";
            }
            return filename;
        }
    }
}
