using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public interface IEnglishData
    {
        int englishId { get; set; }
        string englishName { get; set; }
        string translate { get; set; }
        string pronounce { get; set; }
    }
}
