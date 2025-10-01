namespace ConsoleCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 0, num2, result;
            char op;

            Console.WriteLine("||||||||||||");
            Console.WriteLine("Калькулятор");
            Console.WriteLine("||||||||||||");

            try
            {                
                // Получаем первое число
                Console.Write("\nВведите первое число: ");
                num1 = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Это не число");
            }
            // Получаем операцию
            Console.Write("Введите арифметическую операцию (+, -, *, /): ");
            op = Convert.ToChar(Console.ReadLine());

            // Получаем второе число
            Console.Write("Введите второе число: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            // Perform calculation based on operator
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine($"Результат: {num1} + {num2} = {result}");
                    break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine($"Результат: {num1} - {num2} = {result}");
                    break;
                case '*':
                    result = num1 * num2;
                    Console.WriteLine($"Результат: {num1} * {num2} = {result}");
                    break;
                case '/':
                    if (num2 != 0) // Проверка деления на ноль
                    {
                        result = num1 / num2;
                        Console.WriteLine($"Результат: {num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Деление на 0.");
                    }
                    break;
                default:
                    Console.WriteLine("Не верная арифметическая операция.");
                    break;
            }

            Console.WriteLine("\nНажмите для выхода.");
            Console.ReadKey();
        }
    }
}
