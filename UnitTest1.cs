using ClassLibrary10Lab;
using System.Drawing;
using Лабораторная_работа_12_2;

using Лабораторная_работа_12_4;
namespace Test12_4Lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreating()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>();
            Watch watch = new Watch();
            //Act
            collection.Add(watch);
            //Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>();
            Watch watch = new Watch();
            //Act
            collection.Add(watch);
            bool check = collection.Contains(watch);
            //Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>();
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            collection.Add(watch);
            collection.Add(watch2);
            collection.Remove(watch2);
            //Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void TestAddItem()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>(2);
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            collection.Add(watch);
            collection.Add(watch2);
            //Assert
            Assert.AreEqual(2, collection.Count);
        }

        [TestMethod]
        public void TestCopyTo()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>(5);
            for (int i = 0; i < 5; i++)
            {
                Watch c = new Watch();
                c.RandomInit();
                collection.AddItem(c);
            }
            //Act
            Watch[] arr = new Watch[collection.Count];
            collection.CopyTo(arr, 0);
            //Assert
            Assert.AreEqual(5, arr.Length);
        }
        [TestMethod]
        public void TestClear()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>(5);
            for (int i = 0; i < 5; i++)
            {
                Watch c = new Watch();
                c.RandomInit();
                collection.AddItem(c);
            }
            //Act
            collection.Clear();
            //Assert
            Assert.IsNull(collection);
        }

        [TestMethod]
        public void TestReadOnly()
        {
            //Arrange
            MyCollection<Watch> collection = new MyCollection<Watch>(5);
            //Act
            bool f = collection.IsReadOnly();
            //Assert
            Assert.IsFalse(f);
        }
    }
}