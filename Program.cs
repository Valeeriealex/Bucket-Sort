using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucket_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            Random random = new Random();
            int minimumElementArray = 0;
            int maximumElementArray = 11;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minimumElementArray, maximumElementArray);
            }

            PrintArray(array);
            BucketSort(array);
            PrintArray(array);
        }

        static void BucketSort(int[] array)
        {
            //создаем корзины кол. которых = кол. элементов исходного массива
            List<int>[] bucket = new List<int>[array.Length];

            //инициализируеи каждую корзину(каждый элемент(i) в List)
            for (int i = 0; i < bucket.Length; i++) 
            {
                bucket[i] = new List<int>();
            }

            //ищем мин. и макс. значение в исходном массиве
            int minValue = array[0];
            int maxValue = array[0];

            for (int i = 1; i < array.Length; i++) 
            { 
                if (array[i] < minValue)
                {
                    minValue = i;
                }
                if (array[i] > maxValue) 
                {
                    maxValue = array[i];
                }
            }

            //найдем разницу между мин. и макс. элементом массива и присвоем значение
            double numRange = maxValue - minValue;

            //создаем цикл, который  вычисляет i корзины и добавляет элементы в соответствующую
            for (int i = 0; i < array.Length; i++)
            {
                int bucketIndex = (int)Math.Floor((array[i] - minValue) / numRange * (bucket.Length - 1));
                bucket[bucketIndex].Add(array[i]);
            }

            //отсортированные элементы собираем обратно в исходный массив
            int indexArray = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < bucket[i].Count; j++)
                {
                    array[indexArray++] = bucket[i][j];
                }
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
