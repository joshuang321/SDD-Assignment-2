using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

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

        int coins { get; set; }                       
        int building1 { get; set; }                  
        int building2 { get; set; }                 
        int[] BuildingsPlacementInMap { get; set; }  

        int numPlaced { get; set; }

        public Game(bool loadFromFile = false)
        {
            
            BuildingsPlacementInMap = new int[400];

            if (loadFromFile)
            {
                using (StreamReader reader = File.OpenText(GAMESV_FILENAME))   
                {
                    string data = reader.ReadToEnd();                     
                    if (data.Contains(';'))
                    {
                        string[] dataFilter = data.Split(";");                  
                        coins = int.Parse(dataFilter[0]);                 
                        building1 = int.Parse(dataFilter[1]);
                        building2 = int.Parse(dataFilter[2]);
                        numPlaced = int.Parse(dataFilter[3]);          

                        for (int i = 0; i < BuildingsPlacementInMap.Length; i++)
                        {
                            BuildingsPlacementInMap[i] = Convert.ToInt32(dataFilter[4][i].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: You have completed the game previously, or there is no data in the game file. Please start a new game.");
                    }
                } 
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

        void SaveGame()
        {
            using (StreamWriter sw =  new StreamWriter(GAMESV_FILENAME))
            {
                sw.Write(coins);
                sw.Write(';');
                sw.Write(building1);
                sw.Write(';');
                sw.Write(building2);
                sw.Write(';');
                sw.Write(numPlaced);
                sw.Write(';'); 

                foreach (int building in BuildingsPlacementInMap)
                    sw.Write(building);

                sw.Write(';');

            }
        }

        public static bool FileExists()
        {
            return File.Exists(GAMESV_FILENAME);
        }
    }
}
