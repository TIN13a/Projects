using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ReadWriteFile {
    class Program {
        //static string pathSeparator = Path.PathSeparator.ToString();
        static string PathSeparator = getPathSeparator();
        static void Main(string[] args) {
            string file = getFile();
            //string path = getPath();
            //string filename = getFilename();
            // 2014-02-15 TODO: verify that the dir separator is set at the end of path.
            //string file = path + filename;
            string fileContent;
            fileContent = getFileContent(file);
            
            // file content doesn't return a string yet. It returns the memory address of the object "file" (or something like this).
            // 2014-03-15 TODO: exception handling, if one of the three methods below returns e.g. -1 display an appropriate message.
            int fileLength = getFileLength(fileContent);
            int wordCount = getWordCount(fileContent);
            int phraseCount = getPhraseCount(fileContent);

            Console.WriteLine("File Length:\t" + fileLength + "\nWord Count:\t" + wordCount + "\nPhrase Count:\t" + phraseCount + "\n");
            Console.ReadKey();
        }

        static string getFileContent(string file) {
            string fileContent = "";
            try {
                fileContent = File.ReadAllText(file);
            }
            catch (FileNotFoundException) {
                Console.WriteLine("The file " + file + " was not found.");
            }
            catch (IOException ex) {
                Console.WriteLine("The following Error occured:\n" + ex);
            }
            Console.WriteLine("\n\n" + fileContent + "\n\n");
            Console.ReadKey();
            return fileContent;
        }

        static int getFileLength(string fileContent) {
            int fileLength = fileContent.Length;
            return fileLength;
        }

        static int getWordCount(string fileContent) {
            MatchCollection regexCounter = Regex.Matches(fileContent, @"(\w+)");
            int wordCount = regexCounter.Count;
            return wordCount;
        }

        static int getPhraseCount(string fileContent) {
            MatchCollection regexCounter = Regex.Matches(fileContent, @"[.!?]+");
            int phraseCount = regexCounter.Count;
            return phraseCount;
        }

        static string getFile() {
            Console.WriteLine("Please specify the file and path you want to work with.");
            string file = Console.ReadLine();
            while (!checkFile(file)) {
                Console.WriteLine("The file " + file + " doesn't exist. Enter the path and file again.");
                file = Console.ReadLine();
            }
            return file;
        }

        static bool checkFile(string file) {
            try {
                //File.Exists(file);
                File.OpenRead(file);
                Console.WriteLine("File: " + file + " exists.");
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        //static string getPath() {
        //    Console.WriteLine("Please specify the directory you want to work with (%homepath%" + PathSeparator + "documents" + PathSeparator + ").");
        //    string path = Console.ReadLine();
        //    if (path.Equals("")) {
        //        //path = "%homepath%" + PathSeparator + "documents" + PathSeparator;
        //        path = "";
        //    }
        //    return path;
        //}

        static string getPathSeparator() {
            string pathSeparator;
            if (Regex.IsMatch(Environment.OSVersion.ToString(), @"(?i:Windows)")) {
                pathSeparator = "\\";
            }
            else {
                pathSeparator = "/";
            }
            return pathSeparator;
        }
        
        //static string getFilename() {
        //    Console.WriteLine("Please specify the name of a file (test.txt).");
        //    string filename = Console.ReadLine();
        //    if (filename.Equals("")) {
        //        filename = "test.txt";
        //    }
        //    return filename;
        //}
    }
}
