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

                Console.WriteLine("Coins: " + coins);
                PrintMenu();

                Console.WriteLine("[1] Building: " + buildingStrArr[building1]);
                Console.WriteLine("[2] Building: " + buildingStrArr[building2]);
                Console.Write("Your option? ");


                while(true)
                {
                    int buildingChoice = int.Parse(Console.ReadLine());

                    if (buildingChoice == 1 ||
                        buildingChoice == 2)
                        Console.WriteLine("Invalid option! Try Again!");
                }

                int row = 0, column = 0;
                Console.Write("Row and Column (1-20)? ");
                
                while (true)
                {
                    string[] split = Console.ReadLine().Split(' ');
                    row = int.Parse(split[0]);

                    if (row < 1 || row > 20)
                        Console.WriteLine("Invalid Row! Try Again!");

                    column = int.Parse(split[1]);

                    if (column < 1 || column > 20)
                        Console.WriteLine("Invalid Column! Try Again!");

                    row--; column--;

                    if (BuildingsPlacementInMap[row*20 + column] == INVALID_BUILDING)
                        Console.WriteLine("Building has already been placed here! Try Again!");

                    if (!first &&
                        BuildingsPlacementInMap[(row - 1) * 20 + column] == INVALID_BUILDING &&
                        BuildingsPlacementInMap[row * 20 + column - 1] == INVALID_BUILDING &&
                        BuildingsPlacementInMap[row * 20 + column + 1] == INVALID_BUILDING &&
                        BuildingsPlacementInMap[(row + 1) + column] == INVALID_BUILDING)
                        Console.WriteLine("Building must be placed to an already adjacent building! Try Again!");
                }

                SelectBuildings();
            }
        }

        public void SelectBuildings()
        {
            Random random = new Random();
            building1 = buildingStr[random.Next(0, 4)];

            do
            {
                building2 = buildingStr[random.Next(0, 4)];
            } while (building1 == building2);
        }

        public void PrintMenu()
        {
            for (int i = 0; i < 81; i++) 
                Console.Write('=');

            int k = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 81; j++)
                    Console.Write('=');

                Console.Write('\n');

                for (int j = 0; j < 20; j++)
                    Console.Write("| " + buildingStr[BuidingsPlacementInMap[k++]] + " ");

                Console.Write("|\n");
            }
            for (int i = 0; i < 81; i++)
                Console.Write('=');

            Console.Write('\n');
        }
    }
}