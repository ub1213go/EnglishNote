using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public interface ITestDataConvertService
    {
        List<EnglishData> englishData { get; set; }

        List<TestData> getTestData();
    }
}
