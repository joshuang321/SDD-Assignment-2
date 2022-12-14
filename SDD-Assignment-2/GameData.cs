using System;
using System.Collections.Generic;
using System.Text;

namespace SDD_Assignment_2
{
    internal class GameData
    {
        public static readonly string FILE_PATH = "SDD_City.dat";

        GameData()
        {
            // To implement ..
        }

        GameData(int coins,
            char building1,
            char building2,
            char[,] buildingMap)
        {
            // To implement ..
        }

        public int  coins { get; set; }
        public char building1 { get; set; }
        public char building2 { get; set; }
        public char[,] BuidingsPlacementInMap { get; set; }

        public void SaveGame()
        {
            // To implement .. 
        }
        public static GameData LoadGame()
        {
            // To implement ..
        }
    }
}
