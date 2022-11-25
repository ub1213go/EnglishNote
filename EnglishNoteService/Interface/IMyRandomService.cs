using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public interface IMyRandomService
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
    }
}
