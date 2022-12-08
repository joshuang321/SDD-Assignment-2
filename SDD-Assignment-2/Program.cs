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

namespace Game
{
    internal sealed class PlayerDatabase
    {
    }

    internal sealed class Player
    {
        public string Name 
        {
            get { return this.Name; }
            set
            {
                this.Name = value ?? (
                    value.Equals(string.Empty) 
                    ? value 
                    : new Func<string>(() => {
                        Dictionary<byte, char> charCodeList = new Dictionary<byte, char>
                        {
                            {1, 'a'},
                            {2, 'b'},
                            {3, 'c'},
                            {4, 'd'},
                            {5, 'e'},
                            {6, 'f'},
                            {7, 'g'},
                            {8, 'h'},
                            {9, 'i'},
                            {10, 'j'},
                            {11, 'k'},
                            {12, 'l'},
                            {13, 'm'},
                            {14, 'n'},
                            {15, 'o'},
                            {16, 'p'},
                            {17, 'q'},
                            {18, 'r'},
                            {19, 's'},
                            {20, 't'},
                            {21, 'u'},
                            {22, 'v'},
                            {23, 'w'},
                            {24, 'x'},
                            {25, 'y'},
                            {26, 'z'},
                            {27, 'A'},
                            {28, 'B'},
                            {29, 'C'},
                            {30, 'D'},
                            {31, 'E'},
                            {32, 'F'},
                            {33, 'G'},
                            {34, 'H'},
                            {35, 'I'},
                            {36, 'J'},
                            {37, 'K'},
                            {38, 'L'},
                            {39, 'M'},
                            {40, 'N'},
                            {41, 'O'},
                            {42, 'P'},
                            {43, 'Q'},
                            {44, 'R'},
                            {45, 'S'},
                            {46, 'T'},
                            {47, 'U'},
                            {48, 'V'},
                            {49, 'W'},
                            {50, 'X'},
                            {51, 'Y'},
                            {52, 'Z'},
                            {53, '0'},
                            {54, '1'},
                            {55, '2'},
                            {56, '3'},
                            {57, '4'},
                            {58, '5'},
                            {59, '6'},
                            {60, '7'},
                            {61, '8'},
                            {62, '9'}
                        };
                        byte value = (byte)Math.Abs(new Random().Next(62));
                        LinkedList<char> chars = new LinkedList<char> { };   //This linked list will be responsible for storing a list of characters. 
                        chars.AddFirst(charCodeList[
                            (byte) (value.Equals(0) 
                            ? value >= 53 
                                ? new Func<byte>(() => {
                                    byte minusHowMuch; 
                                    for (; ; )
                                    {
                                        minusHowMuch = (byte)Math.Abs(new Random().Next(61)); //how much do we need to move back
                                        if (minusHowMuch > 10) break; 
                                    }
                                    value -= minusHowMuch;
                                    return value; 
                                })()
                                : value 
                            : value + 1)]
                        );

                        return new string(chars.ToArray<char>()); 
                    })()
                ); 
            }
        }

        public int PlayerId
        {
            get { return this.PlayerId; }
            set
            {

            }
        }

        public long Highscore
        {
            get;
            set; 
        }

        private Player () {  } 

        public Player(string name, int playerId)
        {
            Name = name;
            PlayerId = playerId;
        }    
    }

    //This class will be responsible for game logic handling
    internal sealed class Functionality
    {
        internal sealed class GameSessionData //This class will be responsible 
        {
            public int Coins { get; set; } 
            public int Points { get; set; } 
            public bool IsFirstMove { get; set; } 
            public List<char> BuildingsPlaceable { get; set; } 
            public char[,] BuidingsPlacementInMap { get; set; }
        }

        private Functionality() { }

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

