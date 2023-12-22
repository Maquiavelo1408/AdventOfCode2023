using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day_7
{
    internal static class Day7
    {
        enum HandType
        {
            Five = 7,
            Four = 6,
            Full = 5,
            Third = 4,
            TwoPair = 3,
            OnePair = 2,
            Hihg = 1
        }
        enum Card
        {
            J = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eigth = 8,
            Nine = 9,
            T = 10,

            Q = 12,
            K = 13,
            A = 14
        }
        class Hand
        {
            public Hand()
            {
                Bid = 0;
                Rank = 0;
            }
            public string Cards { get; set; }
            public int Bid { get; set; }
            public int Rank { get; set; }
            public HandType Type { get; set; }
            public Card First { get; set; }
            public Card Second { get; set; }
            public Card Third { get; set; }
            public Card Fourth { get; set; }
            public Card Fifth { get; set; }
        }
        public static void First()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 7\\input.txt");
            List<Hand> hands = new List<Hand>();
            foreach (string line in lines)
            {
                string hand = line.Split(' ')[0];
                hands.Add(new Hand()
                {
                    Cards = line.Split(' ')[0],
                    Bid = int.Parse(line.Split(" ")[1]),
                    Type = IdentifyHand(line.Split(' ')[0]),
                    First = (Card)Enum.Parse(typeof(Card), hand[0].ToString()),
                    Second = (Card)Enum.Parse(typeof(Card), hand[1].ToString()),
                    Third = (Card)Enum.Parse(typeof(Card), hand[2].ToString()),
                    Fourth = (Card)Enum.Parse(typeof(Card), hand[3].ToString()),
                    Fifth = (Card)Enum.Parse(typeof(Card), hand[4].ToString())
                });
            }
            hands = hands.OrderBy(x => x.Type).ThenBy(x => x.First).ThenBy(x => x.Second).ThenBy(x => x.Third).ThenBy(x => x.Fourth).ThenBy(x => x.Fifth).ToList();
            int ranking = 1;
            long total = 0;
            foreach (Hand hand in hands)
            {
                hand.Rank = ranking;
                total += (ranking * hand.Bid);
                ranking++;
            }

            Console.Write(total);
        }
        public static void Second()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\Admin\\source\\repos\\AdventOfCode2023\\AdventOfCode2023\\Day 7\\input.txt");
            List<Hand> hands = new List<Hand>();
            foreach (string line in lines)
            {
                string hand = line.Split(' ')[0];
                hands.Add(new Hand()
                {
                    Cards = line.Split(' ')[0],
                    Bid = int.Parse(line.Split(" ")[1]),
                    Type = IdentifyHand(line.Split(' ')[0]),
                    First = (Card)Enum.Parse(typeof(Card), hand[0].ToString()),
                    Second = (Card)Enum.Parse(typeof(Card), hand[1].ToString()),
                    Third = (Card)Enum.Parse(typeof(Card), hand[2].ToString()),
                    Fourth = (Card)Enum.Parse(typeof(Card), hand[3].ToString()),
                    Fifth = (Card)Enum.Parse(typeof(Card), hand[4].ToString())
                });
            }
            hands = hands.OrderBy(x => x.Type).ThenBy(x => x.First).ThenBy(x => x.Second).ThenBy(x => x.Third).ThenBy(x => x.Fourth).ThenBy(x => x.Fifth).ToList();
            int ranking = 1;
            long total = 0;
            foreach (Hand hand in hands)
            {
                hand.Rank = ranking;
                total += (ranking * hand.Bid);
                ranking++;
            }

            Console.Write(total);
        }
        static HandType IdentifyHand(string hand)
        {
            HandType finalType = HandType.Hihg;
            string tempValue = hand;
            Regex regex = new Regex("([2-9AKQJT]){1}");
            string regExp = "([2-9AKQJT]){1}";
            var matches = regex.Matches(tempValue);
            var thirdFound = false;
            var pairFound = false;
            bool hasJoker = false;
            int jokerCards = 0;
            while (tempValue.Length > 0)
            {


                var match = tempValue.Count(x => x == tempValue[0]);
                if (tempValue[0] == 'J')
                {
                    hasJoker = true;
                    jokerCards = match;
                    tempValue = tempValue.Replace(tempValue[0].ToString(), "");
                    continue;
                }
                //var match = Regex.Match(tempValue, regExp);
                if (match == 1)
                {
                    tempValue = tempValue.Remove(0, 1);
                    continue;
                }
                else if (match == 5)
                {
                    finalType = HandType.Five;
                }
                else if (match == 4)
                {
                    finalType = HandType.Four;
                }
                else if (match == 3)
                {
                    if (pairFound)
                    {
                        finalType = HandType.Full;

                    }
                    else
                    {
                        thirdFound = true;
                        finalType = HandType.Third;
                    }
                }
                else if (match == 2)
                {
                    if (pairFound)
                        finalType = HandType.TwoPair;
                    else if (thirdFound)
                    {
                        finalType = HandType.Full;
                    }
                    else
                    {
                        pairFound = true;
                        finalType = HandType.OnePair;
                    }
                }
                tempValue = tempValue.Replace(tempValue[0].ToString(), "");


            }


            if (hasJoker)
            {

                for (int i = 0; i < jokerCards; i++)
                {
                    if (finalType == HandType.Five)
                        break;

                    if (finalType == HandType.Third || finalType == HandType.OnePair || finalType == HandType.TwoPair)
                    //if (finalType == HandType.Third || finalType == HandType.OnePair)
                        finalType += 2;
                    else
                        finalType += 1;
                }
                /*switch(finalType)
                {
                    case HandType.Full:
                        finalType = HandType.Four;
                        break;
                        case HandType.TwoPair:
                        finalType = HandType.Full;
                        break;
                        case HandType.OnePair:
                        finalType= HandType.Third;
                        break;
                        case HandType.Five:
                        break;
                        case HandType.Four:
                        finalType = HandType.Five;
                        break;
                        case HandType.Third:
                        finalType = HandType.Four;
                        break;
                }*/
            }
            return finalType;
        }
    }
}
