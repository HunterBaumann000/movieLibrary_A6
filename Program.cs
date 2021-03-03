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
            string tempInput = "";

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
                        // Add movie
                        Movie movie = new Movie();

                        // ask user to input movie title
                        Console.WriteLine("What is the movie titled");
                        movie.movieTitle = Console.ReadLine();

                        // check if the title matches another title
                        if (!movieFile.hasSameTitle(movie.movieTitle)){
                       
                            do
                            {
                                // ask user to enter genre
                                Console.WriteLine("Enter genre. ('.' to stop) ");
                                tempInput = Console.ReadLine();
                                //adds to genrelist
                                movie.movieGenres.Add(tempInput);
                            } while (tempInput != ".");

                            //movie never gets created if the title matches another
                            movieFile.AddMovie(movie);
                        }
                    } 
                    else if (userInput == "2") 
                    {
                        // Add movie
                        Show show = new Show();

                        // ask user to input movie title
                        Console.WriteLine("What is the show titled");
                        show.showTitle = Console.ReadLine();

                        // check if the title matches another title
                        if (!showFile.hasSameTitle(show.showTitle)){
                       
                            Console.WriteLine("What Season?");
                            show.showSeason = int.Parse(Console.ReadLine());

                            Console.WriteLine("What Episode?");
                            show.showEpisode = int.Parse(Console.ReadLine());
            
                            do
                            {
                                // ask user to enter genre
                                Console.WriteLine("Enter a Writer. ('.' to stop) ");
                                tempInput = Console.ReadLine();

                                show.showWriters.Add(tempInput);
                            
                            } while (tempInput != ".");

                            //show never gets created if the title matches another
                            showFile.AddShow(show);
                        }
                    }
                    else if(userInput == "3")
                    {
                        // Add video
                        Video video = new Video();

                        // ask user to input movie title
                        Console.WriteLine("What is the video titled");
                        video.videoTitle = Console.ReadLine();

                        Console.WriteLine("What is the video format?");
                        video.videoFormat = Console.ReadLine();

                        Console.WriteLine("How many minutes long is the video?");
                        video.videoLength = int.Parse(Console.ReadLine());

                        // check if the title matches another title
                        if (!videoFile.hasSameTitle(video.videoTitle)){
                       
                            do
                            {
                                // ask user to enter genre
                                Console.WriteLine("Enter a Region, type '.' to stop) ");
                                tempInput = Console.ReadLine();

                                video.videoRegions.Add(tempInput);
                            
                            } while (tempInput != ".");
           
                            //video never gets created if the title matches another
                            videoFile.AddVideo(video);
                        }
                    }
                } 
                else if (userInput == "2")
                {
                    //displays menu for reading the from the file
                    menu.DisplayReadMediaMenu();
                    userInput = Console.ReadLine();

                    if (userInput == "1") {
                        // Display All Movies
                        foreach(Movie m in movieFile.Movies)
                        {
                            Console.WriteLine(m.displayMovieFormatted());
                        }
                    } 
                    else if (userInput == "2") {
                        // Display All Shows
                        foreach(Show s in showFile.Shows)
                        {
                            Console.WriteLine(s.displayShowFormatted());
                        }
                    } 
                    else if (userInput == "3") {
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