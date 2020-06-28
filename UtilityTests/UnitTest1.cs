using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilite_1;


namespace UtilityTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckInsertOnMatch()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(path + @"Test_data/variant_1");
            Assert.IsTrue(dir.ReadDirectory().Length == 3);
            string[] actual = dir.ReadDirectory();
            string[] expected = new string[] { "one", "three", "two" };
            CollectionAssert.AreEqual(expected, actual, 
                        "Expected: " + string.Join(",", expected) + ", actual: " + string.Join(",", actual));
        }

        [TestMethod]
        public void CheckLength2Element()
        {
            string path= AppDomain.CurrentDomain.BaseDirectory;
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(path+@"Test_data/variant_1/one");
            Assert.IsTrue(dir.ReadDirectory().Length == 1);
        }

        [TestMethod]
        public void ComboCheck()
        {
            string path= AppDomain.CurrentDomain.BaseDirectory;
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(path+@"Test_data/variant_1/one/For test/");
            Assert.IsTrue(dir.ReadDirectory().Length == 5);
            string[] actual = dir.ReadDirectory();
            string[] expected = new string[] { "dolly", "holiday", "holy","insert","opera" };
            CollectionAssert.AreEqual(expected, actual,
                        "Expected: " + string.Join(",", expected) + ", actual: " + string.Join(",", actual));
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CheckEqualFullArray()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory+ @"Test_data/variant_1/one/For test/";
            ReturnFullArrayList fullArrayList = new ReturnFullArrayList(path);
            ReadDirrectoryAndFileName dirrectoryName = new ReadDirrectoryAndFileName(path);
        }
    }
}
