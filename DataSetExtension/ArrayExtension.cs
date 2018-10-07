using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//visualGo for sortingб ен грифелдс
// Суздаль спец курс по алгоритмам
// массив - объект в памяти с кол полей = кол эллементов + поле длинна массива
// куча- управляемая куча 
// в имени массива лежит ссылка(порция данных уник образом идентифицирующая объект в куче)
// +bubble sort + tests +mergeSort сначала публичные потом приватные 
// одномер массив написать метод выполн трансформация = каждый элемент в его строковое двоичное представление
// string обертка над массивом чаров
namespace DataSetExtension
{
    //Add delegate
    public static class ArrayExtension
    {
        //add
        public const int LowerBase = 2;
        public const int UpperBase = 16;

        public static string[] TransformToString(int []array,int @base)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = TransformToString(array[i], @base);
            }

            return result;
        }

        public static string[] TransformToString(int[] array) // repsentation use 
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = TransformToString(array[i]);
                result[i] = string.Join(" ",result[i].Split(new char[] { ' ' }).Reverse()).Trim();
            }
            return result;
        }

        private static string TransformToString(int value)
        {
            string[] words = { "zero","one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var temp = new StringBuilder();

            while (value != 0)
            {
                int rest = value % 10;
                temp.Append(words[rest]);
                temp.Append(" ");
                value /= 10;
            }
            return  temp.ToString();

        }

        private static string TransformToString(int value, int @base)
        {
            var temp = new StringBuilder();

            Notation notation = new Notation(@base);

            while (value != 0)
            {
                int rest = value % notation.Base;
                temp.Append(notation.Alphabet[rest]);
                value /= notation.Base;
            }

            char[] result = temp.ToString().ToArray();

            for (int i = 0; i < result.Length / 2 - 1; i++)
            {
                Swap(ref result[i], ref result[result.Length - 1 - i]);
            }

            return new string(result);
        }

        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            QuickSort(array, 0, array.Length - 1);
        }

        public static void BubbleSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            BubbleSort(array, array.Length);
        }

        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            MergeSort(array, 0, array.Length - 1);
        }
        private static void BubbleSort(int[] array, int size)
        {
            bool isChanged = false;
            int start = 0, end = size - 1;

            do
            {
                for (int i = start; i < end; i++)
                {
                    if (array[i] > array[i+1])
                    {
                        Swap<int>(ref array[i], ref array[i+1]);
                        isChanged = true;
                    }     
                }
                end--;

                if (isChanged == false) break;

                isChanged = false;

                for (int j = end; j>start; j--)
                {
                    if (array[j] < array[j-1])
                    {
                        Swap<int>(ref array[j - 1], ref array[j]);
                        isChanged = true;
                    }
                }

                start++;

                if (isChanged == false) break;

                isChanged = false;

            } while (start< end);
        }

        private static void MergeSort(int[] input, int startIndex, int endIndex)
        {
            int mid;

            if (endIndex > startIndex)
            {
                mid = (endIndex + startIndex) / 2;
                MergeSort(input, startIndex, mid);
                MergeSort(input, (mid + 1), endIndex);
                Merge(input, startIndex, (mid + 1), endIndex);
            }
        }

        private static void Merge(int[] input, int left, int mid, int right)
        { 
            int[] temp = new int[input.Length];

            int i, leftEnd, lengthOfInput, tmpPos;
            leftEnd = mid - 1;
            tmpPos = left;
            lengthOfInput = right - left + 1;

            while ((left <= leftEnd) && (mid <= right))
            {
                if (input[left] <= input[mid])
                {
                    temp[tmpPos++] = input[left++];
                }
                else
                {
                    temp[tmpPos++] = input[mid++];
                }
            }

            while (left <= leftEnd)
            {
                temp[tmpPos++] = input[left++];
            }


            while (mid <= right)
            {
                temp[tmpPos++] = input[mid++];
            }

            for (i = 0; i < lengthOfInput; i++)
            {
                input[right] = temp[right];
                right--;
            }
        }

       

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                QuickSort(array, left, pivot - 1);
                QuickSort(array, pivot + 1, right);
            }
        }
        
        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }

            Swap(ref array[i + 1], ref array[high]);

            return i + 1;
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

    }
}
