using System.Threading;
using System.Xml.Linq;

namespace Collections
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<string> _listOfStrings = new List<string>();

            public void TaskLoop()
            {
                _listOfStrings.Add("Первый");
                _listOfStrings.Add("Второй");
                _listOfStrings.Add("Третий");

                Console.WriteLine("Задача 1\n");


                while (true)
                {
                    Console.Write("\nВведите новую строку для добавления в конец списка (или '-exit' для выхода): ");
                    string input = Console.ReadLine();

                    if (IsExitCommand(input))
                        break;

                    _listOfStrings.Add(input);

                    Console.Write("Введите строку для добавления в середину списка (или '-exit' для выхода): ");
                    input = Console.ReadLine();

                    if (IsExitCommand(input))
                        break;

                    int middleIndex = _listOfStrings.Count / 2;
                    _listOfStrings.Insert(middleIndex, input);

                    Console.WriteLine("\nТекущее содержимое списка:");
                    for (int i = 0; i < _listOfStrings.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {_listOfStrings[i]}");
                    }
                }
            }
            private bool IsExitCommand(string input)
            {
                if (input == "-exit")
                {
                    Console.WriteLine("Завершение задачи 1.");
                    return true;
                }
                return false;
            }

        }

        private class DictionaryTask
        {
            private readonly Dictionary<string, int> _dictionary = new Dictionary<string, int>();

            public void TaskLoop() {

                Console.WriteLine("Задача 2\n");

                while (true) {

                    Console.WriteLine("Введите фамилию студента (или '-exit' для выхода):");
                    string surname = Console.ReadLine();

                    if (IsExitCommand(surname))
                        break;

                    Console.WriteLine("Введите оценку студента (или '-exit' для выхода): ");

                    string input = Console.ReadLine();

                    if (IsExitCommand(input))
                        break;

                    if (!int.TryParse(input, out int grade) || grade < 2 || grade > 5) {

                        Console.WriteLine("Оценка не может быть пустой, не цифрой, меньше 2 или больше 5.");
                        continue;
                    }

                    _dictionary.Add(surname, grade);

                    Console.Write("\nВведите фамилию студента, чтобы узнать его оценку: ");
                    surname = Console.ReadLine();

                    if (_dictionary.ContainsKey(surname))
                    {
                        Console.WriteLine($"Оценка студента {surname}: {_dictionary[surname]}");
                    }
                    else
                    {
                        Console.WriteLine($"Студент с фамилией {surname} не найден.");
                    }

                }
            
            }

            private bool IsExitCommand(string input)
            {
                if (input == "-exit")
                {
                    Console.WriteLine("Завершение задачи 2.");
                    return true;
                }
                return false;
            }
        }

        private class LinkedListTask
        {
            private class Node {

                public int Value;
                public Node Next { get; set; }
                public Node Prev { get; set; }

                public Node(int value)
                {
                    Value = value;
                }
            }

            private Node _nextNode;
            private Node _prevNode;
            private int _count;
            public void TaskLoop()
            {
                Console.WriteLine("Задача 3\n");

                while (_count < 6)
                {
                    Console.WriteLine("Введите фисло (или '-exit' для выхода): ");

                    if (_count == 3)
                    {
                        Console.Write("Введено 3 элемента. Если хотите продолжить ввод — введите 'y': ");
                        string response = Console.ReadLine();

                        if (response != "y")
                        {
                            break;  
                        }
                    }

                    if (!TryGetNextValue($"Элемент {_count + 1}: ", out int value))
                    {
                        return;
                    }

                    AddNode(value);
                }

                Console.WriteLine("\nСписок в прямом порядке:");
                PrintForward();

                Console.WriteLine("\nСписок в обратном порядке:");
                PrintBackward();
            }

            private bool TryGetNextValue(string template, out int value)
            {
                while (true) 
                {
                    Console.Write(template);
                    string input = Console.ReadLine();

                    if (input == "-exit")
                    {
                        Console.WriteLine("Завершение задачи 3.");
                        value = 0;
                        return false;
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Ввод не может быть пустым. Повторите попытку.");
                        continue;  
                    }

                    if (int.TryParse(input, out value))
                    {
                        return true;  
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите целое число. Повторите попытку.");
                        continue;  
                    }
                }
            }


            private void AddNode(int value)
            {
                Node newNode = new Node(value);

                if (_nextNode == null)
                {
                    _nextNode = newNode;
                    _prevNode = newNode;
                }
                else
                {
                    newNode.Prev = _prevNode;
                    _prevNode.Next = newNode;
                    _prevNode = newNode;
                }

                _count++;
            }

            private void PrintForward()
            {
                Node current = _nextNode;
                int index = 1;
                while (current != null)
                {
                    Console.WriteLine($"Элемент {index}. {current.Value}");
                    current = current.Next;
                    index++;
                }
            }

            private void PrintBackward()
            {
                Node current = _prevNode;
                int index = _count;
                while (current != null)
                {
                    Console.WriteLine($"Элемент {index}. {current.Value}");
                    current = current.Prev;
                    index--;
                }
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задачи, которую хотите запустить:\n 1 - Задача 1\n 2 - Задача 2\n 3 - Задача 3\n");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int task))
            {
                switch (task)
                {
                    case 1:
                        CheckTaskFirst();
                        break;
                    case 2:
                        CheckTaskSecond();
                        break;
                    case 3:
                        CheckTaskThird();
                        break;
                    default:
                        Console.WriteLine("Задачи с таким номером нет");
                        break;
                }
            }
           else
            {
                Console.WriteLine("Неверный ввод. Нужно ввести номер задачи - 1, 2 или 3!");
            }
        }


        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }

        private static void CheckTaskSecond()
        {
            var dictionaryTask = new DictionaryTask();
            dictionaryTask.TaskLoop();
        }

        private static void CheckTaskThird()
        {
            var linkedListTask = new LinkedListTask();
            linkedListTask.TaskLoop();
        }
    }
}


