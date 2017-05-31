using OversizedPancake;
using System.Collections.Generic;
using System.IO;

namespace PancakeFlipper
{
    class Program
    {
        private static List<string> _states = new List<string>();
        private static List<int> _flipperSizes = new List<int>();
        private static int _testCases;

        static void Main(string[] args)
        {
            ReadFile(@"A-small-practice.in");
            var flipper = new Flipper(_testCases, _flipperSizes, _states);
            var steps = flipper.DoWork();
            WriteFile(@"A-small-practice.out", steps);

            _testCases = 0;
            _flipperSizes = new List<int>();
            _states = new List<string>();

            ReadFile(@"A-large-practice.in");
            flipper.NumberOfTestCase = _testCases;
            flipper.StateOfPancake = _states;
            flipper.FlipperSize = _flipperSizes;
            steps = flipper.DoWork();
            WriteFile(@"A-large-practice.out", steps);
        }

        static void ReadFile(string filePath)
        {
            var file = new StreamReader(filePath);
            _testCases = int.Parse(file.ReadLine());
            for (int i = 0; i < _testCases; i++)
            {
                var line = file.ReadLine();
                var subString = line.Split(' ');

                _states.Add(subString[0]);
                _flipperSizes.Add(int.Parse(subString[1]));
            }

            file.Close();
        }

        static void WriteFile(string filePath, List<int> steps)
        {
            using (StreamWriter file = new StreamWriter(filePath, true))
            {
                for (int i = 0; i < _testCases; i++)
                {
                    var result = steps[i].ToString();
                    if (steps[i] < 0)
                    {
                        result = "IMPOSSIBLE";
                    }

                    file.WriteLine("Case #{0}: {1}", i + 1, result);
                }
            }
        }
    }
}
