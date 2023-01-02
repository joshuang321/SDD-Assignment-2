using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    public partial class Game
    {
        const string buildingStr = "*RICO ";
        readonly static string[] buildingStrArr = { "Road", "Residential", "Industry", "Commercial", "Park" };

        public void StartGame()
        {
            bool first = building1 == INVALID_BUILDING;
            // Game logic goes here ..
            while(true)
            {
                if (first)
                    SelectBuildings();
                else if (numPlaced == 400 ||
                    coins == 0)
                {
                    FinishGame();
                    break;
                }

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

                if (buildingChoice == 3)
                {
                    SaveGame();
                    break;
                }

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

\                BuildingsPlacementInMap[row * 20 + column] = buildingChoice;
                coins--;
                numPlaced++;

                // Update the number of coins accordingly ..
                updateCoins(buildingChoice, row, column);

                // Set the first flag is false to signify a new round
                if (first)
                    first = false;
                SelectBuildings();
            }
        }

        void updateCoins(int buildingChoice, int row, int column)
        {
            if (buildingChoice == INDUSTRY ||
                buildingChoice == COMMERCIAL)
            {
                if (row != 19 && BuildingsPlacementInMap[(row + 1) * 20 + column] == RESIDENTIAL)
                    coins++;

                if (row != 0 && BuildingsPlacementInMap[(row - 1) * 20 + column] == RESIDENTIAL)
                    coins++;

                if (column != 19 && BuildingsPlacementInMap[row * 20 + column + 1] == RESIDENTIAL)
                    coins++;

                if (column != 0 && BuildingsPlacementInMap[row * 20 + column - 1] == RESIDENTIAL)
                    coins++;
            }
        }

        int GetCurrentPoints()
        {
            int points = 0;
            int index;
            int roadCount;
            int nIndustry = 0;

            for (int i = 0; i < 20; i++)
            {
                roadCount = 0;

                for (int j = 0; j < 20; j++)
                {
                    index = i * 20 + j;

                    if (BuildingsPlacementInMap[index] == ROAD)
                    {
                        roadCount++;
                    }
                    else
                    {
                        if (roadCount != 0)
                        {
                            points = roadCount * roadCount;
                            roadCount = 0;
                        }

                        switch (BuildingsPlacementInMap[index])
                        {
                            case RESIDENTIAL:
                                int respoints = 0;
                                if (i != 0)
                                {
                                    if (BuildingsPlacementInMap[index - 20] == RESIDENTIAL ||
                                        BuildingsPlacementInMap[index - 20] == COMMERCIAL)
                                        respoints++;
                                    else if (BuildingsPlacementInMap[index - 20] == PARK)
                                        respoints += 2;
                                    else if (BuildingsPlacementInMap[index - 20] == INDUSTRY)
                                    {
                                        points++;
                                        break;
                                    }
                                }
                                if (i != 19)
                                {
                                    if (BuildingsPlacementInMap[index + 20] == RESIDENTIAL ||
                                        BuildingsPlacementInMap[index + 20] == COMMERCIAL)
                                        respoints++;
                                    else if (BuildingsPlacementInMap[index + 20] == PARK)
                                        respoints += 2;
                                    else if (BuildingsPlacementInMap[index + 20] == INDUSTRY)
                                    {
                                        points++;
                                        break;
                                    }
                                }
                                if (j != 0)
                                {
                                    if (BuildingsPlacementInMap[index - 1] == RESIDENTIAL ||
                                        BuildingsPlacementInMap[index - 1] == COMMERCIAL)
                                        respoints++;
                                    else if (BuildingsPlacementInMap[index - 1] == PARK)
                                        respoints += 2;
                                    else if (BuildingsPlacementInMap[index - 1] == INDUSTRY)
                                    {
                                        points++;
                                        break;
                                    }
                                }
                                if (j != 19)
                                {
                                    if (BuildingsPlacementInMap[index + 1] == RESIDENTIAL ||
                                        BuildingsPlacementInMap[index + 1] == COMMERCIAL)
                                        respoints++;
                                    else if (BuildingsPlacementInMap[index + 1] == PARK)
                                        respoints += 2;
                                    else if (BuildingsPlacementInMap[index + 1] == INDUSTRY)
                                    {
                                        points++;
                                        break;
                                    }
                                }
                                break;

                            case INDUSTRY:
                                nIndustry++;
                                break;

                            case COMMERCIAL:
                                if (i != 0 && BuildingsPlacementInMap[index - 20] == COMMERCIAL)
                                    points++;
                                if (i != 19 && BuildingsPlacementInMap[index + 20] == COMMERCIAL)
                                    points++;
                                if (j != 0 && BuildingsPlacementInMap[index - 1] == COMMERCIAL)
                                    points++;
                                if (j != 19 && BuildingsPlacementInMap[index + 1] == COMMERCIAL)
                                    points++;
                                break;

                            case PARK:
                                if (i != 0 && BuildingsPlacementInMap[index - 20] == PARK)
                                    points++;
                                if (i != 19 && BuildingsPlacementInMap[index + 20] == PARK)
                                    points++;
                                if (j != 0 && BuildingsPlacementInMap[index - 1] == PARK)
                                    points++;
                                if (j != 19 && BuildingsPlacementInMap[index + 1] == PARK)
                                    points++;
                                break;
                        }
                    }
                }
            }
            points += nIndustry * nIndustry;
            return points;
        }

        void FinishGame()
        {  
            Console.WriteLine($"Game Over! You have scored {GetCurrentPoints()} points!");
        }

        void SelectBuildings()
        {
            Random random = new Random();
            building1 = random.Next(0, 4);

            do
            {
                building2 = random.Next(0, 4);
            } while (building1 == building2);
        }

        void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Coins: " + coins + "   Points: " + GetCurrentPoints());

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