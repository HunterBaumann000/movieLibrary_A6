using System;
using System.Collections.Generic;

namespace MovieLibrary_A5
{

    public class Show
    {
        public int showId { get; set; }
        public string showTitle{get; set;}
        public int showSeason{get; set;}
        public int showEpisode{get; set;}
        public List<string> showWriters { get; set; }

        // constructor
        public Show()
        {
            showWriters = new List<string>();
        }

        public string displayShowFormatted()
        {
            //fo
            return $"ID: {showId}, Title: {showTitle}, Season {showSeason} Ep. {showEpisode}, Writers: {string.Join(", ", showWriters)}";
        }
    }
}