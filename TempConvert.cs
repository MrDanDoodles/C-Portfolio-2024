//Purpose of program is to convert Farenheit to Celcius and vice versa.
namespace TempConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable Declarations
            double f; //Farenheit Var
            double c; //Celcius Var

            int userChoice;     //Determines what conversion user wants
            bool appIsOn = true;//Determines whether the app is on or off

            //Intitial Loop
            while (appIsOn)
            {
                userChoice = getChoice();   //Gets what conversion the user would like to make

                if (userChoice == 0)        //User did not make a valid choice
                {
                    Console.WriteLine("Input Error: Try Again");
                }
                else if (userChoice == 1)   // F --> C
                {
                    Console.Write("Farenheit Temperature: ");
                    f = double.Parse(Console.ReadLine());

                    c = convertToCelcius(f);
                    Console.WriteLine("{0} Degrees Celcius", c);
                }
                else if (userChoice == 2)   // C --> F
                {
                    Console.Write("Celsius Temperature: ");
                    c = double.Parse(Console.ReadLine());

                    f = convertToFarenheit(c);
                    Console.WriteLine("{0} Degrees Farenheit", f);
                }
                appIsOn = endApp();
            }

            
        }

        //FUNCTION CREATION
        static double convertToCelcius(double f) // F --> C
        {
            double c;
            c = (f - 32) * 5/9;
            c = Math.Round(c, 2);
            return c;
        }

        static double convertToFarenheit(double c) // C --> F
        {
            double f;
            f = (c * 9/5) + 32;
            f = Math.Round(f, 2);

            return f;
        }

        static int getChoice() //Returns user's choice 
        {
            int choice = 0;
            Console.Write("Would you like to convert Farenheit to Celcius (1) | or | convert Celcius to Farenheit (2): ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("You did not input a number");
            }
            return choice;
        }

        static bool endApp() //Determines whether or not the User wants to end the program.
        {
            //Var Declarations
            bool appIsOn = true;
            string choice;

            //Making Decision
            Console.Write("Would you like to keep converting? Yes or No: ");
            choice = Console.ReadLine().ToLower();
            if (choice == "yes" || choice == "ye" || choice == "y")
            {
                Console.WriteLine("Enjoy Converting!\n");
            }
            else if (choice == "no" || choice == "n")
            {
                Console.WriteLine("Thank you for using my app!");
                appIsOn = false;
            }

            //Returning Decision
            return appIsOn;
        }
    }
}
