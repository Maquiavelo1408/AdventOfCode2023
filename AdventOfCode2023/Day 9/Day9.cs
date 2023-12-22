using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_9
{
    static internal class Day9
    {
        public static void First()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 9\\input.txt");
            List<int> numbersToAdd = new List<int>();

            foreach (string line in lines)
            {
                List<int> sequence = line.Split(' ').ToList().Select(int.Parse).ToList();
                Dictionary<int, List<int>> diffs = new Dictionary<int, List<int>>();
                List<List<int>> list = Enumerable.Range(0, 255).Select(i => new List<int>()).ToList();
                list[0] = sequence;
                //sequence.Insert(0, 0);
                int diffNumber = 0;
                int[,] differences = new int[255, 255];
                while (list[diffNumber].Where(x => x == 0).Count() != list[diffNumber].Count)
                {
                    for (int i = 0; i < list[diffNumber].Count - 1; i++)
                    {
                        int temp = list[diffNumber][i + 1] - list[diffNumber][i];

                        list[diffNumber + 1].Add(temp);
                    }
                    diffNumber++;
                }
                var listWithNumbers = list.Where(a=> a.Count() > 0).ToList();
                int numToSum = 0;
                foreach(var i in listWithNumbers)
                {
                    numToSum += i.Last();
                }
                numbersToAdd.Add(numToSum);
            }
            Console.WriteLine(numbersToAdd.Sum());
        }
    }
}
