using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.List;

namespace Z1DataStructAlgorithm.List.Tests
{
    [TestClass()]
    public class SeqListTests
    {
        [TestMethod()]
        public void IsEmptyTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            Assert.IsTrue(seq_list.IsEmpty());
            seq_list.Append(0);
            Assert.IsFalse(seq_list.IsEmpty());
            seq_list.Append(1);
            Assert.IsFalse(seq_list.IsEmpty());
            seq_list.Clear();
            Assert.IsTrue(seq_list.IsEmpty());
        }

        [TestMethod()]
        public void IsFullTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            Assert.IsFalse(seq_list.IsFull());
            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
                if (i == 4)
                    Assert.IsTrue(seq_list.IsFull());
                else
                    Assert.IsFalse(seq_list.IsFull());
            }
            seq_list.Clear();
            Assert.IsFalse(seq_list.IsFull());
        }

        [TestMethod()]
        public void AppendTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
            }
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, seq_list.GetElem(i));
            }
        }

        [TestMethod()]
        //[ExpectedException(typeof(IndexOutOfRangeException))]
        [ExpectedException(typeof(InvalidOperationException))] // only one ExpectedException can be used
        public void InsertTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            seq_list.Insert(0, 10);
            Assert.AreEqual(0, seq_list.GetElem(0));
            Assert.AreEqual(1, seq_list.GetLength());
            Assert.IsFalse(seq_list.IsEmpty());
            Assert.IsFalse(seq_list.IsFull());

            seq_list.Insert(1, 0);
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(0, seq_list.GetElem(1));
            Assert.AreEqual(2, seq_list.GetLength());

            seq_list.Insert(2, seq_list.GetLength());
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(0, seq_list.GetElem(1));
            Assert.AreEqual(2, seq_list.GetElem(2));
            Assert.AreEqual(3, seq_list.GetLength());

            seq_list.Insert(4, 1);
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(4, seq_list.GetElem(1));
            Assert.AreEqual(0, seq_list.GetElem(2));
            Assert.AreEqual(2, seq_list.GetElem(3));
            Assert.AreEqual(4, seq_list.GetLength());

            //seq_list.Insert(4, -1);
            //seq_list.Insert(5, 5);

            seq_list.Append(9);
            Assert.IsTrue(seq_list.IsFull());

            seq_list.Insert(10, 2);
            Assert.AreEqual(5, seq_list.GetLength());
            seq_list.Insert(12, 3);
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(4, seq_list.GetElem(1));
            Assert.AreEqual(0, seq_list.GetElem(2));
            Assert.AreEqual(2, seq_list.GetElem(3));
            Assert.AreEqual(9, seq_list.GetElem(4));
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            seq_list.Delete(0);

            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
            }

            seq_list.Delete(4);
            Assert.AreEqual(4, seq_list.GetLength());
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i, seq_list.GetElem(i));
            }
            seq_list.Delete(0);
            Assert.AreEqual(3, seq_list.GetLength());
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(2, seq_list.GetElem(1));
            Assert.AreEqual(3, seq_list.GetElem(2));

            seq_list.Delete(1);
            Assert.AreEqual(2, seq_list.GetLength());
            Assert.AreEqual(1, seq_list.GetElem(0));
            Assert.AreEqual(3, seq_list.GetElem(1));
        }

        [TestMethod()]
        public void LocateTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
            }

            Assert.AreEqual(-1, seq_list.Locate(5));
            Assert.AreEqual(0, seq_list.Locate(0));
            Assert.AreEqual(1, seq_list.Locate(1));
            Assert.AreEqual(2, seq_list.Locate(2));
            Assert.AreEqual(3, seq_list.Locate(3));
            Assert.AreEqual(4, seq_list.Locate(4));
        }

        [TestMethod()]
        public void ReverseTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            seq_list.Reverse();
            Assert.IsTrue(seq_list.IsEmpty());
            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
            }

            seq_list.Reverse();
            Assert.AreEqual(4, seq_list.GetElem(0));
            Assert.AreEqual(3, seq_list.GetElem(1));
            Assert.AreEqual(2, seq_list.GetElem(2));
            Assert.AreEqual(1, seq_list.GetElem(3));
            Assert.AreEqual(0, seq_list.GetElem(4));

            seq_list = new SeqList<int>(1);
            seq_list.Append(1);
            seq_list.Reverse();
            Assert.AreEqual(1, seq_list.GetElem(0));

            seq_list = new SeqList<int>(10);
            for (int i = 0; i < 10; i++)
            {
                seq_list.Append(i);
            }
            seq_list.Reverse();
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(9-i, seq_list.GetElem(i));
            }
        }
    }
}

namespace Z1DataStructAlgorithmTests.List.Tests
{
    [TestClass()]
    public class SeqListTests
    {
        [TestMethod()]
        public void SeqListTest()
        {
            var seq_list = new SeqList<int>(5);
            Assert.AreEqual(5, seq_list.MaxSize);
            Assert.AreEqual(-1, seq_list.Last);
        }

        [TestMethod()]
        public void GetLengthTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            Assert.AreEqual(0, seq_list.GetLength());
            seq_list.Append(1);
            Assert.AreEqual(1, seq_list.GetLength());
            seq_list.Append(1);
            Assert.AreEqual(2, seq_list.GetLength());
            seq_list.Delete(0);
            Assert.AreEqual(1, seq_list.GetLength());
        }

        [TestMethod()]
        public void ClearTest()
        {
            ILinearList<int> seq_list = new SeqList<int>(5);
            for (int i = 0; i < 5; i++)
            {
                seq_list.Append(i);
            }

            Assert.AreEqual(5, seq_list.GetLength());
            seq_list.Clear();
            Assert.AreEqual(0, seq_list.GetLength());
            Assert.AreEqual(-1, seq_list.Last);
        }
    }
}