        public static void StartGame()
        {
            Dictionary<int, char> building = new Dictionary<int, char> //Dictionary to store building codes
            {
                {0, 'R'},
                {1, 'I'},
                {2, 'C'},
                {3, 'O'},
                {4, '*'}
            };
            Dictionary<char, byte> charCodeListReverse = new Dictionary<char, byte> //Dictionary to store character placement codes
            {
                {'A', 0},
                {'B', 1},
                {'C', 2},
                {'D', 3},
                {'E', 4},
                {'F', 5},
                {'G', 6},
                {'H', 7},
                {'I', 8},
                {'J', 9},
                {'K', 10},
                {'L', 11},
                {'M', 12},
                {'N', 13},
                {'O', 14},
                {'P', 15},
                {'Q', 16},
                {'R', 17},
                {'S', 18},
                {'T', 19}
            };
            GameSessionData gameSessionData = new GameSessionData
            {
                Coins = 16,
                Points = 0,
                IsFirstMove = true,
                BuildingsPlaceable = new Func<List<char>>(() =>
                {
                    List<char> list = new List<char> { };
                    for (int i = 0; i <= 20; i++)
                    {
                        list.Add('R');
                        list.Add('I');
                        list.Add('C');
                        list.Add('O');
                        list.Add('*');
                    }
                    return list;
                })(),
                BuidingsPlacementInMap = new char[20, 20]
            }; 
            while (true)
            {
                StringBuilder primary = new StringBuilder();
                StringBuilder secondary = new StringBuilder();
                StringBuilder separator = new StringBuilder();
                StringBuilder box = new StringBuilder();
                StringBuilder row = new StringBuilder();
                StringBuilder full = new StringBuilder();
                for (int i = 0; i < 3; i++)
                {
                    separator.Append("-");
                    box.Append(" ");
                }
                for (int i = 0; i < 20; i++)
                {   
                    //need to check for whether game session data's BuildingsPlacementInMap property is empty.
                    primary.Append(i == 0 ? "  +" : "+").Append(separator); 
                    secondary.Append(i == 0 ? "  |" : "|").Append(box);
                }
                primary.Append("+\n");
                secondary.Append("|\n");
                row.Append(primary).Append(secondary);
                for (int i = 0; i < 20; i++)
                {
                    full.Append(row);
                }
                full.Append(primary);
                char[,] map = gameSessionData.BuidingsPlacementInMap; //this is where all the building placement thing reside.
                //TODO: We will need to transfer all the data from the variable named 'map' into the map itself.... 


                Console.WriteLine(full.ToString());
                char building1 = building[Math.Abs(new Random().Next(5))]; 
                char building2 = building[Math.Abs(new Random().Next(5))]; 
                //Generate building
                Console.WriteLine("===========================================================");
                Console.WriteLine("[0] End game and return to the main menu");
                Console.WriteLine(String.Format("[1] Place a building named: {0}{1}", building1, building1=='R'?"(Residential)" : building1=='I'?"(Industry)" : building1=='C' ? "(Commercial)" : building1=='O'?"(Park)":"(Road)"));
                Console.WriteLine(String.Format("[2] Place a building named: {0}{1}", building2, building2== 'R' ? "(Residential)" : building2 == 'I' ? "(Industry)" : building2 == 'C' ? "(Commercial)" : building2 == 'O' ? "(Park)" : "(Road)"));
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine("===========================================================");
                try
                {
                    int choiceCorrect = Convert.ToInt32(choice); 
                    while (true)
                    {
                        if (choiceCorrect == 0)
                        {
                            //Exit to the main menu, but we will need to check if there is any building placed within the map...
                            char[,] buildingPlacementMap = gameSessionData.BuidingsPlacementInMap;                  //Get the building placement map thing 
                            StringBuilder commaDelimitedString = new StringBuilder();                               //Initialize a new string builder object to begin comma delimited file construction....
                            for (int i = 0; i < buildingPlacementMap.GetLength(0); i++)
                            {
                                for (int j = 0; j < buildingPlacementMap.GetLength(1); j++)
                                {
                                    commaDelimitedString.Append(buildingPlacementMap[i, j] + ","); 
                                }
                            }
                            string[] strings = commaDelimitedString.ToString().Split('\u002C');
                            foreach(string s in strings)
                            {
                                if (!s.Equals(string.Empty))     //If the string is not empty this means that there is unsaved game progress!
                                {
                                    Console.WriteLine("===========================================================");
                                    Console.WriteLine("Confirm exit? If you exit the game like this, all your game data will be lost!");
                                    Console.WriteLine("[Y] Yes, I would like to save my game data for use later.");
                                    Console.WriteLine("[N] No, I would not like to save my game data (Your progress...will be lost...FOREVER!)");
                                    Console.WriteLine("===========================================================");
                                    while (true)
                                    {
                                        Console.Write("Your choice? [Y/N]: ");
                                        string decision = Console.ReadLine();
                                        try
                                        {
                                            char decisionFinal = Convert.ToChar(decision);
                                            if (decisionFinal.Equals('Y'))
                                            {
                                                //Initiate stream writer....
                                                using (StreamWriter writer = new StreamWriter(Game.Functionality.FILE_PATH))
                                                {
                                                    writer.WriteLine("Points: " + gameSessionData.Points);
                                                    writer.WriteLine("Coins: " + gameSessionData.Coins);
                                                    writer.WriteLine("IsFirstMove: " + gameSessionData.IsFirstMove);
                                                    writer.WriteLine("======================");
                                                    writer.WriteLine("Residential: " + new Func<int>(() =>
                                                    {
                                                        int residentialBldgCount = 0;
                                                        List<char> buildingChars = gameSessionData.BuildingsPlaceable;
                                                        foreach (char buildingCodeName in buildingChars)
                                                        {
                                                            if (buildingCodeName.Equals('R')) residentialBldgCount++;
                                                        }
                                                        return residentialBldgCount;
                                                    })());
                                                    writer.WriteLine("Industry: " + new Func<int>(() =>
                                                    {
                                                        int industrialBldgCount = 0;
                                                        List<char> buildingChars = gameSessionData.BuildingsPlaceable;
                                                        foreach (char buildingCodeName in buildingChars)
                                                        {
                                                            if (buildingCodeName.Equals('I')) industrialBldgCount++;
                                                        }
                                                        return industrialBldgCount;
                                                    })());
                                                    writer.WriteLine("Commercial: " + new Func<int>(() =>
                                                    {
                                                        int commercialBldgCount = 0;
                                                        List<char> buildingChars = gameSessionData.BuildingsPlaceable;
                                                        foreach (char buildingCodeName in buildingChars)
                                                        {
                                                            if (buildingCodeName.Equals('C')) commercialBldgCount++;
                                                        }
                                                        return commercialBldgCount;
                                                    })());
                                                    writer.WriteLine("Park: " + new Func<int>(() =>
                                                    {
                                                        int parkCount = 0;
                                                        List<char> buildingChars = gameSessionData.BuildingsPlaceable;
                                                        foreach (char buildingCodeName in buildingChars)
                                                        {
                                                            if (buildingCodeName.Equals('O')) parkCount++;
                                                        }
                                                        return parkCount;
                                                    })());
                                                    writer.WriteLine("Road: " + new Func<int>(() =>
                                                    {
                                                        int roadCount = 0;
                                                        List<char> buildingChars = gameSessionData.BuildingsPlaceable;
                                                        foreach (char buildingCodeName in buildingChars)
                                                        {
                                                            if (buildingCodeName.Equals('*')) roadCount++;
                                                        }
                                                        return roadCount;
                                                    })());
                                                    //store the position of where
                                                    writer.WriteLine("=====================");
                                                    writer.WriteLine(commaDelimitedString); 
                                                }
                                                return;
                                            }
                                            else if (decisionFinal.Equals('N'))
                                            {
                                                Console.WriteLine("Returning to the main menu.....");
                                                return; //quit the function!
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid selection. Please select 'Y' or 'N'");
                                            }
                                        }
                                        catch (Exception ignored)
                                        {
                                            Console.WriteLine("Invalid selection. Please select 'Y' or 'N'");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("Returning to main menu......");
                        }
                        else if (choiceCorrect == 1)   //Option to place the first building.....
                        {
                            //Place generated building.....
                            if (gameSessionData.IsFirstMove)
                            {
                                gameSessionData.IsFirstMove = false;
                                while (true)
                                {
                                    Console.Write("Please enter the name of the square you would like to insert that building in (You can type any square for the first move): ");
                                    string position = Console.ReadLine();
                                    char[] positionAsCharArr = position.ToCharArray();
                                    if (((positionAsCharArr[0] >= 'A' && positionAsCharArr[0] <= 'T') || (positionAsCharArr[0] >= 'a' && positionAsCharArr[0] <= 't')) &&
                                        new Func<bool>(() =>
                                        {
                                            StringBuilder rowNumString = new StringBuilder();
                                            for (int i = 1; i < positionAsCharArr.Length; i++)
                                            {
                                                rowNumString.Append(positionAsCharArr[i]);
                                            }
                                            try
                                            {
                                                int rowNum = Convert.ToInt32(rowNumString.ToString());
                                                if (!(rowNum >= 1 && rowNum <= 20))
                                                {
                                                    return false;
                                                }
                                            }
                                            catch (Exception ignored)
                                            {
                                                return false;
                                            }
                                            return true;
                                        })())
                                    {
                                        gameSessionData.BuildingsPlaceable.Remove(building1);
                                        //char[row, col] convention.
                                        gameSessionData.BuidingsPlacementInMap
                                        [
                                            (new Func<int>(() =>
                                            {
                                                StringBuilder rowNumString = new StringBuilder();
                                                for (int i = 1; i < positionAsCharArr.Length; i++)
                                                {
                                                    rowNumString.Append(positionAsCharArr[i]);
                                                }
                                                return Convert.ToInt32(rowNumString.ToString());
                                            })()) - 1,
                                            //charCodeListReverse['T'] => 19 
                                            charCodeListReverse[positionAsCharArr[0]]
                                        ] = building1;
                                        //deduct points accordingly. 
                                        gameSessionData.Coins -= 1;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("Sorry, {0} is not a valid grid name!", position));
                                    }
                                }
                                break; 
                            }
                            else
                            {
                                char[,] currentMapCond = gameSessionData.BuidingsPlacementInMap;
                                List<int[]> buildingCoordinatesList = new List<int[]>();
                                for (int i = 0; i < currentMapCond.GetLength(0); i++)
                                {
                                    for (int j = 0; j < currentMapCond.GetLength(1); j++)
                                    {
                                        if (currentMapCond[i, j] != '\u0000')
                                        {
                                            buildingCoordinatesList.Add(new int[] { i, j });
                                        }
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Please enter the coordinates of the square that you would like your building to go to: ");
                                    string position = Console.ReadLine();
                                    char[] positionAsCharArr = position.ToCharArray();
                                    //This statement checks for the format of the building coordinates. 
                                    if (((positionAsCharArr[0] >= 'A' && positionAsCharArr[0] <= 'T') || (positionAsCharArr[0] >= 'a' && positionAsCharArr[0] <= 't')) &&
                                        new Func<bool>(() =>
                                        {
                                            StringBuilder rowNumString = new StringBuilder();
                                            for (int i = 1; i < positionAsCharArr.Length; i++)
                                            {
                                                rowNumString.Append(positionAsCharArr[i]);
                                            }
                                            try
                                            {
                                                int rowNum = Convert.ToInt32(rowNumString.ToString());
                                                if (!(rowNum >= 1 && rowNum <= 20))
                                                {
                                                    return false;
                                                }
                                            }
                                            catch (Exception ignored)
                                            {
                                                return false;
                                            }
                                            return true;
                                        })())
                                    {
                                        int[] newBuildingCoordinate; 
                                        //TODO: Now we will need to check for whether there is an adjacent building..


                                        //char[row, col] convention.
                                        gameSessionData.BuidingsPlacementInMap
                                        [
                                            (new Func<int>(() =>
                                            {
                                                StringBuilder rowNumString = new StringBuilder();
                                                for (int i = 1; i < positionAsCharArr.Length; i++)
                                                {
                                                    rowNumString.Append(positionAsCharArr[i]);
                                                }
                                                return Convert.ToInt32(rowNumString.ToString());
                                            })()) - 1,
                                            //charCodeListReverse['T'] => 19 
                                            charCodeListReverse[positionAsCharArr[0]]
                                        ] = building1;
                                        gameSessionData.Coins -= 1; 
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("Sorry, {0} is not a valid grid name!", position));
                                    }
                                }
                                break; 
                            }
                        }
                        else if (choiceCorrect == 2)
                        {
                            //TODO: Repeat what we have did for if(choiceCorrect == 1)
                            //Place generated building.....
                            if (gameSessionData.IsFirstMove)
                            {
                                gameSessionData.IsFirstMove = false;
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that is an invalid choice!");
                        }
                    } //while (true) end of prompt choice loop
                } 
                catch (Exception ignored)
                {
                    Console.WriteLine("Sorry, that is an invalid choice!");  
                }
            } //end of main game loop while(true) 
        }
    }

    internal sealed class Menu
    {
        private Menu() { }

        //This method will be responsible for printing out the main menu of the game for the user to interact....
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

namespace SDD_Assignment_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Game.Menu.DisplayMainMenu();
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
                    Game.Functionality.StartGame();
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
    }
}
