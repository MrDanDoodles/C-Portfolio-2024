//The purpose of this program is the simple higher or lower game
namespace HigherOrLower
{
    internal class Program
    {
        //File Path for Score
        const string filePath = @"C:\\Users\\user\\Desktop\\Computer Science\\Personal Projects\\Higher - Lower\\score.txt";

        //MAIN
        static void Main(string[] args)
        {
            //Declaring the taunts
            string[,] taunt = {
                { "Wow thats so low", "A little too low", "Wow, so far off, LOW", "So close yet so low" }, 
                { "A tad bit too high", "Jeez, high up in the skies huh?", "You flew high over it", "You my man, are too high for this" }
            };

            //Varaiable Creation
            Random random = new Random();
            int playerGuess;                //Variable to catch user input
            int randomNumber;               //This will be a random number
            int numberOfGuesses = 0;        //Catching how many loops it took to guess correctly
            bool appIsOn = true;

            int previousScore;              //Loads the previous score from the last game.

            //Loading the previos score from the last game
            previousScore = loadScore(filePath);
            Console.WriteLine("Your previous score was: {0}", previousScore);

            //Generating random number
            Console.WriteLine("A random number between 1-100 has been chosen");
            randomNumber = random.Next(1, 100);

         //MAIN LOOP
            while (appIsOn)
            {
                numberOfGuesses++;

                //playerGuess is controlled by a function
                playerGuess = guessNumber();

                //checking to see if player was correct
                appIsOn = checkPlayerGuess(playerGuess, randomNumber, taunt);
            }
            Console.WriteLine("It took you {0} guesses to get it correct.", numberOfGuesses);
            saveScore(numberOfGuesses);
        }


        //FUNCTION CREATION
        static int guessNumber()
        {
            //Variable creation and declaration
            int guess = 0;
            Console.Write("Pick a number: ");

            //Catching exceptions and giving a default value
            try
            {
                guess = int.Parse(Console.ReadLine());
            }
            catch (Exception FormatException)
            {
                Console.WriteLine("You did not input a number!\n" +
                    "A default value of 0 was given");
            }
            return guess;
        }

        static bool checkPlayerGuess(int playerGuess, int randomNumber, string[,] taunt)
        {
            //declaring local variables
            bool appIsOn = true;
            Random random = new Random();

            if (playerGuess < randomNumber)
            {
                Console.WriteLine(taunt[0, random.Next(0, 4)]);
            }
            else if (playerGuess > randomNumber)
            {
                Console.WriteLine(taunt[1, random.Next(0, 4)]);
            }
            else if (playerGuess == randomNumber)
            {
                Console.WriteLine("You guessed correctly: {0}", randomNumber);
                appIsOn = false;
            }
            return appIsOn;
        }

        static void saveScore(int score)
        {
            string scoreString = score.ToString(); //Converts the int to a string
            File.WriteAllText(filePath, scoreString);
        }

        static int loadScore(string filePath)
        {
            int previousScore = 0;                          //catches the int version of score
            string contents = File.ReadAllText(filePath);   //Reads content from the file
            
            previousScore = int.Parse(contents);
            return previousScore;
        }
    }
}
