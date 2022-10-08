using EnglishNote.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNote.Lab
{
    public class TEST
    {
        public List<English> EnglishTestData { get; set; }
        public TEST()
        {
            #region 單字新增
            EnglishTestData = new List<English>();
            EnglishTestData.Add(new English()
            {
                EnglishName = "apple",
                EnglishType = "single",
                CreateDatetime = DateTime.Now,
                IsVisible = true
            });
            EnglishTestData.Add(new English()
            {
                EnglishName = "banana",
                EnglishType = "single",
                CreateDatetime = DateTime.Now,
                IsVisible = true
            });
            EnglishTestData.Add(new English()
            {
                EnglishName = "flower",
                EnglishType = "single",
                CreateDatetime = DateTime.Now,
                IsVisible = true
            });
            EnglishTestData.Add(new English()
            {
                EnglishName = "juice",
                EnglishType = "single",
                CreateDatetime = DateTime.Now,
                IsVisible = true
            });
            #endregion
        }
    }
    
}
