namespace TimeCalc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TimeCalculator
    {
        private readonly static Dictionary<string, Func<TimeSpan, TimeSpan, TimeSpan>>
            SupportedOperations = new Dictionary<string, Func<TimeSpan, TimeSpan, TimeSpan>>
            {
                {"+", (first, second) => first + second},
                {"-", (first, second) => first - second}
            };


        public TimeSpan Evaluate(string input)
        {
            string operation, expression;
            if (!ParseExpression(input, out operation, out expression))
                throw new ArgumentException("Wrong input format");

            return EvaluateExpression(operation, expression);
        }

        private static bool ParseExpression(string input, out string operation, out string expression)
        {
            var operations = SupportedOperations.Select(o => o.Key);
            foreach (var item in operations.Where(input.Contains))
            {
                operation = item;
                expression = input;
                return true;
            }

            operation = expression = null;
            return false;
        }

        private TimeSpan EvaluateExpression(string operation, string expression)
        {
            if (!SupportedOperations.ContainsKey(operation))
                throw new InvalidOperationException($"Opeation {operation} is not supported");

            var arguments = expression.Split(new[] { operation }, StringSplitOptions.RemoveEmptyEntries);

            var firstArgument = ParseTime(arguments[0]);
            var secondArgument = ParseTime(arguments[1]);

            var result = SupportedOperations[operation](firstArgument, secondArgument);
            return result;
        }

        private static TimeSpan ParseTime(string argument)
        {
            const string separator = " ";
            var timeParts = argument.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            var hour = int.Parse(timeParts[0]);
            var minute = int.Parse(timeParts[1]);

            var time = new TimeSpan(hour, minute, 0);
            return time;
        }
    }
}
