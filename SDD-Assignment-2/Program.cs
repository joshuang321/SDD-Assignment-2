using System;
using System.Collections.Generic;
using System.Linq;

namespace SDD_Assignment_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game;

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
                    game = new Game();
                    Game.ClearFile();
                    game.StartGame();
                }
                else if (choice == 2)
                {
                    if (Game.FileExists())
                    {
                        game = new Game(true);
                        game.StartGame();
                    }
                    else
                    {
                        Console.Clear(); 
                        Console.WriteLine("Error: Data file is not found! Please try creating a new game! Press Enter key to continue");
                        if (Console.ReadKey().Key.Equals(ConsoleKey.Enter))
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (choice == 3)
                {
                    List<Highscore> highscoreList = Highscore.ReadHighscore();
                    Console.WriteLine("=======================HIGHSCORE========================");
                    for (int i=0; i<highscoreList.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {highscoreList[i].name}" + "\t\t\t" + $"{highscoreList[i].highscore}");
                    }
                }
            }
        }

        public static void DisplayMainMenu()
        {
            Console.WriteLine("=======================GAME MENU========================");
            Console.WriteLine("[0] Exit the Game");
            Console.WriteLine("[1] Start a New Game");
            Console.WriteLine("[2] Open Saved Game");
            Console.WriteLine("[3] View Highscore");
        }
    }
}
