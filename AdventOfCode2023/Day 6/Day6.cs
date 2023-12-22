using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_6
{
    static internal class Day6
    {
        public static void FirstPart()
        {
            Regex regex = new Regex(" +");
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 6\\input.txt");
            string timeLine = lines[0].Split(':')[1].Trim();
            string distanceLine = lines[1].Split(':')[1].Trim();
            List<int> records = new List<int>();
            List<int> numberOfRec = new List<int>();
            var splittedTime = Regex.Replace(timeLine, " +", " ").Split(' ');
            var splittedDistance = Regex.Replace(distanceLine, " +", " ").Split(' ');

            var timeInt = Array.ConvertAll(splittedTime, s => int.Parse(s));
            var distanceInt = Array.ConvertAll(splittedDistance, s => int.Parse(s));
            for (int i = 0; i < timeInt.Length; i++)
            {
                int numberRecods = 0;
                for (int j = 0; j <= timeInt[i]; j++)
                {
                    var currentRecord = j * (timeInt[i] - j);
                    if (currentRecord > distanceInt[i])
                    {
                        records.Add(currentRecord);
                        numberRecods++;
                    }
                }
                numberOfRec.Add(numberRecods);
            }
            int tolta = numberOfRec.Aggregate((x, y) => x * y);
            Console.WriteLine(tolta.ToString());
        }
        public static void SecondPart()
        {
            Regex regex = new Regex(" +");
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 6\\input.txt");
            long timeLine = long.Parse(Regex.Replace(lines[0].Split(':')[1], " +", ""));
            long distanceLine = long.Parse(Regex.Replace(lines[1].Split(':')[1], " +", ""));
            List<int> records = new List<int>();
            List<int> numberOfRec = new List<int>();

            int numberRecods = 0;
            for (int j = 0; j <= timeLine; j++)
            {
                var currentRecord = j * (timeLine - j);
                if (currentRecord > distanceLine)
                {
                    numberRecods++;
                }
            }
            numberOfRec.Add(numberRecods);

            int tolta = numberOfRec.Aggregate((x, y) => x * y);
            Console.WriteLine(tolta.ToString());
        }
    }
}
