namespace ConsoleCalc
{
    internal class Program
    {
        static double ReadNumber(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double number))
                    return number;
                Console.WriteLine("Ошибка: Введите корректное число!");
            }
        }

        static char ReadOperation()
        {
            while (true)
            {
                Console.Write("Введите арифметическую операцию (+, -, *, /): ");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && "+-*/".Contains(input[0]))
                    return input[0];

                Console.WriteLine("Ошибка: Неверная операция! Используйте +, -, * или /.");
            }
        }

        static bool CalculateOperation()
        {
            try
            {
                double num1 = ReadNumber("Введите первое число: ");
                char op = ReadOperation();
                double num2 = ReadNumber("Введите второе число: ");

                string result = op switch
                {
                    '+' => $"{num1} + {num2} = {num1 + num2}",
                    '-' => $"{num1} - {num2} = {num1 - num2}",
                    '*' => $"{num1} * {num2} = {num1 * num2}",
                    '/' when num2 != 0 => $"{num1} / {num2} = {num1 / num2:F2}",
                    '/' => "Ошибка: Деление на ноль!",
                    _ => "Неизвестная ошибка"
                };

                Console.WriteLine($"\nРезультат: {result}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
                return false;
            }
        }

        static bool AskForContinue()
        {
            while (true)
            {
                Console.Write("\nХотите выполнить еще одну операцию? (да/нет): ");
                string answer = Console.ReadLine()?.ToLower().Trim();

                switch (answer)
                {
                    case "да":
                    case "д":
                    case "yes":
                    case "y":
                        return true;
                    case "нет":
                    case "н":
                    case "no":
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Пожалуйста, введите 'да' или 'нет'");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("++++++++++++++++++++++");
            Console.WriteLine("КОНСОЛЬНЫЙ КАЛЬКУЛЯТОР");
            Console.WriteLine("++++++++++++++++++++++");

            bool continueCalculating = true;

            while (continueCalculating)
            {
                bool calculationSuccess = CalculateOperation();

                if (calculationSuccess)
                {
                    continueCalculating = AskForContinue();
                }
                else
                {
                    Console.WriteLine("Попробуйте еще раз...");
                }
            }

            Console.WriteLine("\n+++++++++++++++++++++++++++++++++");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}