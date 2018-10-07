using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using static DataSetExtension.ArrayExtension;

namespace Sorts_Tests
{
    [TestClass]
    public class SortsTests
    {
        [TestMethod]
        public void MergeSortForThePositiveShoudReturnSortedArray()
        {
            int[] temp = { 89, 4, 14, 11, 58 };
            int[] result = new int[temp.Length];
            Array.Copy(temp, result, temp.Length);
            Array.Sort(result);
            MergeSort(temp);
            CollectionAssert.AreEqual(temp, result);
        }
        [TestMethod]
        public void MergeSortForTheMixedShoudReturnSortedArray()
        {
            int[] temp = { 89, -4, 14, 11, -58 };
            int[] result = new int[temp.Length];
            Array.Copy(temp, result, temp.Length);
            Array.Sort(result);
            MergeSort(temp);
            CollectionAssert.AreEqual(temp, result);
        }
        [TestMethod]
        public void QuickSortForThePositiveShoudReturnSortedArray()
        {
            int[] temp = { 89, 4, 14, 11, 58 };
            int[] result = new int[temp.Length];
            Array.Copy(temp, result, temp.Length);
            QuickSort(temp);
            Array.Sort(result);
            CollectionAssert.AreEqual(temp, result);
        }
        [TestMethod]
        public void QuickSortForTheMixedShoudReturnSortedArray()
        {
            int[] temp = { 89, -4, 14, -11, 58 };
            int[] result = new int[temp.Length];
            Array.Copy(temp, result, temp.Length);
            QuickSort(temp);
            Array.Sort(result);
            CollectionAssert.AreEqual(temp, result);
        }

        //[TestMethod]
        public void SortsForRandomDoublesShoudReturnSortedArray()
        {
            int Min = -158782;
            int Max = 168415;
            int[] first = new int[900000];
            int[] second = new int[900000];
            Random random = new Random();
            for (int i = 0; i < first.Length; i++)
            {
                first[i] = random.Next() * (Max - Min) + Min;
            }
            Array.Copy(first, second, first.Length);
            QuickSort(first);
            MergeSort(second);
            CollectionAssert.AreEqual(first, second);

        }
        [TestMethod]
        public void PerformanceComparisonForArraysOf1000Elements()
        {
            int Min = -158782;
            int Max = 168415;
            int[] first = new int[100000];
            Random random = new Random();
            for (int i = 0; i < first.Length; i++)
            {
                first[i] = random.Next() * (Max - Min) + Min;
            }
            var second = first.Clone() as int[];
            var third= first.Clone() as int[];
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            QuickSort(first);
            stopwatch.Stop();
            long performanceQ = stopwatch.ElapsedMilliseconds;

            stopwatch.Start();
            MergeSort(second);
            stopwatch.Stop();
            long performanceM = stopwatch.ElapsedMilliseconds;

            stopwatch.Start();
            BubbleSort(third);
            stopwatch.Stop();
            long performanceB = stopwatch.ElapsedMilliseconds;

            Assert.IsTrue((performanceQ < performanceM) && (performanceM < performanceB));
        }
    }
}
