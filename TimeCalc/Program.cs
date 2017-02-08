namespace TimeCalc
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            var calculator = new TimeCalculator();
            while (true)
            {
                Iterate(calculator);
            }
        }

        private static void Iterate(TimeCalculator calculator)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                var input = ReadString("Enter expression: ");
                if (string.IsNullOrWhiteSpace(input))
                    return;

                var result = calculator.Evaluate(input);
                Console.WriteLine("{0}:{1}", ((int)result.TotalHours), result.Minutes);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.ToString());
            }
        }

        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            var line = Console.ReadLine() ?? string.Empty;
            return line;
        }
    }
}
