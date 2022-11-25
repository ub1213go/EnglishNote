using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishNoteService;

namespace UnitTest
{
    [TestClass]
    public class FullServiceTest
    {
        public FullServiceTest()
        {
            
        }
        [TestMethod]
        public void TestGetService()
        {
            IMyRandomService myrs = FullService.GetService<IMyRandomService>();

            Assert.IsNotNull(myrs);

            IRandomTestService myrs2 = FullService.GetService<IRandomTestService>();

            Assert.IsNotNull(myrs2);
        }
    }
}
