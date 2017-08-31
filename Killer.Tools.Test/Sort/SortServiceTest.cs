using Killer.Tools.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer.Tools.Test.Sort
{
    [TestClass]
    public class SortServiceTest
    {
        [TestMethod]
        public void ShellSortTest()
        {
            int[] arr = { 1, 2, 3, 4, 42, 5, 6, 8, 1, 2, 3 };

            SortService.ShellSort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            } 
          
        }
        [TestMethod]
        public void QuickSortTest()
        {
            int[] arr = { 1, 2, 3, 4, 42, 5, 6, 8, 1, 2, 3 };
            SortService.QuickSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        [TestMethod]
        public void HeapSortTest()
        {
            int[] arr = { 1, 2, 3, 4, 42, 5, 6, 8, 1, 2, 3 ,25};
            SortService.HeapSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
