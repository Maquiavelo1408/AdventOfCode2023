using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_3
{
    internal static class Day3
    {
        class Indexes
        {
            public int y {  get; set; }
            public int StartIndex { get; set;}
            public int Length { get; set;}    
            public int Value {  get; set;}
            public bool Applied { get; set;}
            public Indexes()
            {
                    Applied = false;
            }
        }
        public static void Third()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 3\\input.txt");
            Regex regex = new Regex("([0-9])+");
            char[][] result = lines.Select(item=> item.ToArray()).ToArray();
            List<int> numsToSum = new List<int>();
            List<Indexes> indexes = new List<Indexes>();

            for (int j=0; j<lines.Length; j++)
            {
                var matches = regex.Matches(lines[j]);
                if (matches.Count > 0)
                {
                    for (int i = 0; i < matches.Count; i++) { 
                        var current = matches[i];
                        indexes.Add(new Indexes
                        {
                            y = j,
                            Length = current.Length,
                            StartIndex = current.Index,
                            Value = Convert.ToInt32(current.Value)
                        });

                    }
                }
            }
            int suma = 0;
            foreach(var index in indexes)
            {
                index.Applied = CheckIfAdyacent(index, lines);
                if (index.Applied)
                {
                    PrintAdyacents(index.StartIndex, index.Length, lines, index.y, index.Value);
                    Console.WriteLine("-----------------------------------------");
                    suma += index.Value;
                }
            }
            Console.WriteLine(suma);
            Console.WriteLine("--------------");
            
        }
        private static void PrintAdyacents(int startIndex, int length, string[] lines, int y, int value)
        {
            StringBuilder sb = new StringBuilder();
            if(y > 0)
            {
                if (startIndex == 0)
                {
                    sb.Append(lines[y-1].Substring(startIndex, length + 1));
                }
                else if (startIndex + length > 139)
                {
                    sb.Append(lines[y-1].Substring(startIndex - 1, length));
                }
                else
                {
                    sb.Append(lines[y-1].Substring(startIndex - 1, length + 2));
                }
                sb.AppendLine();

            }
            if (startIndex==0)
            {
                sb.Append(lines[y].Substring(startIndex, length+1));
            }
            else if(startIndex+length> 139)
            {
                sb.Append(lines[y].Substring(startIndex-1, length));
            }
            else
            {
                sb.Append(lines[y].Substring(startIndex-1, length + 2));
            }
            sb.AppendLine();
            if (y < 139)
            {
                if (startIndex == 0)
                {
                    sb.Append(lines[y+1].Substring(startIndex, length + 1));
                }
                else if (startIndex + length > 139)
                {
                    sb.Append(lines[y+1].Substring(startIndex - 1, length));
                }
                else
                {
                    sb.Append(lines[y+1].Substring(startIndex - 1, length + 2));
                }
            }
            
            Console.WriteLine(sb.ToString());
            
        }
        private static bool CheckIfAdyacent(Indexes index, string[] lines)
        {
            Regex symbols = new Regex(@"[^.\d]");
            MatchCollection currentLine;
            if (index.y > 0)
            {
                var previousLine = symbols.Matches(lines[index.y -1]);
                if(previousLine.Count>0)
                {
                    var coincidenes = previousLine.Where(a => a.Index >= index.StartIndex - 1 && a.Index <= index.StartIndex + index.Length).ToList();
                    if(coincidenes.Count>0)
                    {
                       //PrintAdyacents(index.StartIndex, index.Length, lines, index.y, index.Value);
                        return true;
                    }
                }
            }

            currentLine = symbols.Matches(lines[index.y]);
            if (currentLine.Count>0)
            {
                var coincidenes = currentLine.Where(a => a.Index >= index.StartIndex - 1 && a.Index <= index.StartIndex + index.Length).ToList();
                if (coincidenes.Count > 0)
                {
                    //PrintAdyacents(lines[index.y], index.StartIndex, index.Length);
                    return true;
                }
            }
            if (index.y < lines.Length - 2)
            {
                var nextLine = symbols.Matches(lines[index.y + 1]);
                if (nextLine.Count > 0)
                {
                    var coincidenes = nextLine.Where(a => a.Index >= index.StartIndex - 1 && a.Index <= index.StartIndex + index.Length).ToList();
                    if (coincidenes.Count > 0)
                    {
                     //   PrintAdyacents(lines[index.y + 1], index.StartIndex, index.Length);
                        return true;
                    }

                }
            }

            return false;
        }

    }
}
