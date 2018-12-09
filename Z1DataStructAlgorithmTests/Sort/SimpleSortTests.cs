using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Z1DataStructAlgorithm.List;

namespace Z1DataStructAlgorithm.Sort.Tests
{
    [TestClass()]
    public class SimpleSortTests
    {
        [TestMethod()]
        public void InsertSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().InsertSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().InsertSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().InsertSort(sq_list);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }

        [TestMethod()]
        public void BubbleSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().BubbleSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().BubbleSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().BubbleSort(sq_list);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }

        [TestMethod()]
        public void SimpleSelectSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().SimpleSelectSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().SimpleSelectSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().SimpleSelectSort(sq_list);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }

        [TestMethod()]
        public void QuickSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().QuickSort(sq_list, 0, 4);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().QuickSort(sq_list, 0, 4);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().QuickSort(sq_list, 0, 7);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }

        [TestMethod]
        public void HeapSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().HeapSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().HeapSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().HeapSort(sq_list);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);

        }

        [TestMethod()]
        public void MergeSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().MergeSort(sq_list, 0, sq_list.Last);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().MergeSort(sq_list, 0, sq_list.Last);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().MergeSort(sq_list, 0, sq_list.Last);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }

        [TestMethod()]
        public void RadixSortTest()
        {
            var sq_list = new SeqList<int>(5);
            sq_list.Append(5);
            sq_list.Append(4);
            sq_list.Append(3);
            sq_list.Append(2);
            sq_list.Append(1);
            new SimpleSort().RadixSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list[0] = 3;
            sq_list[1] = 2;
            sq_list[2] = 4;
            sq_list[3] = 1;
            sq_list[4] = 5;
            new SimpleSort().RadixSort(sq_list);
            Assert.AreEqual(5, sq_list.GetLength());
            Assert.AreEqual(1, sq_list[0]);
            Assert.AreEqual(2, sq_list[1]);
            Assert.AreEqual(3, sq_list[2]);
            Assert.AreEqual(4, sq_list[3]);
            Assert.AreEqual(5, sq_list[4]);

            sq_list = new SeqList<int>(100);
            sq_list.Append(42);
            sq_list.Append(20);
            sq_list.Append(17);
            sq_list.Append(27);
            sq_list.Append(13);
            sq_list.Append(8);
            sq_list.Append(17);
            sq_list.Append(48);
            new SimpleSort().RadixSort(sq_list);
            Assert.AreEqual(8, sq_list.GetLength());
            Assert.AreEqual(8, sq_list[0]);
            Assert.AreEqual(13, sq_list[1]);
            Assert.AreEqual(17, sq_list[2]);
            Assert.AreEqual(17, sq_list[3]);
            Assert.AreEqual(20, sq_list[4]);
            Assert.AreEqual(27, sq_list[5]);
            Assert.AreEqual(42, sq_list[6]);
            Assert.AreEqual(48, sq_list[7]);
        }
    }
}