using System;
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
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(@"c:\Files\Книги\simple\");
            Assert.IsTrue(dir.ReadDirectory().Length == 3);
            string[] actual = dir.ReadDirectory();
            string[] expected = new string[] { "one", "three", "two" };
            CollectionAssert.AreEqual(expected, actual, 
                        "Expected: " + string.Join(",", expected) + ", actual: " + string.Join(",", actual));
        }

        [TestMethod]
        public void CheckLength2Element()
        {
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(@"c:\Files\Книги\simple\one\");
            Assert.IsTrue(dir.ReadDirectory().Length == 1);
        }

        [TestMethod]
        public void ComboCheck()
        {
            ReadDirrectoryAndFileName dir = new ReadDirrectoryAndFileName(@"c:\Files\Книги\simple\one\For test\");
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
            string path = @"c:\Files\Книги\simple\one\For test\";
            ReturnFullArrayList fullArrayList = new ReturnFullArrayList(path);
            ReadDirrectoryAndFileName dirrectoryName = new ReadDirrectoryAndFileName(path);
            
        }
    }
}
