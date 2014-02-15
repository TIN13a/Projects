﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteFile {
    class Program {
        //static string pathSeparator = Path.PathSeparator.ToString();
        static string pathSeparator = "/";
        static void Main(string[] args) {
            string path = getPath();
            string filename = getFilename();
            // 2014-02-15 TODO: verify that the dir separator is set at the end of path.
            string file = path + filename;
            string fileContent;
            fileContent = getFileContent(file);
            
            // file content doesn't return a string yet. It returns the address of the object file (or something like this). 
            //string fileLength = getFileLength(fileContent);
            //string wordCount = getWordCount(fileContent);
            //string phraseCount = getPhraseCount(fileContent);
        }

        // read file
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

        // get file length
        static int getFileLength(string fileContent) {
            int fileLength = 0;
            fileLength = fileContent.Length;
            return fileLength;
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
            Console.WriteLine("Leave empty to keep the default Path \"%homepath%" + pathSeparator + "documents" + pathSeparator + "\"");
            string path = Console.ReadLine();
            if (path.Equals("")) {
                path = "%homepath%" + pathSeparator + "documents" + pathSeparator;
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
