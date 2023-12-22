using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_8
{
    internal static class Day8
    {

        public static void First()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 8\\input.txt");
            string steps = lines[0].Replace("L", "0").Replace("R", "1");
            string currentPos = "AAA";
            long totalSteps = 0;
            Dictionary<string, string[]> locations = new Dictionary<string, string[]>();
            for (int i = 2; i < lines.Length; i++)
            {
                var loc = lines[i].Split('=')[0].Trim();
                var nextPos = lines[i].Split('=')[1].Trim().Substring(1).Replace(")","");
                locations.Add(loc, new string[] { nextPos.Split(',')[0], nextPos.Split(',')[1].Trim() });
            }
            do
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    int index = Convert.ToInt32(steps[i].ToString());
                    totalSteps++;
                    currentPos = locations[currentPos][index];
                }
            } while (currentPos != "ZZZ");
            
            Console.WriteLine(totalSteps);
        }
        static int gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int lcm(int a, int b)
        {
            return (a / gcf(a, b)) * b;
        }
        public static void Second()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 8\\input.txt");
            string steps = lines[0].Replace("L", "0").Replace("R", "1");
            string currentPos = "AAA";
            long totalSteps = 0;
            Dictionary<string, string[]> locations = new Dictionary<string, string[]>();
            for (int i = 2; i < lines.Length; i++)
            {
                var loc = lines[i].Split('=')[0].Trim();
                var nextPos = lines[i].Split('=')[1].Trim().Substring(1).Replace(")", "");
                locations.Add(loc, new string[] { nextPos.Split(',')[0], nextPos.Split(',')[1].Trim() });
            }
            var startingPoints = locations.Keys.Where(a => a.EndsWith('A')).ToList();
            var endingPoints = locations.Keys.Where(a=> a.EndsWith("Z")).ToList();
            List<string> points = new List<string>();
            foreach (var item in startingPoints)
            {
                points.Add(item);
            }

            do
            {
                for (int i = 0; i < steps.Length; i++)
                {
                    int index = Convert.ToInt32(steps[i].ToString());
                    totalSteps++;
                    for(int j = 0; j < startingPoints.Count; j++)
                    {
                        points[j] = locations[points[j]][index];
                    }
                }
            } while (points.Where(a=> a.EndsWith('Z')).ToList().Count != endingPoints.Count);

            Console.WriteLine(totalSteps);
        }
    }
}
