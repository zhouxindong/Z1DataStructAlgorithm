using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z1DataStructAlgorithm.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Z1DataStructAlgorithm.List.Tests
{
    [TestClass()]
    public class SiLinkedListTests
    {
        [TestMethod()]
        public void GetLengthTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            Assert.AreEqual(0, linked_list.GetLength());
            linked_list.Append(1);
            Assert.AreEqual(1, linked_list.GetLength());
            linked_list.Clear();
            Assert.AreEqual(0, linked_list.GetLength());
        }

        [TestMethod()]
        public void AppendTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            for (var i = 0; i < 5; i++)
            {
                linked_list.Append(i);
            }
            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, linked_list.GetElem(i));
            }
        }

        [TestMethod()]
        public void InsertTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            linked_list.Insert(1, 0);
            linked_list.Insert(2, 0);
            linked_list.Insert(3, 2);
            linked_list.Insert(4, 10);
            Assert.AreEqual(2, linked_list.GetElem(0));
            Assert.AreEqual(1, linked_list.GetElem(1));
            Assert.AreEqual(3, linked_list.GetElem(2));
            Assert.AreEqual(4, linked_list.GetElem(3));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                linked_list.Insert(i, 0);
            }
            linked_list.Delete(0);
            linked_list.Delete(1);
            linked_list.Delete(2);
            Assert.AreEqual(2, linked_list.GetLength());
            Assert.AreEqual(3, linked_list.GetElem(0));
            Assert.AreEqual(1, linked_list.GetElem(1));
        }

        [TestMethod()]
        public void LocateTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                linked_list.Append(i);
            }
            Assert.AreEqual(-1, linked_list.Locate(5));
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, linked_list.Locate(i));
            }
        }

        [TestMethod()]
        public void ReverseTest()
        {
            ILinearList<int> linked_list = new SiLinkedList<int>();
            Assert.IsTrue(linked_list.IsEmpty());
            linked_list.Reverse();
            Assert.IsTrue(linked_list.IsEmpty());
            linked_list.Append(1);
            Assert.AreEqual(1, linked_list.GetElem(0));
            Assert.AreEqual(1, linked_list.GetLength());
            linked_list.Reverse();
            Assert.AreEqual(1, linked_list.GetElem(0));
            Assert.AreEqual(1, linked_list.GetLength());

            linked_list.Clear();

            for (int i = 0; i < 5; i++)
            {
                linked_list.Append(i + 1);
            }
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(i+1, linked_list.GetElem(i));
            }
            linked_list.Reverse();
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(5 - i, linked_list.GetElem(i));
            }
        }
    }
}