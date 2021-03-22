namespace MovieLibrary_A5
{
    public class Menus
    {
         public void DisplayMainMenu() {
            System.Console.WriteLine("");
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("   1.) Add a Media.");
            System.Console.WriteLine("   2.) Display a list of media.");
            System.Console.WriteLine("   3.) Display page of media (Not working yet).");
            System.Console.WriteLine("   4.) End Program.");
            System.Console.Write("Choice: ");
        }

        public void DisplayMediaTypeMenu() {
            System.Console.WriteLine("What type of media would you like?");
            System.Console.WriteLine("   1.) A Movie. ");
            System.Console.WriteLine("   2.) A Show. ");
            System.Console.WriteLine("   3.) A Video. ");
        }

        public void DisplayReadMediaMenu() {
            System.Console.WriteLine("What File would you like to read?");
            System.Console.WriteLine("   1.) The Movie File. ");
            System.Console.WriteLine("   2.) The Show File. ");
            System.Console.WriteLine("   3.) The Video File. ");
        }

        public static void askUserForMovie(string userInput) {

            string movieFilePath = "movies.csv";
            MovieFile movieFile = new MovieFile(movieFilePath);

            // Add movie
            Movie movie = new Movie();
            string tempInput = "";

            // ask user to input movie title
            System.Console.WriteLine("What is the movie titled");
            movie.movieTitle = System.Console.ReadLine();

            // check if the title matches another title
            if (!movieFile.hasSameTitle(movie.movieTitle)){
                       
                do
                {
                    // ask user to enter genre
                    System.Console.WriteLine("Enter a genre. ('.' to stop) ");
                    tempInput = System.Console.ReadLine();
                    //adds to genrelist
                    movie.movieGenres.Add(tempInput);
                } 
                while (tempInput != ".");

                //movie never gets created if the title matches another
                movieFile.AddMovie(movie);
            }
        }   


        public static void askUserForShow(string userInput) {

            string showFilePath = "shows.csv";
            ShowFile showFile = new ShowFile(showFilePath);

            // Add show
            Show show = new Show();
            string tempInput = "";

            // ask user to input show title
            System.Console.WriteLine("What is the show titled");
            show.showTitle = System.Console.ReadLine();

            // check if the title matches another title
            if (!showFile.hasSameTitle(show.showTitle)){
                       
                System.Console.WriteLine("What Season?");
                show.showSeason = int.Parse(System.Console.ReadLine());

                System.Console.WriteLine("What Episode?");
                show.showEpisode = int.Parse(System.Console.ReadLine());
            
                do
                {
                    // ask user to enter a writer
                    System.Console.WriteLine("Enter a Writer. ('.' to stop) ");
                    tempInput = System.Console.ReadLine();

                    show.showWriters.Add(tempInput);
                            
                } while (tempInput != ".");

                //show never gets created if the title matches another
                showFile.AddShow(show);
            }   
        }

        public static void askUserForVideo(string userInput) {

            string videoFilePath = "video.csv";
            VideoFile videoFile = new VideoFile(videoFilePath);

            // Add video
            Video video = new Video();
            string tempInput = "";

            // ask user to input video title
            System.Console.WriteLine("What is the video titled");
            video.videoTitle = System.Console.ReadLine();

            System.Console.WriteLine("What is the video format?");
            video.videoFormat = System.Console.ReadLine();

            System.Console.WriteLine("How many minutes long is the video?");
            video.videoLength = int.Parse(System.Console.ReadLine());

            // check if the title matches another title
            if (!videoFile.hasSameTitle(video.videoTitle)){
                       
                do
                {
                    // ask user to enter region
                    System.Console.WriteLine("Enter a Region (type '.' to stop) ");
                    tempInput = System.Console.ReadLine();

                    video.videoRegions.Add(tempInput);
                            
                } while (tempInput != ".");
           
                //video never gets created if the title matches another
                videoFile.AddVideo(video);
            }
        }
    }   
}
