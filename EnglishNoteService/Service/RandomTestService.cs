using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records;

namespace EnglishNoteService
{
    public class RandomTestService : IRandomTestService
    {
        private IMyRandomService _random;
        public List<int[]> testList { get; set; }
        public int currentIndex { get; set; }

        public RandomTestService()
        {
            IMyRandomService random = FullService.GetService<IMyRandomService>();

            init(random);
        }

        public void init(IMyRandomService random)
        {
            if (random == null)
            {
                throw new ArgumentNullException();
            }
            _random = random;
        }

        public List<int[]> getTestNumber(int len, int optionLen)
        {
            if(optionLen < 1)
            {
                throw new Exception("選項長度不能小於 1");
            }

            currentIndex = 0;
            testList = new List<int[]>();
            List<int> box = new List<int>();
            if (len <= 3) return testList;

            for(int i = 0; i < len; i++)
            {
                box.Add(i);
            }

            while (box.Count > 0)
            {
                int stepRandom = _random.Next(box.Count - 1);

                List<int> options = new List<int>();
                options.Add(box[stepRandom]);
                int rn;
                int answerOptionIndex = _random.Next(optionLen);
                for(int i = 0; i < optionLen; i++)
                {
                    if( i == answerOptionIndex)
                    {
                        options.Add(box[stepRandom]);
                        continue;
                    }

                    do
                    {
                        rn = _random.Next(len);
                    }
                    while (options.Contains(rn));
                    options.Add(rn);
                }
                

                testList.Add(options.ToArray());

                box.RemoveAt(stepRandom);
            }

            return testList;
        }

        
    }
}
