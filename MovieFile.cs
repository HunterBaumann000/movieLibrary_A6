using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace MovieLibrary_A5
{
    public class MovieFile
    {
        public string filePath { get; set; }
        public List<Movie> Movies { get; set; }
        
        public void AddMovie(Movie movie)
        {
            try
            {
                if (!File.Exists("movies.csv"))
                throw new FileNotFoundException();
            }
            catch(FileNotFoundException) { 
                System.Console.WriteLine("File was not found!");
                System.Console.WriteLine("Want to create a file? y/n");
                string wantNewFile = Console.ReadLine();
                    
                //creates file for user if they want it
                if (wantNewFile.Equals("y")) {
                    filePath = "movies.csv";
                    StreamWriter sw = new StreamWriter(filePath, true);
                }
            }
            
            try {
                // first generate movie id
                movie.movieId = Movies.Max(m => m.movieId) + 1;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{movie.movieId},{movie.movieTitle},{string.Join("|", movie.movieGenres)}");
                sw.Close();
                
                // add movie to list
                Movies.Add(movie);
            } 
            catch(Exception e)
            {
                //catches error
                Console.WriteLine(e.Message);
            }
        }

        public MovieFile(string movieFilePath)
        {
            filePath = movieFilePath;
            Movies = new List<Movie>();

            // read movie line
            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    // instance of Movie
                    Movie movie = new Movie();
                    string line = sr.ReadLine();

                    //gets input and converts to string
                    string[] movieLine = line.Split(',');

                    //fields that go into the string
                    movie.movieId = int.Parse(movieLine[0]);
                    movie.movieTitle = movieLine[1];
                    movie.movieGenres = movieLine[2].Split('|').ToList();
                    
                    //adds movie to file
                    Console.WriteLine(movieLine);
                }
                // close file when done
                sr.Close();
            }
            catch (Exception e)
            {
                //catch error
                Console.WriteLine(e.Message);
            }
        }
        public bool hasSameTitle(string movieTitle)
        {
            //goes through each movie with a lambda and checks whether titles are the same
            if (Movies.ConvertAll(m => m.movieTitle.ToLower()).Contains(movieTitle.ToLower())){
                Console.WriteLine("{Title} is a duplicate in the file", movieTitle);
                return true;
            }
            return false;
        }
    }
}