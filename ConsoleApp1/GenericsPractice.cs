using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SharpPractice
{
    //Класс для создания кастомного массива с обобщённым типом
    class MyArray<T>
    {
        private T[] _array = Array.Empty<T>();

        public T this[int index]
        {
            get { return _array[index]; }
        }

        public int Length() { return _array.Length; }

        public void Add(T value)
        {
            T[] newArray = new T[_array.Length + 1];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }
            newArray[_array.Length] = value;

            _array = newArray;
        }
    }

    class GenericsPractice
    {
        static public void ShowResults()
        {
            MyArray<int> intArray = new MyArray<int>();
            intArray.Add(0);
            intArray.Add(6);
            intArray.Add(-2);
            intArray.Add(12);
            OutputArray(intArray);

            MyArray<float> floatArray = new MyArray<float>();
            floatArray.Add(3211.0f);
            floatArray.Add(4231.003f);
            floatArray.Add(0.0234f);
            floatArray.Add(-234231.230f);
            OutputArray(floatArray);

            MyArray<string> stringArray = new MyArray<string>();
            stringArray.Add("Я");
            stringArray.Add("Строковый");
            stringArray.Add("Элемент");
            stringArray.Add("Массива");
            OutputArray(stringArray);

            MyArray<int[]> customArray = new MyArray<int[]>();
            customArray.Add(new int[] { 3, 4, 5, 2, 4 });
            customArray.Add(new int[] { -23, 0, 0, -2 });
            customArray.Add(new int[] { });
            customArray.Add(new int[] { 3234235 });
            OutputArray(customArray);
        }

        static private void OutputArray<T>(MyArray<T> array)
        {
            for (int i = 0; i < array.Length(); i++)
            {
                if (i == array.Length() - 1)
                {
                    Console.Write($"{array[i]};");
                }
                else
                {
                    Console.Write($"{array[i]}  ");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
