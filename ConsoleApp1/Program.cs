using SharpPractice;
using System.Security.Cryptography;

//namespace CSLight
//{
//    internal class Program
//    {
//        private static float foo()
//        {
//            float res;
//            int x, y = 2;
//            x = 5;
//            res = x / y;
//            return res;
//        }
//        private static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//            Console.WriteLine(foo());

//            int x = 10;
//            Console.WriteLine(int.MaxValue);
//            Console.WriteLine($"fds {x} fwe: {10} {true}");
//            Console.WriteLine($"{1 + Convert.ToInt32(false)}");

//            string name;
//            Console.Write("Введите ваше имя: ");
//            name = Console.ReadLine();
//            Console.WriteLine(name);

//            int age;
//            Console.Write("Введите ваш возраст: ");
//            age = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine($"Ваш возраст: {age}");

//            Console.WriteLine();
//            int countOfFood, foodUnitPrice = 10, countOfMoney;
//            Console.WriteLine($"Добро пожаловать в пекарню сегодня еда по {10} монет!");
//            Console.Write("Введите количество монет у вас: ");
//            countOfMoney = Convert.ToInt32(Console.ReadLine());
//            Console.Write("Сколько единиц еды вы хотите купить: ");
//            countOfFood = Convert.ToInt32(Console.ReadLine());
//            bool flag = countOfMoney >= countOfFood * foodUnitPrice;
//            if (flag)
//            {
//                Console.WriteLine($"Вы купили {countOfFood} единиц еды, у вас осталось {countOfMoney - countOfFood * foodUnitPrice} монет");
//            }
//            else
//            {
//                Console.WriteLine($"Вы купили {countOfMoney / foodUnitPrice} единиц еды, у вас осталось {countOfMoney % foodUnitPrice} монет");
//            }

//            Console.WriteLine();
//            string dayOfWeek;
//            for (int i = 0; i < 4; i++)
//            {
//                Console.Write("Введите день недели: ");
//                dayOfWeek = Console.ReadLine().ToLower();
//                switch (dayOfWeek)
//                {
//                    case "понедельник":
//                    case "четверг":
//                        Console.WriteLine("Сегодня понедельник или четверг");
//                        break;
//                    case "среда":
//                        Console.WriteLine("Сегодня среда");
//                        break;
//                    case "суббота":
//                        Console.WriteLine("Сегодня суббота");
//                        break;
//                    default:
//                        Console.WriteLine("Сегодня другой день недели");
//                        break;
//                }
//            }

//            //Console.ReadKey();

//        }
//    }
//}

namespace CSLRight
{
    internal class Programm
    {
        public static void func()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 20;
            Console.WindowWidth = 100;
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Change colors of console!");
            Console.SetCursorPosition(0, 0);
        }

        //Сортировка пузырьком одномерного массива
        public static int[] bubbleSort(int[] arr)
        {
            int item;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        item = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = item;
                    }
                }
            }

            return arr;
        }

        //Сортировка вставками одномерного массива
        public static int[] insertionSort(int[] arr)
        {
            int item;

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        item = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = item;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return arr;
        }

        static void AlgoSortingRun()
        {
            //Сортировка пузырьком
            int[] array = bubbleSort([3, 4, 1, 2, 10, 0, 1, 0, 9, 2]);
            Console.Write("Отсортированный пузырьком массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            //Сортировка вставками
            array = insertionSort([3, 4, 1, 2, 10, 0, 1, 0, 9, 2]);
            Console.Write("Отсортированный вставками массив: ");
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
        }

        private static void Main(string[] args)
        {
            //---Работа с рандомными числами---
            //Console.WriteLine("Запуск программы. Урок 2");
            //Random random = new Random();
            //int randomNumber = random.Next(0, 10);
            //Console.WriteLine(randomNumber);

            //---Работа параметрами консоли---
            //func();

            //---Работа с алгоритмами сортировки---
            //AlgoSortingRun();


            //---Написание консольной игры---
            //ConsoleGame csGame = new ConsoleGame();
            //csGame.Game();


            //Коллекции в c#
            //CollectionPractice collectionPractice = new CollectionPractice();
            //collectionPractice.WorkArray();
            //collectionPractice.WorkList();
            //collectionPractice.WorkQueue();
            //collectionPractice.WorkStack();
            //collectionPractice.WorkDictionary();

            Student[] stedentsArr =
            {
                new Student("Пётр Иванов", 22, 'B', true, 4.7f),
                new Student("Вася Зайцев", 18, 'A', false, 3.24f),
                new Student("Дима Клюев", 20, 'B', false, 3.45f),
                new Student("Андрей Марск", 21, 'A', false, 3.33f),
                new Student("Ольга Коршун", 20, 'A', true, 4.84f),
            };

            foreach (var student in stedentsArr)
                student.ShowInfo();
            Console.WriteLine();

            Article article1 = new Article(DateTime.Now);
            Article article2 = new Article(DateTime.Now, "Влияние IT-индустрии на жизнь подростков", "vliyanie-it", 243_256);

            Dictionary<int, Article> articleDict = new Dictionary<int, Article>() { { 1, article1 }, { 2, article2 } };
            foreach (var articleKey in articleDict.Keys)
                articleDict[articleKey].ShowInfo();

            Console.WriteLine();
            Type type = typeof(Article);
            Console.WriteLine(type);
            // Вывод родительского класса для класса Article
            Console.WriteLine(type.BaseType);
            // Доказательство того, что все классы неявно наследуются от класса Object
            Console.WriteLine(type.IsSubclassOf(typeof(Object)));

            // Вывод всех классов наследников класса BaseArticle
            Type[] types = typeof(BaseArticle).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseArticle))).ToArray();
            foreach (var item in types)
                Console.WriteLine(item);

            // При отрицательных значениях _countOfViews падает ошибка из-за написанной в сеттере валидации
            PrivateArticle privateArticle = new PrivateArticle("Старлинк и будущее", "starlink-i-budushee", DateTime.Now, 100);
            Console.WriteLine($"Аттрибут \"{nameof(privateArticle.CountOfViews)}\" объекта \"{nameof(privateArticle)}\" равен {privateArticle.CountOfViews}");

            Console.ReadKey();
        }
    }
}
