using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    namespace ConsoleApplication1 {
        class Program {

            static void Main(string[] args) {
                System.Console.WriteLine("Hello World\n");
                System.Threading.Thread.Sleep(1500);

                Console.WriteLine("Digit" + "\t=>\t" + "Square");
                for (int i = 50; i < 71; i++) {
                    Console.WriteLine(i + "\t=>\t" + calculate((byte) i)); // (byte) var => downcast to another type, doesn't work for strings
                }
                Console.ReadKey();
            }

            public static int calculate(byte argument) {
                return argument * argument;
            }
        }
    }
}
