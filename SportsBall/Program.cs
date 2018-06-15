using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace SportsBall
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            //var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            //var fileContents = ReadSoccerResults(fileName);
            //fileName = Path.Combine(directory.FullName, "players.json");
            //var players = DeserializePlayers(fileName);
            //var topTenPlayers = GetTopTenPlayers(players);
            //foreach (var player in topTenPlayers)
            //{
            //    List<NewsResult> newsResults = GetNewsForPlayer(string.Format("{0} {1}", player.FirstName, player.LastName));
            //    foreach (var result in newsResults)
            //    {
            //        Console.WriteLine(string.Format("Date: {0:f}, Headline: {1}, Summary: {2}\r\n", result.DatePublished, result.Headline, result.Summary));
            //        Console.ReadKey();
            //    }
            //}

            //fileName = Path.Combine(directory.FullName, "topten.json");
            //SerializePlayersToFile(topTenPlayers, fileName);
            //Console.WriteLine(GetGoogleHomePage());
            Console.WriteLine(GetNewsForPlayer("Diego Valeri"));
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            var SoccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');

                    DateTime gameDate;

                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = values[1];
                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }

                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }

                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }

                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if (double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PossessionPercent = possessionPercent;
                    }

                    SoccerResults.Add(gameResult);
                }
            }
            return SoccerResults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
            return players;
        }

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());
            int counter = 0;
            foreach (var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }

            return topTenPlayers;
        }

        public static void SerializePlayersToFile(List<Player> players, string fileName)

        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }

        public static string GetGoogleHomePage()
        {
            var webClient = new WebClient();
            byte[] googleHome = webClient.DownloadData("https://www.google.com");
            using (var stream = new MemoryStream(googleHome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        //public static List<NewsResult> GetNewsForPlayer(string playerName)
        public static string GetNewsForPlayer(string playerName)
        {
            //var results = new List<NewsResult>();
            var webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "0f2573c2204648789be5302eee10aa37");

            byte[] searchResults = webClient.DownloadData(string.Format(
                "https://api.cognitive.microsoft.com/bing/v7.0/news/search?q={0}&mkt=en-us", playerName));
            //var serializer = new JsonSerializer();

            //using (var jsonReader = new JsonTextReader(reader))
            using (var stream = new MemoryStream(searchResults))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
                //results = serializer.Deserialize<NewsSearch>(jsonReader).NewsResults;
            }

            //return results;
        }
    }
}

//            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "17b5242629a44fd1982cdcde31cc1a14");

/*https://api.cognitive.microsoft.com/api/v7/entities/c168339b-1dba-b3de-5a73-fc3110ede90f

https://api.cognitive.microsoft.com/bing/v7.0/news/search?q=

'Ocp-Apim-Subscription-Key': 'd075692d853c4387950f76a53e21cbaa'

deacf907f3344a08908224848d44bf3d

370c0d56b9837807aef6962ddba4493f

----

https://api.cognitive.microsoft.com/bing/v7.0/news

https://api.cognitive.microsoft.com/bing/v7.0/spellcheck

https://api.cognitive.microsoft.com/bing/v7.0/videos

https://api.cognitive.microsoft.com/bing/v7.0

Key 1: ee1806bcf76b4465b828f6d070ef8afd

Key 2: 1faa925e2e524f56aef350cf985f58f8

----
bingSearchAPI

8jhH8TwVCHdDiWxXYgC5KqyEmChYTKW0kkFngbVYnH8

Utu7oE4xxDzx44gHnZY4QMjDJwAXS3x56D7fS9m2q58

vMxn7HtSEMFKZPHMYO+ULN3YfePDenhDoPA22uULpyU

*/