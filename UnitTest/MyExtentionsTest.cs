using EnglishNoteService;

namespace UnitTest
{
    [TestClass]
    public class MyExtentionsTest
    {
        [TestMethod]
        public void TestReplaceOne()
        {
            Assert.AreEqual("TEST", "ITEST".replaceOnce("I", "", true));
            Assert.AreEqual("IEST", "ITEST".replaceOnce("T", "", true));
            Assert.AreEqual("ITEST", "ITEST".replaceOnce("i", "", false));
            Assert.AreEqual("ITEST", "ITEST".replaceOnce("t", "", false));
        }

        [TestMethod]
        public void TestReplaceStartWith()
        {
            Assert.AreEqual("TEST", "ITEST".replaceStartWith("I", "", true));
            Assert.AreEqual("ITEST", "ITEST".replaceStartWith("T", "", true));
            Assert.AreEqual("ITEST", "ITEST".replaceStartWith("i", "", false));
            Assert.AreEqual("ITEST", "ITEST".replaceStartWith("t", "", false));
        }
    }
}