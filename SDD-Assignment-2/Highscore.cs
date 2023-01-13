using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDD_Assignment_2
{
    internal class Highscore
    {
        const string HIGHSCRE_FILENAME = "highscore.dat";
        public string name { set; get; }
        public int highscore { get; set; }

        public Highscore(string name, int highscore)
        {
            this.name = name;
            this.highscore = highscore;
        }

        public static List<Highscore> ReadHighscore()
        {
            List<Highscore> highscoreList = new List<Highscore>();
            string[] tempReadArr = null;

            if (File.Exists(HIGHSCRE_FILENAME))
            {
                using (StreamReader sr = new StreamReader(HIGHSCRE_FILENAME))
                {
                    while ((tempReadArr = sr.ReadLine().Split(';')) != null)
                    {
                        highscoreList.Add(new Highscore(tempReadArr[0], int.Parse(tempReadArr[1])));
                    }
                }
            }

            return highscoreList;
        }


        public static void DumpHighscore(List<Highscore> highscores)
        {
            if (highscores.Count == 0)
                return;
            
            using (StreamWriter sw = new StreamWriter(HIGHSCRE_FILENAME))
            {
                sw.Write(highscores[0].name);
                sw.Write(';');
                sw.Write(highscores[0].highscore);
                for (int i = 1; i < highscores.Count; i++)
                {
                    sw.WriteLine();
                    sw.Write(highscores[i].name);
                    sw.Write(';');
                    sw.Write(highscores[i].highscore);
                }
            }
        }

    }
}
