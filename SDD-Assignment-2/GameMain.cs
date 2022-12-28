using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    public partial class Game
    {
        readonly static string buildingStr = "*RICO ";

        readonly static string[] buildingStrArr = { "Road", "Residential", "Industry", "Commercial", "Park" };

        public void StartGame()
        {
            bool first = building1 == INVALID_BUILDING;
            // Game logic goes here ..
            while(true)
            {
                if (first)
                    SelectBuildings();

                PrintMenu();

                Console.WriteLine("[1] Building: " + buildingStrArr[building1]);
                Console.WriteLine("[2] Building: " + buildingStrArr[building2]);
                Console.WriteLine("[3] Save Game");
                Console.Write("Your option? ");

                int buildingChoice = 0;

                while (true)
                {
                    buildingChoice = int.Parse(Console.ReadLine());

                    if (buildingChoice < 1 ||
                        buildingChoice > 3)
                        Console.WriteLine("Invalid option! Try Again!");
                    else
                        break;
                }

                // To do:
                // Handle buidngChoice equals 3; Save Game, by calling SaveGame class Method and exiting game


                // Get the correctly selected building and put in in buildingChoice
                buildingChoice = buildingChoice == 1 ? building1 : building2;

                int row = 0, column = 0;
                Console.Write("Row and Column (E.g: 1 20)? ");
                
                while (true)
                {
                    string[] split = Console.ReadLine().Split(' ');
                    row = int.Parse(split[0]);

                    if (row < 1 || row > 20)
                    {
                        Console.WriteLine("Invalid Row! Try Again!");
                        break;
                    }

                    column = int.Parse(split[1]);

                    if (column < 1 || column > 20)
                    {
                        Console.WriteLine("Invalid Column! Try Again!");
                        continue;
                    }

                    // Zero index row and column
                    row--; column--;

                    // Check that the position is empty
                    if (BuildingsPlacementInMap[row * 20 + column] != INVALID_BUILDING)
                    {
                        Console.WriteLine("Building has already been placed here! Try Again!");
                        continue;
                    }

                    // Check if the building is adjacent to another building if it's not first round
                    if (!first &&
                        (row == 0 || BuildingsPlacementInMap[(row - 1) * 20 + column] == INVALID_BUILDING) &&
                        (column == 0 || BuildingsPlacementInMap[row * 20 + column - 1] == INVALID_BUILDING) &&
                        (column == 19 || BuildingsPlacementInMap[row * 20 + column + 1] == INVALID_BUILDING) &&
                        (row == 19 || BuildingsPlacementInMap[(row + 1) * 20 + column] == INVALID_BUILDING))
                        Console.WriteLine("Building must be placed to an already adjacent building! Try Again!");
                    else
                        break;
                }

                // Place building from buildingChoice into placement map and deduct coins
                BuildingsPlacementInMap[row * 20 + column] = buildingChoice;
                coins--;

                // Update the number of coins accordingly ..
                updateCoins(buildingChoice);

                // Set the first flag is false to signify a new round
                if (first)
                    first = false;
                SelectBuildings();
            }
        }

        public void updateCoins(int buildingChoice)
        {
            // To do: Check if placed residential build
        }

        public void SelectBuildings()
        {
            Random random = new Random();
            building1 = random.Next(0, 4);

            do
            {
                building2 = random.Next(0, 4);
            } while (building1 == building2);
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Coins: " + coins);

            int k = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 81; j++)
                    Console.Write('=');

                Console.Write('\n');

                for (int j = 0; j < 20; j++)
                    Console.Write("| " + buildingStr[BuildingsPlacementInMap[k++]] + " ");

                Console.Write("|\n");
            }
            for (int i = 0; i < 81; i++)
                Console.Write('=');

            Console.Write('\n');
        }
    }
}