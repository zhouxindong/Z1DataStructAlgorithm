using System;
using Z1DataStructAlgorithm.List;

namespace Z1DataStructAlgorithm.Sort
{
    public class SimpleSort
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="sq_list"></param>
        public void InsertSort(SeqList<int> sq_list)
        {
            for (var i = 1; i < sq_list.GetLength(); ++i)
            {
                if (sq_list[i] < sq_list[i - 1])
                {
                    var tmp = sq_list[i];
                    int j;
                    for (j = i - 1; j >= 0 && tmp < sq_list[j]; --j)
                    {
                        sq_list[j + 1] = sq_list[j];
                    }
                    sq_list[j + 1] = tmp;
                }
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="sq_list"></param>
        public void BubbleSort(SeqList<int> sq_list)
        {
            for (var i = 0; i < sq_list.GetLength(); ++i)
            {
                for (var j = sq_list.Last - 1; j >= i; --j)
                {
                    if (sq_list[j + 1] >= sq_list[j]) continue;
                    var tmp = sq_list[j + 1];
                    sq_list[j + 1] = sq_list[j];
                    sq_list[j] = tmp;
                }
            }
        }

        /// <summary>
        /// 简单选择排序
        /// </summary>
        /// <param name="sq_list"></param>
        public void SimpleSelectSort(SeqList<int> sq_list)
        {
            for (var i = 0; i < sq_list.Last; ++i)
            {
                var t = i;
                for (var j = i + 1; j <= sq_list.Last; ++j)
                {
                    if (sq_list[t] > sq_list[j])
                    {
                        t = j;
                    }
                }
                var tmp = sq_list[i];
                sq_list[i] = sq_list[t];
                sq_list[t] = tmp;
            }
        }

        private int Division(SeqList<int> list, int left, int right)
        {
            while (left < right)
            {
                int num = list[left]; //将首元素作为枢轴
                if (num > list[left + 1])
                {
                    list[left] = list[left + 1];
                    list[left + 1] = num;
                    left++;
                }
                else
                {
                    int temp = list[right];
                    list[right] = list[left + 1];
                    list[left + 1] = temp;
                    right--;
                }
            }
            return left; //指向的此时枢轴的位置
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void QuickSort(SeqList<int> list, int left, int right)
        {
            if (left < right)
            {
                int i = Division(list, left, right);
                //对枢轴的左边部分进行排序
                QuickSort(list, i + 1, right);
                //对枢轴的右边部分进行排序
                QuickSort(list, left, i - 1);
            }
        }

        private void CreateHeap(SeqList<int> sq_list, int low, int high)
        {
            if ((low >= high) || (high > sq_list.Last)) return;
            for (var i = high/2; i >= low; --i)
            {
                var k = i;
                var j = 2*k + 1;
                var tmp = sq_list[i];
                while (j <= high)
                {
                    if ((j < high) && (j + 1 <= high)
                        && (sq_list[j] < sq_list[j + 1]))
                    {
                        ++j;
                    }
                    if (tmp < sq_list[j])
                    {
                        sq_list[k] = sq_list[j];
                        k = j;
                        j = 2*k + 1;
                    }
                    else
                    {
                        j = high + 1;
                    }
                }
                sq_list[k] = tmp;
            }
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="sq_list"></param>
        public void HeapSort(SeqList<int> sq_list)
        {
            CreateHeap(sq_list, 0, sq_list.Last);
            for (var i = sq_list.Last; i > 0; --i)
            {
                var tmp = sq_list[0];
                sq_list[0] = sq_list[i];
                sq_list[i] = tmp;
                CreateHeap(sq_list, 0, i - 1);
            }
        }

        public void MergeSort(SeqList<int> sq_list, int low, int high)
        {
            try
            {
                if (low >= high) return;
                var mid = (low + high) / 2;   //子表划分的位置
                MergeSort(sq_list, low, mid);   //对划分出来的左侧子表进行递归划分
                MergeSort(sq_list, mid + 1, high);    //对划分出来的右侧子表进行递归划分
                MergeSortCore(sq_list, low, mid, high); //对左右子表进行有序的整合（归并排序的核心部分）
            }
            catch (Exception)
            { }
        }

        //归并排序的核心部分：将两个有序的左右子表（以mid区分），合并成一个有序的表
        private void MergeSortCore(SeqList<int> sq_list, int first, int mid, int last)
        {
            try
            {
                int indexA = first; //左侧子表的起始位置
                int indexB = mid + 1;   //右侧子表的起始位置
                int[] temp = new int[last + 1]; //声明数组（暂存左右子表的所有有序数列）：长度等于左右子表的长度之和。
                int tempIndex = 0;
                while (indexA <= mid && indexB <= last) //进行左右子表的遍历，如果其中有一个子表遍历完，则跳出循环
                {
                    if (sq_list[indexA] <= sq_list[indexB]) //此时左子表的数 <= 右子表的数
                    {
                        temp[tempIndex++] = sq_list[indexA++];    //将左子表的数放入暂存数组中，遍历左子表下标++
                    }
                    else//此时左子表的数 > 右子表的数
                    {
                        temp[tempIndex++] = sq_list[indexB++];    //将右子表的数放入暂存数组中，遍历右子表下标++
                    }
                }
                //有一侧子表遍历完后，跳出循环，将另外一侧子表剩下的数一次放入暂存数组中（有序）
                while (indexA <= mid)
                {
                    temp[tempIndex++] = sq_list[indexA++];
                }
                while (indexB <= last)
                {
                    temp[tempIndex++] = sq_list[indexB++];
                }

                //将暂存数组中有序的数列写入目标数组的制定位置，使进行归并的数组段有序
                tempIndex = 0;
                for (int i = first; i <= last; i++)
                {
                    sq_list[i] = temp[tempIndex++];
                }
            }
            catch (Exception)
            { }
        }

        public void RadixSort(SeqList<int> sq_list, int array_x = 10, int array_y = 100)
        {
            for (int i = 0; i < array_x/* 最大数字不超过999999999...(array_x个9) */; i++)
            {
                int[,] bucket = new int[array_x, array_y];
                foreach (var item in sq_list.Data)
                {
                    int temp = (item / (int)Math.Pow(10, i)) % 10;
                    for (int l = 0; l < array_y; l++)
                    {
                        if (bucket[temp, l] == 0)
                        {
                            bucket[temp, l] = item;
                            break;
                        }
                    }
                }
                for (int o = 0, x = 0; x < array_x; x++)
                {
                    for (int y = 0; y < array_y; y++)
                    {
                        if (bucket[x, y] == 0) continue;
                        sq_list[o++] = bucket[x, y];
                    }
                }
            }
        }
    }
}