using System;
using System.Collections.Generic;
using System.Linq;

namespace CoderByteHardStringChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
           start: Console.WriteLine(StringChallenge(Console.ReadLine()));
            goto start;
        }

        public static string StringChallenge(string str)
        {
            // code goes here  
            if (string.IsNullOrEmpty(str))
                return "false";
            int Number = 0;
            char Character;
            char[] numberPop = new char[2];
            char[] threePop = new char[3];
            string[] input = str.Split(new char[0]);
            char[] reg = input[0].ToCharArray();
            Stack<char> stackLetters = new Stack<char>(input[1].ToCharArray());
            Stack<char> stackReg = new Stack<char>(reg.Where(c => !char.IsNumber(c) && c != '{' && c != '}'));
            Number = reg.Where(c => char.IsNumber(c)).Select(c => (int)char.GetNumericValue(c)).SingleOrDefault();
            if (Number > 0)
            {
                numberPop = new char[Number];
            }
            while (stackReg.Count > 0 && stackLetters.Count > 0)
            {
                char po = stackReg.Pop();
                if (po == '$')
                {
                    Character = stackLetters.Pop();
                    if (!((Character >= '0') && (Character <= '9'))) break;
                }
                else if (po == '+')
                {
                    Character = stackLetters.Pop();
                    if (!char.IsLetter(Character)) break;
                }
                else if (po == '*')
                {
                    if (Number == 0)
                    {
                        if (stackLetters.Count > 0)
                            for (int i = 0; i < 3; i++)
                            {
                                threePop[i] = stackLetters.Pop();
                            }
                        else
                            break;
                    }
                    else
                    {
                        for (int i = 0; i < Number; i++)
                        {
                            if (stackLetters.Count > 0)
                                numberPop[i] = stackLetters.Pop();
                            else
                                break;
                        }
                        Number = 0;
                    }
                }
            }
            if (stackReg.Count == 0 && stackLetters.Count == 0)
                return "true";
            else
                return "false";
        }
    }
}