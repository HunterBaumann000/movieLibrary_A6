using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MovieLibrary_A5
{
    public class ShowFile
    {
        public List<Show> Shows { get; set; }
        public string filePath { get; set; }
        public void AddShow(Show show)
        {
            try
            {
                if (!File.Exists("shows.csv"))
                throw new FileNotFoundException();
            }
            catch(FileNotFoundException) { 
                System.Console.WriteLine("File was not found!");
                System.Console.WriteLine("Want to create the show.csv? y/n");
                string wantNewFile = Console.ReadLine();
                    
                //creates file for user if they want it
                if (wantNewFile.Equals("y")) {
                    filePath = "videos.csv";
                    StreamWriter sw = new StreamWriter(filePath);
                }
            }
            try
            {
                // first generate movie id
                show.showId = Shows.Max(s => s.showId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);

                sw.WriteLine($"ID: {show.showId}, Title: {show.showTitle}, Season{show.showSeason} Ep. {show.showEpisode}, Writers: {string.Join(", ", show.showWriters)}");

                sw.Close();
                
                // add show details to Lists
                Shows.Add(show);
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public ShowFile(string showFilePath)
        {
            filePath = showFilePath;
            Shows = new List<Show>();

            // read movie line
            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    // instance of Show
                    Show show = new Show();
                    string line = sr.ReadLine();

                    string[] showLine = line.Split(',');
                    show.showId = int.Parse(showLine[0]);
                    show.showTitle = showLine[1];
                    show.showSeason = int.Parse(showLine[2]);
                    show.showEpisode = int.Parse(showLine[3]);
                    show.showWriters = showLine[4].Split('|').ToList();
                    
                    Shows.Add(show);
                }
                // close file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool hasSameTitle(string showTitle)
        {
            if (Shows.ConvertAll(s => s.showTitle.ToLower()).Contains(showTitle.ToLower()))
            {
                Console.WriteLine("{Title} is a duplicate in the file", showTitle);
                return true;
            }
            return false;
        }
    }
}