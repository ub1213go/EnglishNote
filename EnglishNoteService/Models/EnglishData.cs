﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public class EnglishData : IEnglishData
    {
        public int englishId { get; set; }
        public string englishName { get; set; }
        public string translate { get; set; }
        public string pronounce { get; set; }
        public int appearTimes { get; set; }
        public int finishTimes { get; set; }
    }
}
