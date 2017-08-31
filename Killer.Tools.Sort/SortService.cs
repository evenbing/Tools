using System;

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
        public static void ShellSort<T>(T[] arr) where T : IComparable<T>
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
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void QuickSort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            var start = 0;
            var end = arr.Length - 1;
            QuickSortmid(arr, start, end);
        }
        private static void QuickSortmid<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            var markIndex = QuickSort<T>(arr, start, end);
            if (markIndex - start > 1)
            {
                QuickSortmid(arr, start, markIndex - 1);
            }
            if (end - markIndex > 1)
            {
                QuickSortmid(arr, markIndex + 1, end);
            }
        }
        private static int QuickSort<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            var temp = arr[start];
            while (start < end)
            {
                while (start < end && arr[end].CompareTo(temp) >= 0)
                {
                    end--;
                }
                arr[start] = arr[end];
                while (start < end && arr[start].CompareTo(temp) <= 0)
                {
                    start++;
                }
                arr[end] = arr[start];
            }
            arr[start] = temp;
            return start;
        }
        /// <summary>
        /// 队排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void HeapSort<T>(T[] arr) where T : IComparable<T>
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            for (int i = (arr.Length / 2 - 1); i >= 0; i--)
            {
                HeapSort(arr, i, arr.Length - 1);
            }
            for (int i = arr.Length - 1; i > 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapSort(arr, 0, i-1);
            }
        }

        private static void HeapSort<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            var i = start;
            var j = 2 * start + 1;
            var temp = arr[i];
            while (j <= end)
            {
                if (j < end && arr[j].CompareTo(arr[j + 1]) < 0)
                {
                    j++;
                }
                if (temp.CompareTo(arr[j]) < 0)
                {
                    arr[i] = arr[j]; // 交换根节点与其孩子节点
                    i = j;  // 以交换后的孩子节点作为根节点继续调整其子树
                    j = 2 * i + 1;  // j指向交换后的孩子节点的左孩子
                }
                else
                {
                    break;
                }
            }
            arr[i] = temp;
        }
    }
}
