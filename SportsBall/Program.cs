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
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadSoccerResults(fileName);
        }

        public static string ReadFile(string fileName)
        {
          using(var reader = new StreamReader(fileName))
          {
            return reader.ReadToEnd();
          }
        }
      public static list<string[]> ReadSoccerResults(string fileName)
      {
        var SoccerResults = new list<string[]>();
        using(var reader = new StreamReader(fileName))
        {
          string line = "";
          reader.ReadLine();
          while((line = reader.ReadLine()) != null);
          {
            var gameResult = new GameResult();
            string[] values = line.Split(',');
            DateTime.gameDate;
            if(DateTime.TryParse(values[0], out gameDate)){
              gameResult.GameDate = gameDate;
            };
            SoccerResults.Add(values);
          }
        }
        return SoccerResults;
      }
    }

}
