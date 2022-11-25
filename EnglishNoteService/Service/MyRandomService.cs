using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNoteService
{
    public class MyRandomService : Random, IMyRandomService
    {
        public MyRandomService()
        {

        }

        public override int Next()
        {
            return base.Next();
        }

        public override int Next(int maxValue)
        {
            return base.Next(maxValue);
        }

        public override int Next(int minValue, int maxValue)
        {
            return base.Next(minValue, maxValue);
        }
    }
}
