﻿using System;
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
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0)
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else if (choice == 1)
                {
                    //start game

                }
                else if (choice == 2)
                {
                    //open saved game

                }
                else if (choice == 3)
                {
                    //get the high score

                }
            }
        }

        public static void DisplayMainMenu()
        {
            Console.WriteLine("=======================GAME MENU========================");
            Console.WriteLine("[0] Exit the game");
            Console.WriteLine("[1] Start a new game");
            Console.WriteLine("[2] Open saved game");
            Console.WriteLine("[3] View highscore");
        }
    }
}
