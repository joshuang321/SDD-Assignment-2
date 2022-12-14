using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    public partial class Game
    {
        static readonly string GAMESV_FILENAME = "SDD_City.dat";

        public Game(bool loadFromFile = false)
        {
            // For Documentation/Implementation ..
            // Note: Make sure that two randomly selected buildings are assigned to building1 & building2

            if (loadFromFile)
            {
                // For Documentation/Implementation ..
                // Check if file exists first before trying to load from file ..
            }
            else
            {

            }
        }

        int  coins { get; set; }
        char building1 { get; set; }
        char building2 { get; set; }
        char[,] BuidingsPlacementInMap { get; set; }

        public void SaveGame()
        {
            // For Documentation/Implementation ..
        }

        static bool CheckIfFileExists()
        {
            // For Documentation/Implementation ..
            // Note: Check if the file with name GAMESV_FILENAME exists in current Directory and return true
            // if exists, false otherwise .. 

            return false;
        }
    }
}
