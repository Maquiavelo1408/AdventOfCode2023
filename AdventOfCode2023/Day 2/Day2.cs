using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_2
{
    internal static class Day2
    {
        public static void Second()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 2\\input.txt");
            int totalId = 0;
            int totalPower = 0;
            foreach (string line in lines)
            {
                string[] separators = line.Split(':');
                string gameId = separators[0].Trim().Split(' ')[1];
                string[] sets = separators[1].Split(';');
                Dictionary<string, int> totalDice = new Dictionary<string, int>()
                {
                    {"blue", 0 },
                    {"red", 0 },
                    {"green", 0 }
                };
                bool isValid = true;
                for (int i = 0; i < sets.Length; i++)
                {
                    string[] diceType = sets[i].Split(",");
                    for (int j = 0; j < diceType.Length; j++)
                    {
                        string[] diceInfo = diceType[j].Trim().Split(" ");
                        int diceCount = Convert.ToInt32(diceInfo[0]);
                        if (diceCount> totalDice[diceInfo[1]]) {
                            totalDice[diceInfo[1]] = diceCount;
                        }
                        /*switch (diceInfo[1])
                        {
                            case "blue":
                                if (Convert.ToInt32(diceInfo[0])>14)
                                    isValid = false;
                                break;
                            case "green":
                                if (Convert.ToInt32(diceInfo[0]) > 13)
                                    isValid = false;
                                break;
                            case "red":
                                if (Convert.ToInt32(diceInfo[0]) > 12)
                                    isValid = false;
                                break;
                        }*/
                    }
                }
                int power = totalDice["blue"] * totalDice["red"] * totalDice["green"];
                totalPower += power;
                /*if (isValid)
                    totalId += Convert.ToInt32(gameId);*/



            }
            Console.WriteLine(totalPower);
            //Console.WriteLine(totalId.ToString());
        }
    }
}
