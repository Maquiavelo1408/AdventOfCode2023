using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_4
{
    public static class Day4
    {
        public static void SecondPart()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 4\\input.txt");
            int total = 0;
            for(int i= 0; i < lines.Length; i++) 
            {
                string line = lines[i];
                string[] splittedOriginal = line.Split('|');
                string strWinningNumber = splittedOriginal[0];
                string strSetNumbers = line.Split("|")[1].Substring(1);
                string strCards = strWinningNumber.Split(':')[1].TrimEnd().Substring(1);
                var listWinning = StringToList(strCards);
                var totalFinds = StringToList(strSetNumbers);
                var winners = totalFinds.Intersect(listWinning).ToList();

                var temp = Analyze(winners.Count, lines, i);
                total += temp;
            }
            Console.WriteLine(total);
        }

        static int Analyze(int nextLine, string[] lines, int currentLine)
        {
            if (nextLine < 0 || nextLine >= lines.Length)
                return 0;

            int total = 0;
            string line = lines[nextLine+currentLine];

            string[] parts = line.Split('|');
            if (parts.Length < 2) return 0;

            string strWinningNumber = parts[0];
            string strSetNumbers = parts[1].Substring(1);

            var listWinning = StringToList(strWinningNumber);
            var totalFinds = StringToList(strSetNumbers);

            var winners = totalFinds.Intersect(listWinning).ToList();
            if (winners.Count > 0)
            {
                total += winners.Count;
                total += Analyze(nextLine - 1, lines, currentLine);
            }

            return total + Analyze(nextLine - 1, lines, currentLine);
        }
        public static void FirstPart()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 4\\input.txt");
            int total = 0;
            foreach (string line in lines)
            {
                string[] splittedOriginal = line.Split('|');
                string strWinningNumber = splittedOriginal[0];
                string strSetNumbers = line.Split("|")[1].Substring(1);
                string strCards = strWinningNumber.Split(':')[1].TrimEnd().Substring(1);
                var listWinning = StringToList(strCards);
                var totalFinds = StringToList(strSetNumbers);
                var winner = totalFinds.Intersect(listWinning).ToList();
                if (winner.Count > 0)
                {
                    total += CalculateResult(winner.Count);
                }
            }
            Console.WriteLine(total);
        }

        static List<int> StringToList(string str)
        {
            List<int> result = new List<int>();
            for(int i = 0; i < str.Length; i+=3)
            {
                int res = 0;
                if(int.TryParse(str[i].ToString() + str[i + 1].ToString(), out res))
                {
                    result.Add(res);
                }
                
            }
            return result;
        }
        static  int CalculateResult(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return (int)Math.Pow(2, n - 1);
            
        }
    }
}
