using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishNoteService;

namespace UnitTest
{
    [TestClass]
    public class RandomTestServiceTest
    {
        private IRandomTestService _randomTestService;
        public RandomTestServiceTest()
        {
            _randomTestService = FullService.GetService<IRandomTestService>();
        }
        [TestMethod]
        public void TestGetTestNumber()
        {
            int len = 10;

            List<int[]> testNumbers = _randomTestService.getTestNumber(len, 3);

            Assert.IsNotNull(testNumbers);

            foreach(var nums in testNumbers)
            {
                foreach(var num in nums)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }

            Assert.AreEqual(len, testNumbers.Count);
        }
    }
}
