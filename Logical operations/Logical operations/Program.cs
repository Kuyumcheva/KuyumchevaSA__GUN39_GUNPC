// See https://aka.ms/new-console-template for more information
// Логические операции
/* Критерии оценивания:

  1. В калькуляторе пользователю предлагается ввести первое число, затем второе
  2  В случае ошибки есть предупреждение для пользователя, и настроен выход из программы
  3. Пользователю предлагается ввести оператор: & | или ^, и запрограммирована проверка ввода (введён корректный символ)
  4. В зависимости от ввода выводится результат побитовой операции
  5. Результат выводится в десятичной, двоичной и шестнадцатеричной форме
 */
class Program
{
    static void Main (string[] args)
    {
        // Ввод и проверка первого числа
        Console.WriteLine("Enter first number:");

        if (!int.TryParse(Console.ReadLine(), out int firstNumber))
        {
            Console.WriteLine("No-no-no, I said NUMBER!");
            return;
        }

        // Ввод и проверка второго числа
        Console.WriteLine("Enter second number:");
        
        if (!int.TryParse(Console.ReadLine(), out int secondNumber))
        {
            Console.WriteLine("Nope, not a NUMBER!");
            return;
        }

        // Ввод операнда
        Console.WriteLine("Choose operation: & (AND), | (OR), ^ (XOR):");

        var operand = Console.ReadLine();
        var result = 0;

        // Если операнд не введен или введено более 1 символа, то выводится предупреждение и выполняется выход из программы
        if (operand.Length == 0 || operand.Length > 1)
        {
            Console.WriteLine("Trying to cheat?");
            return;
        }

        switch (operand[0]) {
            //Результат выполнения логического И в трёх системах счисления
            case '&':    
                result = firstNumber & secondNumber;
                Console.WriteLine("Result of {0} & {1} in three formats:", firstNumber, secondNumber);
                Console.WriteLine("Decimal: {0}", result);
                Console.WriteLine("Binary: {0}", Convert.ToString(result, 2));
                Console.WriteLine("Hex: {0}", result.ToString("X"));
                break;

            //Результат выполнения логического ИЛИ в трёх системах счисления
            case '|':
                result = firstNumber | secondNumber;
                Console.WriteLine("Result of {0} | {1} in three formats:", firstNumber, secondNumber);
                Console.WriteLine("Decimal: {0}", result);
                Console.WriteLine("Binary: {0}", Convert.ToString(result, 2));
                Console.WriteLine("Hex: {0}", result.ToString("X"));
                break;

            //Результат выполнения логического исключающего ИЛИ в трёх системах счисления
            case '^':
                result = firstNumber ^ secondNumber;
                Console.WriteLine("Result of {0} ^ {1} in three formats:", firstNumber, secondNumber);
                Console.WriteLine("Decimal: {0}", result);
                Console.WriteLine("Binary: {0}", Convert.ToString(result, 2));
                Console.WriteLine("Hex: {0}", result.ToString("X"));
                break;

            //Предупреждение и выход из программы, если введён другой символ
            default:
                Console.WriteLine("Unknown operation. Please, use &, |, or ^.");
                return;
        }

    }
}