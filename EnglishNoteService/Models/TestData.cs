using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public class TestData
    {
        public int englishId { get; set; }
        public string englishName { get; set; }
        public List<string> translate { get; set; }
        public List<string> pronounce { get; set; }
    }
}
