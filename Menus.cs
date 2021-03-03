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
    }
}