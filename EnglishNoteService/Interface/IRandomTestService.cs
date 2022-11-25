using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public interface IRandomTestService
    {
        List<int[]> getTestNumber(int len, int optionLen);
    }
}
