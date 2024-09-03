using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPractice
{
    //Основы работы с коллекциями на c#. Операции вставки, чтения и удаления элементов
    internal class CollectionPractice
    {
        public void WorkArray()
        {
            int[] arr = new int[] { 1, 3, 5, 2, 5, 1, 3 };
            string[,] stringArr = new string[,] { { "Egor", "Svetlichny", "23", "Kazan" }, { "Sasha", "Petrov", "35", "Moscow" }, { "Vasya", "Ivanov", "77", "Volgograd" } };

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine($"Элемент массива {i} = {arr[i]}");

            Console.WriteLine();

            stringArr[1, 0] = "Dima";

            for (int i = 0; i < stringArr.GetLength(0); i++)
                Console.WriteLine($"{stringArr[i, 0]} {stringArr[i, 1]} - {stringArr[i, 2]} года, город - {stringArr[i, 3]};");

            Console.WriteLine("\n\n");
        }

        public void WorkList()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 10; i++)
                list.Add(i + 1);

            list.Remove(10);
            list.RemoveAt(4);
            list.AddRange(new int[] { 12, 14, 15, 16 });
            list.Insert(5, 777);
            Console.WriteLine($"Число 15 находится на позиции {list.IndexOf(15)}");

            int index = 0;
            // for (int i = 0; i < list.Count; i++)
            foreach (var item in list)
                Console.WriteLine($"Элемент списка с индексом {index++} равен {item}");

            Console.WriteLine("\n\n");
        }

        public void WorkQueue()
        {
            Queue<string> visitors = new Queue<string>(5);
            string[] arr = new string[] { "Петров", "Иванов", "Сидоров", "Светличный", "Тарасов" };

            foreach (var item in arr)
                visitors.Enqueue(item);

            foreach (var visitor in visitors)
                Console.WriteLine($"Посетитель - {visitor};");

            Console.WriteLine();

            // Забрать объект из очереди функция Dequeue
            string currentVisitor = visitors.Dequeue();
            Console.WriteLine($"Посетитель {currentVisitor} вышел из очереди.");

            // Вывести следующий в очереди объект, но не забирать его функция Peek
            string nextVisitor = visitors.Peek();
            Console.WriteLine($"Следующий посетитель {nextVisitor}.");

            Console.WriteLine($"\nОчередь после ухода посетителя - {currentVisitor}:");
            foreach (var visitor in visitors)
                Console.WriteLine(visitor);

            Console.WriteLine("\n\n");
        }

        public void WorkStack()
        {
            Stack<string> books = new Stack<string>();
            List<string> booksList = new List<string>(5) { "Мастер и Маргарита", "Собачье сердце", "Белая гвардия", "Дни Турбины", "Зойкина квартира" };

            foreach (var book in booksList)
                books.Push(book);

            Console.WriteLine("Стэк с лежащими на одной полке книгами: ");
            foreach (var book in booksList)
                Console.WriteLine($"\"{book}\";");

            // Вывести следующий в стеке объект, но не забирать его функция Peek
            string currentBook = books.Peek();
            Console.WriteLine($"\nСамая верхная книга на полке - \"{currentBook}\".\n");

            // Забрать объект из стека функция Pop
            while (books.Count > 0)
                Console.WriteLine($"Забрали с полки книгу - \"{books.Pop()}\"");
            Console.WriteLine("На книжной полке закончились все книги!");

            Console.WriteLine("\n\n");
        }

        public void WorkDictionary()
        {
            Dictionary<int, string> dictCapitals = new Dictionary<int, string>(4);
            Dictionary<string, string> dictCountries = new Dictionary<string, string>() { { "Russia", "Moscow" }, { "German", "Berlin" }, { "Italy", "Roma" }, { "France", "Paris" } };

            int i = 0;

            dictCountries.Remove("Italy");
            dictCapitals.Add(3, "Vena");

            foreach (var item in dictCountries)
                dictCapitals.Add(i++, item.Value);

            foreach (var item in dictCapitals)
                Console.WriteLine($"Элемент в словаре с ключом - {item.Key} равен {item.Value};");

            Console.WriteLine($"\nСтолица Австрии - город {dictCapitals[3]}.");
            Console.WriteLine($"А столица Франции - город {dictCountries["France"]}.");
        }
    }
}
