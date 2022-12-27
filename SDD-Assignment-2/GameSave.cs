﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    public partial class Game
    {
        static readonly string GAMESV_FILENAME = "SDD_City.dat";
        static readonly int INVALID_BUILDING = 5;

        public Game(bool loadFromFile = false)
        {
            // For Documentation/Implementation ..
            // Building1 and building2 is set to ' ' when new game is created

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
            }
        }

        int  coins { get; set; }
        int building1 { get; set; }
        int building2 { get; set; }
        int[] BuildingsPlacementInMap { get; set; }

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
