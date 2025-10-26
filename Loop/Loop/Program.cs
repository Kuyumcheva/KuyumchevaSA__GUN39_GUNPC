// See https://aka.ms/new-console-template for more information

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[10];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            Console.WriteLine("Задание 1: Числа Фиббоначи \n");

            for (int i = 2; i < fibonacci.Length; i++)
              {

                  fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                  Console.WriteLine(fibonacci[i]); 

              }
            
            Console.WriteLine("\nЗадание 2: Чётные числа от 2 до 20 \n");

            for (int i = 2; i < 21;  i++)
             {
                 if( i % 2 == 0)
                 {
                     Console.WriteLine(i);

                 }

             }

            
            Console.WriteLine("\nЗадание 3: Таблица умножение от 1 до 5 \n");

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Console.Write($"{i * j,4}");
                }

                Console.WriteLine();
            }

            
            Console.WriteLine("\nЗадание 4: Проверка пароля \n");

            string password = "qwerty";
            string userPassword;

            do
            {
                Console.Write("Enter your password: ");
                userPassword = Console.ReadLine();

                if (userPassword != password)
                {
                    Console.WriteLine("Wrong password. Try again: ");
                }
            }
            while (userPassword != password);

            Console.WriteLine("Access granted!");
        }
    }
}