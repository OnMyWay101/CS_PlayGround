using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidBrackets.Run();
            Console.ReadLine();
        }
    }
    class ValidBrackets
    {
        public static void Run()
        {
            string example = "{a}[]()";
            Console.WriteLine("result:" + CheakTheString(example));
        }

        private static bool CheakTheString(string s)
        {
            var recordLeftStack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    recordLeftStack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    char temp = recordLeftStack.Pop();
                    switch (c)
                    {
                        case ')':
                            if (temp != '(')
                            {
                                return false;
                            }
                            break;
                        case ']':
                            if (temp != '[')
                            {
                                return false;
                            }
                            break;
                        default:
                            if (temp != '{')
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            if (recordLeftStack.Count != 0)
            {
                return false;
            }
            return true;
        }
    }
}

