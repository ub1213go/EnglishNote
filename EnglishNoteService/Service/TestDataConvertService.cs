using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public class TestDataConvertService : ITestDataConvertService
    {
        public List<EnglishData> englishData { get; set; }

        public TestDataConvertService()
        {
            englishData = new List<EnglishData>();
        }

        public List<TestData> getTestData()
        {
            var res = new List<TestData>();

            Dictionary<string, TestData> dt = new Dictionary<string, TestData>();

            foreach(var item in englishData)
            {
                if(dt.ContainsKey(item.englishName))
                {
                    dt[item.englishName].translate.Add(item.translate);
                    dt[item.englishName].translate.Add(item.pronounce);
                }
                else
                {
                    var td = new TestData()
                    {
                        englishId = item.englishId,
                        englishName = item.englishName,
                        pronounce = new List<string>() { item.pronounce },
                        translate = new List<string>() { item.translate }
                    };
                    dt.Add(item.englishName, td);
                    res.Add(td);
                }
            }

            return res;
        }
    }


}
