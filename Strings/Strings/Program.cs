using System.Text;
using System.Text.RegularExpressions;

namespace Strings
{
    internal class Program
    {
        /*Задание 1
         Конкатенация строк*/
        static string ConcatenateStrings(string str1, string str2)
        {
            var builder = new StringBuilder();

            builder.Append(str1);
            builder.Append(" ");
            builder.Append(str2);

            return builder.ToString();
        }

        /*Задание 2
         Имя и возвраст*/
        static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\nYou are {age} years old.";
        }

        /*Задание 3
         Информация о строке*/
        static string GetStringInfo(string input)
        {
            if (input == null)
            {
                return "NULL";
            }

            if (input == "")
            {
                return "Пустая строка";
            }

            int length = input.Length;
            string upper = input.ToUpper();
            string lower = input.ToLower();

            return $"Количество символов в строке: {length}\n" +
                  $"Строка в верхнем регистре: {upper}\n" +
                  $"Строка в нижнем регистре: {lower}";
        }

        /*Задание 4
         Первые 5 символов строки*/
        static string GetFirstFiveChars(string input)
        {
            if (input == null)
            {
                return "NULL";
            }

            if (input == "")
            {
                return "Пустая строка";
            }

            // Если строка короче 5 символов, возвращаем её целиком
            if (input.Length <= 5)
            {
                return input;
            }

            return input.Substring(0, 5);
        }

        /*Задание 5
         Предложение из массива строк*/
        static StringBuilder BuildSentenceFromArray(string[] strings)
        {
            if (strings == null)
            {
                return new StringBuilder("Входной массив null.");
            }
                
            var builder = new StringBuilder();

            for (int i = 0; i < strings.Length; i++)
            {
                // Используем Append, потому что AppendLine добавляет текст и символ перевода строки, что не подходит под условия задачи
                builder.Append(strings[i]);

                // Если это не последний элемент, добавляем пробел
                if (i < strings.Length - 1)
                {
                    builder.Append(" ");
                }
                    
            }

            return builder;
        }

        /*Задание 6
         Замена слова в предложении*/
        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {

            if (inputString == null)
            {
                return "Null";
            }

            if (inputString == "")
            {
                return "Пустая строка";
            }

            if (wordToReplace == null || wordToReplace.Trim() == "")
            {
                return inputString;
            }

            if (replacementWord == null)
            {
                replacementWord = "";
            }

            // Целое слово (границы \b) с игнорированием регистра
            string pattern = @"\b" + Regex.Escape(wordToReplace) + @"\b";

            return Regex.Replace(inputString, pattern, replacementWord, RegexOptions.IgnoreCase);
        }




        static void Main(string[] args)
        {
            Console.WriteLine(ConcatenateStrings("Hello,", "world!"));

            Console.WriteLine(GreetUser("Alice", 25));

            Console.WriteLine(GetStringInfo("What is up My guy"));

            Console.WriteLine(GetStringInfo(""));

            Console.WriteLine(GetStringInfo(null));

            Console.WriteLine(GetFirstFiveChars("Привет мир!"));    // "Приве"

            Console.WriteLine(GetFirstFiveChars("BOO"));             // "BOO"

            Console.WriteLine(GetFirstFiveChars("ABCDEFGHIJ"));   // "ABCDE"

            Console.WriteLine(GetFirstFiveChars(""));               // "Пустая строка"

            Console.WriteLine(GetFirstFiveChars(null));           // "NULL"

            string[] words = { "Hello", "world", "from", "space" };

            StringBuilder result = BuildSentenceFromArray(words);

            Console.WriteLine(result.ToString()); // Hello world from space

            string[] empty = { };
            Console.WriteLine(BuildSentenceFromArray(empty).ToString()); // Пустая строка

            Console.WriteLine(BuildSentenceFromArray(null).ToString()); // Входной массив null.

            Console.WriteLine(ReplaceWords("Hello world", "world", "")); // "Hello "

            Console.WriteLine(ReplaceWords("apple banana apple", "", "orange")); // "apple banana apple"

            Console.WriteLine(ReplaceWords("The cat in the category", "cat", "dog")); // "The dog in the category" (только целое слово "cat", не "category")

            Console.WriteLine(ReplaceWords("CASE Test case", "case", "sample")); // "sample Test sample" (замена без учёта регистра)

            Console.WriteLine(ReplaceWords("No matches here", "xyz", "abc")); // "No matches here" (нет совпадений)

            Console.WriteLine(ReplaceWords("", "test", "demo")); // Пустая строка

            Console.WriteLine(ReplaceWords(null, "test", "demo")); // "NULL"

        }
    }
}
