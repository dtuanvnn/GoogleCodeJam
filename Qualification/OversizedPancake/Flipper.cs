using System.Collections.Generic;

namespace OversizedPancake
{
    public class Flipper
    {
        public int NumberOfTestCase { get; set; }

        public List<string> StateOfPancake { get; set; }

        public List<int> FlipperSize { get; set; }
        
        public Flipper(int test, List<int> size, List<string> state)
        {
            NumberOfTestCase = test;
            FlipperSize = size;
            StateOfPancake = state;
        }
        
        private bool HappyPancakes(string pancakes)
        {
            return !pancakes.Contains("-");
        }

        private string ChangeState(string pancakes, int startPos, int length)
        {
            var stringArr = pancakes.ToCharArray();
            for (int i = startPos; i < startPos + length; i++)
            {
                var state = stringArr[i];
                stringArr[i] = state == '-' ? '+' : '-';
            }
            return new string(stringArr);
        }

        private int DoFlip(int flipperSize, string pancakes)
        {
            var index = pancakes.IndexOf('-');
            if (index < 0)
            {
                return 0;
            }

            var step = 0;
            while (index > -1 && index <= pancakes.Length - flipperSize)
            {
                pancakes = ChangeState(pancakes, index, flipperSize);
                index = pancakes.IndexOf('-');
                step++;
            }

            if (HappyPancakes(pancakes))
            {
                return step;
            }

            return -1;
        }

        public List<int> DoWork()
        {
            var stepResults = new List<int>();
            for (int i = 0; i < NumberOfTestCase; i++)
            {
                stepResults.Add(DoFlip(FlipperSize[i], StateOfPancake[i]));
            }
            return stepResults;
        }
    }
}
