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

        const int ROAD = 0;                 //can just put all these under enum.   public enum Buildings { ... } 
        const int RESIDENTIAL = 1;
        const int INDUSTRY = 2;
        const int COMMERCIAL = 3;
        const int PARK = 4;
        const int INVALID_BUILDING = 5;

        int coins { get; set; }                         //for storing the number of coins
        int building1 { get; set; }                     //for storing the first building placeable 
        int building2 { get; set; }                     //for storing the second building placeable
        int highscore { get; set; } = 0;                //for storing the highscore
        public int[] BuildingsPlacementInMap { get; set; }     //placement of the buildings within the map. 

        // Store the number of buildings placed
        int numPlaced { get; set; }

        public Game(bool loadFromFile = false)
        {
            // For Documentation/Implementation ..
            
            BuildingsPlacementInMap = new int[400];

            if (loadFromFile)
            {
                // For Documentation/Implementation ..
                // Check if file exists first before trying to load from file ..
                Console.WriteLine("Loading game....");
                using (StreamReader reader = File.OpenText(GAMESV_FILENAME))   //initiate StreamReader to start reading contents from the file. 
                {
                    string data = reader.ReadToEnd();                          //read every single information from the file. 
                    Console.WriteLine(data.Length); 
                    if (data.Contains(';'))
                    {
                        string[] dataFilter = data.Split(";");                     //string is stored as a 'Semi-colon' delimited file according to SaveGame() method.....
                        coins = int.Parse(dataFilter[0]);                           //dataFilter[0] returns the number of coins. 
                        building1 = int.Parse(dataFilter[1]);                       //dataFilter[1] returns the first building that the user can place
                        building2 = int.Parse(dataFilter[2]);                       //dataFilter[2] returns the second building that the user can place 
                        numPlaced = int.Parse(dataFilter[3]);                       //dataFilter[3] returns the number of buildings placed                        
                        for (int i = 0; i < BuildingsPlacementInMap.Length; i++)
                        {
                            Console.WriteLine("Index to go into: " + i + " From file: " + dataFilter[4][i]);
                            BuildingsPlacementInMap[i] = Convert.ToInt32(dataFilter[4][i].ToString());
                            Console.WriteLine("After shifting: " + BuildingsPlacementInMap[i]);
                        }

                        //highscore = int.Parse(dataFilter[5]);

                        Console.WriteLine("=====================================================");

                        foreach (int i in BuildingsPlacementInMap)
                        {
                            Console.WriteLine("Verify item: " + i);
                        }
                        //Loading of data complete at this point. Transfer the data into the board. 
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear(); 
                        Console.WriteLine("Error: You have completed the game previously, or there is no data in the game file. Please start a new game (Press the 'Enter' key to continue)");
                        if (Console.ReadKey().Key.Equals(ConsoleKey.Enter))
                        {
                            Console.Clear();
                        }
                    }
                    reader.Close(); 
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

                //To implement: Get the highscore of the user if the game data file exists.
            }
            //Object not created at this point.
        }

        void SaveGame()
        {
            // For Documentation/Implementation ..
            using (StreamWriter sw =  new StreamWriter(GAMESV_FILENAME))
            {
                sw.Write(coins);  //0 
                sw.Write(';');
                sw.Write(building1);  //1
                sw.Write(';');
                sw.Write(building2);  //2
                sw.Write(';');                          //Note: added missing delimiter
                sw.Write(numPlaced);   //3 
                sw.Write(';'); 

                foreach (int building in BuildingsPlacementInMap)
                    sw.Write(building);  //4

                sw.Write(';');
                //To implement: Save the user's highscore. 


                //sw.Write(   the user's highscore   ) 

                sw.Close(); 
            }
            Console.Clear();
        }

        public static bool FileExists()
        {
            // For Documentation/Implementation ..
            // Note: Check if the file with name GAMESV_FILENAME exists in current Directory and return true
            // if exists, false otherwise ..

            return File.Exists(GAMESV_FILENAME);
        }
    }
}
