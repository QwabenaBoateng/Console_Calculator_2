using System; // Importing the System namespace for basic functionalities

MckenzieCalculator calculator = new("Welcome to Mckenzie's Caculator"); // Creating an instance of the MckenzieCalculator class and initializing it with a greeting message
calculator.Start(); // Calling the Start method of the calculator instance

// Define a sealed class for the calculator
public sealed class MckenzieCalculator
{
    public string _greeting; // Private field to store the greeting message

    // Method to print a separator line
    public void PrintSeparator()
    {
        Console.WriteLine("..............................");
    }

    // Constructor to initialize the calculator with a greeting message
    public MckenzieCalculator(string greeting)
    {
        _greeting = greeting; // Assign the input greeting to the _greeting field
    }

    // Method to start the calculator
    public void Start()
    {
        PrintSeparator(); // Print a separator line
        Console.WriteLine(_greeting); // Display the greeting message
        PrintSeparator(); // Print a separator line

        // Dictionary to store supported operators and their descriptions
        Dictionary<string, string> supportedOperators = new()
        {
            {"+", "Addition"},
            {"-", "Subtraction"},
            {"*", "Multiplication"},
            {"/", "Division"},
        };

        // Infinite loop to keep the calculator running until the user chooses to exit
        while (true)
        {
            Console.WriteLine("Operator Choices are As Follows");
            PrintSeparator(); // Print a separator line

            // Display the supported operators and their descriptions
            foreach (var op in supportedOperators)
            {
                Console.WriteLine($"{op.Value}: {op.Key}");
            }

            Console.WriteLine("Enter an Operator:");
            string operatorChoice = Console.ReadLine(); // Read user input for operator choice

            // Check if the entered operator is supported
            if (!supportedOperators.TryGetValue(
                operatorChoice,
                out var selectedOperatorDescription))
            {
                Console.WriteLine("Invalid Operator choice.");
                continue; // Continue to the next iteration of the loop
            }

            Console.WriteLine($"You selected: {selectedOperatorDescription}");
            Console.WriteLine();

            Console.WriteLine(
                $"Recall that integers are in the range " +
                $"{int.MinValue} to {int.MaxValue}!");
            Console.WriteLine();

            Console.WriteLine("Enter the first integer");
            string firstNumberInput = Console.ReadLine(); // Read user input for the first number

            // Check if the input can be parsed as an integer
            if (!int.TryParse(firstNumberInput, out int firstNumber))
            {
                Console.WriteLine("Invalid input for the first number.");
                continue; // Continue to the next iteration of the loop
            }

            Console.WriteLine("Enter the second integer");
            string secondNumberInput = Console.ReadLine(); // Read user input for the second number

            // Check if the input can be parsed as an integer
            if (!int.TryParse(secondNumberInput, out int secondNumber))
            {
                Console.WriteLine("Invalid input for the second number.");
                continue; // Continue to the next iteration of the loop
            }

            int result; // Variable to store the result of the arithmetic operation
            try
            {
                // Perform the arithmetic operation based on the selected operator
                result = operatorChoice switch
                {
                    "+" => firstNumber + secondNumber,
                    "-" => firstNumber - secondNumber,
                    "*" => firstNumber * secondNumber,
                    "/" => firstNumber / secondNumber,

                    _ => throw new NotSupportedException(
                        $"Arithmetic is not currently supported " +
                        $"for operator {operatorChoice}"
                    )
                };
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by Zero.");
                continue; // Continue to the next iteration of the loop
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"There was an unhandled exception: {ex.Message}");
                continue; // Continue to the next iteration of the loop
            }

            Console.WriteLine($"The result is: {result}"); // Display the result of the operation

            char answer = 'Y'; // Variable to store user's response for continuing
            Console.WriteLine("Wish to continue type Y/N");
            answer = Console.ReadKey().KeyChar; // Read user's key press

            // Check if the user wants to continue or exit the calculator
            if (answer != 'Y')
            {
                break; // Exit the loop and end the calculator
            }
            continue; // Continue to the next iteration of the loop
        }
    }
}
