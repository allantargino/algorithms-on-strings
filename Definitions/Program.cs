using System;
using System.Collections.Generic;

namespace Definitions
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString word1 = new MyString('a', 'b', 'b', 'a');
            MyString word2 = new MyString('a', 'c', 'd', 'a');

            Console.WriteLine(word1.Length);
            Console.WriteLine(word1.PositionAt(2));
            Console.WriteLine(word1.IsEqualTo(word1));
            Console.WriteLine(word1.IsEqualTo(word2));

            var alph = word1.Alph();

            Console.WriteLine(word1 * word2);
            Console.WriteLine(word2 ^ 4);

            Console.WriteLine(~word2);
            Console.WriteLine(~(word1 * word2) ^ 2);
        }

        class MyString
        {
            public char[] Letters { get; set; }

            public MyString(params char[] letters)
            {
                Letters = letters;
            }

            public static MyString EmptyString() => new MyString();

            public int Length => Letters.Length;

            public char PositionAt(int index)
            {
                if (index < 0 && index >= Length)
                    throw new IndexOutOfRangeException();

                return Letters[index];
            }

            public bool IsEqualTo(MyString other)
            {
                if (this.Length != other.Length)
                    return false;

                for (int i = 0; i < Length; i++)
                {
                    if (this.Letters[i] != other.Letters[i])
                        return false;
                }

                return true;
            }

            public ISet<char> Alph()
            {
                HashSet<char> alphabet = new HashSet<char>();

                foreach (char letter in Letters)
                {
                    alphabet.Add(letter);
                }

                return alphabet;
            }

            public static MyString operator *(MyString x, MyString y)
            {
                char[] product = new char[x.Length + y.Length];

                x.Letters.CopyTo(product, 0);
                y.Letters.CopyTo(product, x.Length);

                return new MyString(product);
            }

            public static MyString operator ^(MyString x, int n)
            {
                if (n < 0)
                    throw new ArgumentOutOfRangeException();

                if (n == 0)
                    return EmptyString();

                return (x ^ (n - 1)) * x;
            }

            //public static MyString operator ^(MyString x, int n)
            //{
            //    if (n < 0)
            //        throw new ArgumentOutOfRangeException();

            //    if (n == 0)
            //        return EmptyString();

            //    char[] power = new char[x.Length * n];

            //    for (int i = 0; i < n; i++)
            //    {
            //        x.Letters.CopyTo(power, i * x.Length);
            //    }

            //    return new MyString(power);
            //}

            public static MyString operator ~(MyString x)
            {
                char[] reverse = new char[x.Length];

                for (int i = 0; i < x.Length; i++)
                {
                    reverse[x.Length - 1 - i] = x.Letters[i];
                }

                return new MyString(reverse);
            }

            public override string ToString() => new string(Letters);
        }
    }
}
