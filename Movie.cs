using System;
using System.Collections.Generic;
namespace MovieLibrary_A5 {
    
    public class Movie
    {
        //public fields for each part of the movie
        public int movieId { get; set; }
        public string movieTitle{get; set;}
        public List<string> movieGenres { get; set; }
        
        public string displayMovieFormatted()
        {
            //formatted fields for console.writeLine 
            return $"Id: {movieId}, Title: {movieTitle}, Genres: {string.Join(", ", movieGenres)}";
        }
        public Movie()
        {
            //list of movieGenres so other class can access
            movieGenres = new List<string>();
        }
    }
}