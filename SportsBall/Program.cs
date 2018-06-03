using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SportsBall
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var files = directory.GetFiles("*.txt");
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}