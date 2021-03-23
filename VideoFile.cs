using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieLibrary_A5
{
    public class VideoFile
    {
        public string filePath { get; set; }
        public List<Video> Videos { get; set; }

        public void AddVideo(Video video)
        {
            try
            {
                if (!File.Exists("videos.csv"))
                throw new FileNotFoundException();
            }
            catch(FileNotFoundException) { 
                System.Console.WriteLine("File was not found!");
                System.Console.WriteLine("Want to create a file? y/n");
                string wantNewFile = Console.ReadLine();
                    
                //creates file for user if they want it
                if (wantNewFile.Equals("y")) {
                    filePath = "videos.csv";
                    StreamWriter sw = new StreamWriter(filePath, true);
                }
            }
            try
            {
                // iterate through each video obj until theres no more greater, then add one to ID
                video.videoId = Videos.Max(v => v.videoId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                
                sw.WriteLine($"Id: {video.videoId}, Title: {video.videoTitle}, Format: {video.videoFormat}, Length: {video.videoLength} minutes, VideoRegions: {string.Join(", ", video.videoRegions)}");
                sw.Close();
                
                // add video details to Lists
                Videos.Add(video);
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public VideoFile(string videoFilePath)
        {
            filePath = videoFilePath;
            Videos = new List<Video>();

            // read video line
            try
            {
                //creates streamreader
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                //loops until the end of stream
                while (!sr.EndOfStream)
                {
                    // instance of Video
                    Video video = new Video();
                    string line = sr.ReadLine();

                    string[] videoLine = line.Split(',');
                    video.videoId = int.Parse(videoLine[0]);
                    video.videoTitle = videoLine[1];
                    video.videoFormat = videoLine[2];
                    video.videoLength = int.Parse(videoLine[3]);
                    video.videoRegions = videoLine[4].Split('|').ToList();
                    
                    Console.WriteLine(videoLine);
                }
                // close file when done
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public bool hasSameTitle(string videoTitle)
        {
            //convert all video objects to lowercase, and if that instance contains the title, return true
            if (Videos.ConvertAll(v => v.videoTitle.ToLower()).Contains(videoTitle.ToLower()))
            {
                Console.WriteLine("{Title} is a duplicate in the file", videoTitle);
                return true;
            }
            return false;
        }
    }
}