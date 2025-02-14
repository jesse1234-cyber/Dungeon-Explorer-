using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string roomTitle;
        private string description;


        public Room()
        {
            List<string> roomInfo = GetNameAndDescription();
            roomTitle = roomInfo[0];
            description = roomInfo[1];
        }

        private List<string> GetNameAndDescription()
        {
            List<string> outputList = new List<string>();
            List<string> descriptions = new List<string>();
            List<string> titles = new List<string>();
            Random rnd = new Random();
            try
            {
                string line;
                StreamReader sr = new StreamReader("./dungeons/Descriptions.txt");
                line = sr.ReadLine();

                while(line != null)
                {
                    string[] temp = line.Split('~');
                    titles.Add(temp[0]);
                    descriptions.Add(temp[1]);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Caught: " + e);
            }


            int index = rnd.Next(titles.Count);

            outputList.Add(titles[index]);
            outputList.Add(descriptions[index]);

            return outputList;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}