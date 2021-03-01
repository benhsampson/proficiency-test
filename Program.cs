using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Q1");
            string input1 = "programming is fun";
            string input2 = "(programming is fun)";
            string input3 = "programming is fun)";
            string input4 = ")programming is fun(";
            Console.WriteLine(bracket_matcher(input1));
            Console.WriteLine(bracket_matcher(input2));
            Console.WriteLine(bracket_matcher(input3));
            Console.WriteLine(bracket_matcher(input4));

            Console.WriteLine("Q2");
            string input5 = "COMP10001 is utter!y:) @mazing**";
            Console.WriteLine(new_sentence(input5));

            Console.WriteLine("Q3");
            string[,] input6 = new string[,] { { "f", "d", "d", "s" }, { "r", "d", "d", "d" }, { "o", "o", "d", "d" }, { "o", "o", "d", "d" } };
            Console.WriteLine(matrix_search(input6, "d"));
            Console.WriteLine(matrix_search(input6, "s"));
            Console.WriteLine(matrix_search(input6, "o"));

            Console.WriteLine("Q4");

            string input7 = "ab3c?d?e?4fg???*h3i?j?k?m44???3";
            string input8 = "5???ab2c?d?e5fg*???h2i?j3?k?m4???3";
            Console.WriteLine(sumchecker(input7, 7));
            Console.WriteLine(sumchecker(input8, 7));

            Console.WriteLine("Q5a");
            int m = 18;
            int n = 5;
            int expected = m * (m - n);
            Console.WriteLine(foobar(m, n));
            Console.WriteLine(expected);
        }

        public static bool bracket_matcher(string sentence)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ')')
                {
                    char topElem = stack.Count == 0 ? '#' : stack.Pop();
                    if (topElem != '(')
                    {
                        return false;
                    }
                }
                else if (sentence[i] == '(')
                {
                    stack.Push(sentence[i]);
                }
            }

            return stack.Count == 0;
        }

        public static string new_sentence(string sentence)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]");
            string result = regex.Replace(sentence, "_");
            return result;
        }

        public static int matrix_search(string[,] board, string letter)
        {
            int count = 0;

            for (int row = 0; row < board.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < board.GetLength(1) - 1; col++)
                {
                    if (board[row, col] == letter && board[row + 1, col] == letter && board[row, col + 1] == letter && board[row + 1, col + 1] == letter)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static bool sumchecker(string st, int num)
        {
            int prevNum = 0;
            int currNum = 0;
            int nQMarks = 0;

            for (int i = 0; i < st.Length; i++)
            {
                if (Char.IsDigit(st[i]))
                {
                    prevNum = currNum;
                    currNum = int.Parse(st[i].ToString());

                    if (prevNum != 0)
                    {
                        if (prevNum + currNum == num && nQMarks != 3)
                        {
                            return false;
                        }

                        nQMarks = 0;
                    }
                }
                else if (st[i] == '?')
                {
                    nQMarks++;
                }
            }

            return true;
        }

        public static int foobar(int m, int n)
        {
            int retval = 0;

            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < m - n + 1; j++)
                {
                    retval += i * j;
                    count++;
                }
            }

            return count;
        }
    }
}
