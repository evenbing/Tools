using System;
using System.Collections.Generic;
using System.Text;

namespace Killer.Tools.Sort
{
    /// <summary>
    /// 排序服务类
    /// </summary>
    public class SortService
    {
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void ShellSort<T>(T[] arr)where T :IComparable<T>
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            int j;
            for (int d = arr.Length / 2; d >= 1; d = d / 2)
            {
                for (int i = d; i < arr.Length; i++)
                {
                    j = i - d;
                    T temp = arr[i];

                    while (j >= 0 && temp.CompareTo(arr[j]) < 0)
                    {
                        arr[j + d] = arr[j];
                        j = j - d;
                    }
                    arr[j + d] = temp;
                }
            }
        }
    }
}
