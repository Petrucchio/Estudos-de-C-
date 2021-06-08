using System;
using CalculatorLibrary;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Calculator calculator = new Calculator();
            while (!endApp)
            {
                String numInput1 = "";
                String numInput2 = "";
                double result = 0;
                string op;
                Console.WriteLine("Console calculator in c# i guess");
                Console.WriteLine("now just type a number, and press enter, ok?");
                numInput1 = Console.ReadLine();
                double number1 = 0;
                while (!double.TryParse(numInput1, out number1))
                {
                    Console.WriteLine("Plaease enter with a valid number code");
                    numInput1 = Console.ReadLine();
                }
                Console.WriteLine("now type another one");
                numInput2 = Console.ReadLine();
                double number2 = 0;
                while (!double.TryParse(numInput2, out number2))
                {
                    Console.WriteLine("Plaease enter with a valid number code");
                    numInput2 = Console.ReadLine();
                }
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");
                op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(number1, number2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("look here man, i actually just work oon numbers");
                    }
                    else
                        Console.WriteLine($"yeaah it actually works dude , this is your result {result}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("yeah its not working");
                }
                Console.WriteLine("ok now press the key n to close this thing");
                if (Console.ReadLine() == "n") endApp = true;
                Console.WriteLine("\n"); // Friendly linespacing.
            }
            // And call to close the JSON writer before return
            calculator.Finish();
            return;
        }
    }
}
