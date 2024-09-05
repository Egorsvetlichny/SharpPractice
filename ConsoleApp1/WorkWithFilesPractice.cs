using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPractice
{
    public class MyFile
    {
        public string FilePath { get; private set; }

        public MyFile(string filePath)
        {
            FilePath = filePath;
        }

        public bool CheckFileExisting()
        {
            return File.Exists(FilePath);
        }

        public string[] ReadFile()
        {
            string[] fileLines;
            try
            {
                fileLines = File.ReadAllLines(FilePath);
            }
            catch (Exception ex)
            {
                fileLines = [];
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
            return fileLines;
        }

        public void WriteToFile(string output)
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    //foreach (string line in fileLines)
                    //{
                    //    writer.WriteLine(line);
                    //}

                    writer.WriteLine(output);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи данных в файл: {ex.Message}");
            }
        }

    }

    public class SortingObject
    {
        private int[] _arrayInt;
        private List<int> _listInt;
        private int _objectLength;

        public int[] ArrayInt { get; private set; }
        public List<int> ListInt { get; private set; }
        public int ObjectLength
        {
            get
            {
                return _objectLength;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Длина не может быть отрицательным числом", nameof(_objectLength));
                }
                else
                {
                    _objectLength = value;
                }
            }
        }

        public SortingObject(int length = 0, int[] arrayInt = null, List<int> listInt = null)
        {
            ObjectLength = length;
            ArrayInt = arrayInt ?? new int[ObjectLength];
            ListInt = listInt ?? new List<int>(ObjectLength);
        }

        public int[] QuickSortObject(int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }
            else
            {
                int pivot = arr[0];
                int[] less = arr[1..].Where(item => item.CompareTo(pivot) <= 0).ToArray();
                int[] greater = arr[1..].Where(item => item.CompareTo(pivot) > 0).ToArray();

                return QuickSortObject(less).Concat(new int[] { pivot }).Concat(QuickSortObject(greater)).ToArray();
            }
        }

        public List<int> QuickSortObject(List<int> list)
        {
            if (list.Count < 2)
            {
                return list;
            }
            else
            {
                int pivot = list[0];
                List<int> less = list.GetRange(1, list.Count - 1).Where(item => item <= pivot).ToList();
                List<int> greater = list.GetRange(1, list.Count - 1).Where(item => item > pivot).ToList();

                return QuickSortObject(less).Concat(new List<int>() { pivot }).Concat(QuickSortObject(greater)).ToList();
            }
        }

    }
}
