using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    public partial class Game
    {
        const string GAMESV_FILENAME = "SDD_City.dat";
        const int ROAD = 0;
        const int RESIDENTIAL = 1;
        const int INDUSTRY = 2;
        const int COMMERCIAL = 3;
        const int PARK = 4;
        const int INVALID_BUILDING = 5;

        public Game(bool loadFromFile = false)
        {
            // For Documentation/Implementation ..
            
            BuildingsPlacementInMap = new int[400];

            if (loadFromFile)
            {
                // For Documentation/Implementation ..
                // Check if file exists first before trying to load from file ..

            }
            else
            {
                for (int i = 0; i < 400; i++)
                    BuildingsPlacementInMap[i] = INVALID_BUILDING;

                building1 = INVALID_BUILDING;
                building2 = INVALID_BUILDING;

                coins = 16;
                numPlaced = 0;
            }
        }

        int  coins { get; set; }
        int building1 { get; set; }
        int building2 { get; set; }
        int[] BuildingsPlacementInMap { get; set; }

        // Store the number of buildings placed
        int numPlaced { get; set; }

        public void SaveGame()
        {
            // For Documentation/Implementation ..
        }

        public static bool FileExists()
        {
            // For Documentation/Implementation ..
            // Note: Check if the file with name GAMESV_FILENAME exists in current Directory and return true
            // if exists, false otherwise ..

            return false;
        }
    }
}
