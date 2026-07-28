public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        int solution = 0;
        try
        {
            if (operation == null)
                throw new ArgumentNullException();
            if (operation == "")
                throw new ArgumentException();
            if (operation != "+" &&
                operation != "*" &&
                operation != "/" &&
                operation != "-")
            {
                throw new ArgumentOutOfRangeException();
            }
            if (operation == "/" && operand2 == 0)
                return "Division by zero is not allowed.";
            switch (operation)
            {
                case "+":
                    solution = operand1 + operand2;
                    break;
                case "*":
                    solution = operand1 * operand2;
                    break;
                case "/":
                    solution = operand1 / operand2;
                    break;
                case "-":
                    throw new NotImplementedException("this operand is not to                         be used!");
                    break;
            }
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("The - operand cannot be used on this                             calculator!");
        }
        return $"{operand1} {operation} {operand2} = {solution.ToString()}";
    }
}
