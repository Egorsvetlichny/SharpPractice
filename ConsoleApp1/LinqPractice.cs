using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPractice
{
    public class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int MaxScore { get; private set; }
        public float WinRate { get; private set; }
        public bool IsOnline { get; private set; }

        public Player(string name, int level = 0, int maxScore = 0, float winRate = 0.0f, bool isOnline = false)
        {
            Name = name;
            Level = level;
            MaxScore = maxScore;
            WinRate = winRate;
            IsOnline = isOnline;
        }
    }

    public class PlayersInfo
    {
        public static void ShowPlayersInfo()
        {
            List<Player> playersList = new List<Player>()
            {
                new Player("Джон Бин", 12, 125, 54.5f, true),
                new Player("Вася Петров", 123, 12532, 65.45f, true),
                new Player("Дима Ветров", 13, 125, 56.15f),
                new Player("Костя Панин", 12, 127, 57.02f, true),
                new Player("Илья Ванин"),
                new Player("Данил Полевой", 10, 101, 61.5f, true),
                new Player("Валентин Кашевой", 42, 786, 43.5f, true),
                new Player("Стас Губин", 29, 512, 70.0f, false),
                new Player("Антон Юбин", 57, 2982, 62.4f),
                new Player("Алексей Тюбин"),
            };

            //Перебор и фильтрация через цикл и if
            //Вывод всех игроков online
            foreach (var player in playersList)
            {
                if (player.IsOnline)
                {
                    Console.Write($"{player.Name}. ");
                }
            }
            Console.WriteLine();

            //Вывод всех игроков online при помощи Linq
            List<Player> playersOnline = (from Player player in playersList where player.IsOnline select player).ToList();
            OutputPlayersInLine(playersOnline);

            //Удобная запись той же фильтрации игроков с помощью методов расширения
            playersOnline = playersList.Where(player => player.IsOnline).Select(player => player).ToList();
            OutputPlayersInLine(playersOnline);

            //Вывод всех игроков, чьё имя начинается с буквы 'Д', уровнем больше 10, рекордом очков больше 100. Результат должен быть отсортирован по их винрейту по убыванию
            List<Player> filtredPlayers = playersList.Where(player => player.Level > 10 && player.MaxScore > 100 && player.Name.StartsWith('Д')).Select(player => player).OrderByDescending(player => player.WinRate).ToList();
            OutputPlayersInLine(filtredPlayers);

            //Вывод игрока с наивысшим уровнем
            var playerMaxLevel = playersList.OrderByDescending(player => player.Level).FirstOrDefault();
            Console.WriteLine($"Игрок с наивысшим уровнем {playerMaxLevel.Name} и его уровень равен: {playerMaxLevel.Level}.");

            //Вывод первых пяти игроков с наивысшим винрейтом
            List<Player> fiveBestPlayers = playersList.OrderByDescending(player => player.WinRate).Take(5).ToList();
            Console.WriteLine("Первые пять игроков с наивысшим винрейтом: ");
            OutputPlayersInLine(fiveBestPlayers);


            //Linq в сочетании с примитивными типами
            //Фильтрация массива чисел с плавающей точкой
        }

        //Функция вывода списка игроков с отступом строки
        private static void OutputPlayersInLine(List<Player> players)
        {
            foreach (var player in players)
                Console.Write($"{player.Name}. ");
            Console.WriteLine();
        }
    }
}