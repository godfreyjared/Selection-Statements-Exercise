namespace SelectionStatementExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int favNumber = r.Next(1, 1000); // This line generates the target number at random. 

            // I wanted to add a line that creates a hint because 1 to a 1000 is a really big range. 
            int hintRangeCenter = favNumber + r.Next(-9, 10); // within ±9 of actual number
            int hintRangeStart = Math.Max(1, hintRangeCenter - 10);
            int hintRangeEnd = Math.Min(999, hintRangeCenter + 10);

            Console.WriteLine("Welcome. Please provide a number. Your success, or failure, relies on this.");

            int score = 41;
            bool correct = false;
            bool hintGiven = false;

            while (!correct)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int response))
                {
                    Console.WriteLine("That's not a valid number. Try again.");
                    continue;
                }

                if (response < favNumber)
                {
                    Console.WriteLine($"Too low! Your guess: {response} is wrong!");
                    score--;
                }
                else if (response > favNumber)
                {
                    Console.WriteLine($"Too high! Your guess: {response} is wrong!");
                    score--;
                }
                else
                {
                    Console.WriteLine($"You guessed it! The correct number was {favNumber}! You must be some kind of wizard! Your final score is {score}.");
                    correct = true;
                    break;
                }

                if (!hintGiven)
                {
                    Console.WriteLine($"Hint: The number is within 10 of a number between {hintRangeStart} and {hintRangeEnd}.");
                    hintGiven = true;
                }

                if (score <= 0)
                {
                    Console.WriteLine("You've run out of points! Game over.");
                    Console.WriteLine($"The favorite number was {favNumber}.");
                    break;
                }
            }
        }
    }
}