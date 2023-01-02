using System;

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
                    // For Documentation/Implementation ..
                    // Start New Game
                    // Note: Use new Game() to create Game object, and call StartGame() to start
                    game = new Game();
                    game.StartGame();
                }
                else if (choice == 2)
                {
                    // For Documentation/Implementation ..
                    // Open Saved Game
                    // Note: Check for if the file exists using CheckIfFileExists(), and then use new Game(loadFromFile=true) to
                    // create Game object, and call StartGame() to start
                    if (Game.FileExists())
                    {
                        game = new Game(true);
                        game.StartGame();
                    }
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
