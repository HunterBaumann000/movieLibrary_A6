using System;
using System.IO;
using System.Collections.Generic;

namespace MovieLibrary_A5
{
    class Program
    {
        static void Main(string[] args)
        {
            //setting up file directories
            string movieFilePath = "movies.csv";
            string showFilePath = "shows.csv";
            string videoFilePath = "video.csv";

            //class with file-path parameter
            MovieFile movieFile = new MovieFile(movieFilePath);
            ShowFile showFile = new ShowFile(showFilePath);
            VideoFile videoFile = new VideoFile(videoFilePath);

            //menu class
            Menus menu = new Menus();

            //declaring userInput so the scanner menu input works
            string userInput = "";

            do
            {
                // displays main menu
                menu.DisplayMainMenu();
                // scanner
                userInput = Console.ReadLine();

                //nested if-statements for users input
                if (userInput == "1") 
                {
                    //displays which MediaType they want to add
                    menu.DisplayMediaTypeMenu();
                    userInput = Console.ReadLine();

                    if(userInput == "1") 
                    {
                        //movie menu
                        Menus.askUserForMovie(userInput);
                    } 
                    else if (userInput == "2") 
                    {
                        //show menu
                        Menus.askUserForShow(userInput);
                    }
                    else if(userInput == "3")
                    {
                        //video menu
                        Menus.askUserForVideo(userInput);
                    } 
                }
                else if (userInput == "2")
                {
                    //displays menu for reading the media from the file
                    menu.DisplayReadMediaMenu();
                    userInput = Console.ReadLine();

                    if (userInput == "1") 
                    {
                        // Display All Movies
                        foreach(Movie m in movieFile.Movies)
                        {
                            Console.WriteLine(m.displayMovieFormatted());
                        }
                    } 
                    else if (userInput == "2") 
                    {
                        // Display All Shows
                        foreach(Show s in showFile.Shows)
                        {
                            Console.WriteLine(s.displayShowFormatted());
                        }
                    } 
                    else if (userInput == "3") 
                    {
                        // Display All Videos
                        foreach(Video v in videoFile.Videos)
                        {
                            Console.WriteLine(v.displayVideoFormatted());
                        }
                    }
                }
            } while (userInput == "1" || userInput == "2" || userInput == "3");

            Console.WriteLine("Program Ended");
        }
    }
}