using System;
using System.Collections.Generic ;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.IO; 
using System.Text;
using System.Globalization;
using Microsoft.VisualBasic.FileIO;
using System.Data.Common;
/*
namespace Game
{

    //This class will be responsible for game logic handling

        class GameSessionData //This class will be responsible 
        {
            public int Coins { get; set; }
            public List<char> BuildingsPlaceable { get; set; } 
            public char[,] BuidingsPlacementInMap { get; set; }
        }

        public static readonly string FILE_PATH = "D:\\NgeeAnnCityGame\\NgeeAnnCityGameData.txt"; 

        public static void OpenSavedGame()
        {
            int points = 0, coins = 0, residential = 0, industry = 0, commercial = 0, park = 0, road = 0;
            bool isFirstMove = false;
            string mapAsCVVString = string.Empty;
            using (StreamReader sr = new StreamReader(Game.Functionality.FILE_PATH))
            {
                string s = sr.ReadToEnd();
                foreach (string st in s.Split("\n"))
                {
                    if (st.StartsWith("Points"))
                    {
                        points = Convert.ToInt32(st.Split(":")[1]);
                    }
                    if (st.StartsWith("Coins"))
                    {
                        coins = Convert.ToInt32(st.Split(":")[1]); 
                    }
                    if (st.StartsWith("IsFirstMove"))
                    {
                        isFirstMove = Convert.ToBoolean(st.Split(":")[1]); 
                    }
                    if (st.StartsWith("Residential"))
                    {
                        residential = Convert.ToInt32(st.Split(":")[1]);
                    }
                    if (st.StartsWith("Industry"))
                    {
                        industry = Convert.ToInt32(st.Split(":")[1]);
                    } 
                    if (st.StartsWith("Commercial"))
                    {
                        commercial = Convert.ToInt32(st.Split(":")[1]); 
                    }
                    if (st.StartsWith("Park"))
                    {
                        park = Convert.ToInt32(st.Split(":")[1]); 
                    }
                    if (st.StartsWith("Road"))
                    {
                        road = Convert.ToInt32(st.Split(":")[1]); 
                    }
                    if (st.Contains(","))
                    {
                        mapAsCVVString = st.Split(":")[1]; 
                    }
                }
            } //end of stream reader
            char[,] transfer = new char[20, 20];
            int j = 0;
            int i = 0; 
            while (i < mapAsCVVString.Split(",").Length)
            {
                transfer[i, j] = Convert.ToChar(mapAsCVVString.Split(",")[i]);
                i++; 
                if (j % 20 == 0)
                {
                    j++;
                    i = 0; 
                }
            }
            GameSessionData gameSessionData = new GameSessionData
            {
                Points = points,
                Coins = coins,
                IsFirstMove = isFirstMove,
                BuildingsPlaceable = new Func<List<char>>(() =>
                {
                    List<char> buildingList = new List<char> { }; 
                    int i = 0;
                    do
                    {
                        buildingList.Add('R'); 
                    } while (i <= residential);
                    return buildingList; 
                })(),
                BuidingsPlacementInMap = transfer
            }; 
        }
    }
}
*/

namespace SDD_Assignment_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
               DisplayMainMenu();
                Console.Write("Please enter your option: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else if (choice == 1)
                {
                    // For Documentation/Implementation ..
                    // Start New Game
                    // Note: Use new Game() to create Game object, and call StartGame() to start
                    Game game = new Game();
                    game.StartGame();
                }
                else if (choice == 2)
                {
                    // For Documentation/Implementation ..
                    // Open Saved Game
                    // Note: Check for if the file exists using CheckIfFileExists(), and then use new Game(loadFromFile=true) to
                    // create Game object, and call StartGame() to start

                }
                else if (choice == 3)
                {
                    // For Documentation/Implementation ..
                    // View Highscore

                }
            }
        }

        public static void DisplayMainMenu()
        {
            Console.Clear();

            Console.WriteLine("=======================GAME MENU========================");
            Console.WriteLine("[0] Exit the Game");
            Console.WriteLine("[1] Start a New Game");
            Console.WriteLine("[2] Open Saved Game");
            Console.WriteLine("[3] View Highscore");
        }
    }
}
