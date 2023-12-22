using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_1
{
    internal static class Day1
    {
        public static void First() {
            Regex expression = new Regex("(one|two|three|four|five|six|seven|eight|nine|zero|1|2|3|4|5|6|7|8|9|0|oneight|twone|threeight|fiveight|sevenine|eightwo|eighthree|nineight)");
            Regex inversedExpresion = new Regex("(eno|owt|eerht|ruof|evif|xis|neves|thgie|enin|1|2|3|4|5|6|7|8|9)");
            Regex combination = new Regex("(oneight|twone|threeight|fiveight|sevenine|eightwo|eighthree|nineight)");
            Dictionary<string,string> exceptions = new Dictionary<string, string>()
            {
                { "oneight","8"},
                { "twone", "1" },
                { "threeight", "8" },
                { "fiveight", "8" },
                { "sevenine", "9" },
                { "eightwo", "2" },
                { "eighthree", "3" },
                    { "nineight", "8" }
            };
            List<int> numbers = new List<int>();
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 1\\Input.txt");
            foreach(string line in lines){
                string calibrationValue = "";
                var matches = expression.Matches(line);
                char[] stringArray = line.ToCharArray();
                Array.Reverse(stringArray);
                string reversedString = new string(stringArray);

                var inversedMatches = inversedExpresion.Matches(reversedString);
                var firstMatch = matches.First().Value;
                var lastMatch = inversedMatches.First().Value;
                if(matches.Count>0)
                {
                    int n = 0;
                    if(int.TryParse(firstMatch, out n))
                    {
                        calibrationValue += n;
                    }
                    else
                    {
                        switch(firstMatch)
                        {
                            case "one":
                                calibrationValue += "1";
                                break;
                                case "two":
                                calibrationValue += "2";
                                break;
                            case "three":
                                calibrationValue += "3";
                                break;
                            case "four":
                                calibrationValue += "4";
                                break;
                            case "five":
                                calibrationValue += "5";
                                break;
                            case "six":
                                calibrationValue += "6";
                                break;
                            case "seven":
                                calibrationValue += "7";
                                break;
                            case "eight":
                                calibrationValue += "8";
                                break;
                            case "nine":
                                calibrationValue += "9";
                                break;
                            
                        }
                    }
                   
                }
                if(inversedMatches.Count > 0)
                {
                    int n = 0;
                    if (int.TryParse(lastMatch, out n))
                    {
                        calibrationValue += n;
                    }
                    else
                    {
                        switch (lastMatch)
                        {
                            case "eno":
                                calibrationValue += "1";
                                break;
                            case "owt":
                                calibrationValue += "2";
                                break;
                            case "eerht":
                                calibrationValue += "3";
                                break;
                            case "ruof":
                                calibrationValue += "4";
                                break;
                            case "evif":
                                calibrationValue += "5";
                                break;
                            case "xis":
                                calibrationValue += "6";
                                break;
                            case "neves":
                                calibrationValue += "7";
                                break;
                            case "thgie":
                                calibrationValue += "8";
                                break;
                            case "enin":
                                calibrationValue += "9";
                                break;

                        }
                    }
                }
                numbers.Add(Convert.ToInt32(calibrationValue));
            }
            Console.WriteLine(numbers.Sum());
        }

    }
}
