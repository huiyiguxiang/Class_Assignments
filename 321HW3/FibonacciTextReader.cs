// <copyright file="FibonacciTextReader.cs" company="Linh Stitsel 11779841">
// Copyright (c) Linh Stitsel 11779841. All rights reserved.
// </copyright>

namespace _321HW3
{
    using System;
    using System.IO;
    using System.Numerics;
    using System.Text;

    /// <summary>
    /// Inherits the TextReader class.
    /// It can calculate and print a Fibonacci Sequence formatted.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private int maximum;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// This is the constructor for FibonacciTextReader.
        /// </summary>
        /// <param name="max">Maximum number of lines.</param>
        public FibonacciTextReader(int max)
        {
            this.maximum = max;
        }

        /// <summary>
        /// Implements the logic for the Fibonacci Sequence.
        /// It has two special cases for 0 and 1,
        /// Then starting from 2, it adds the previous number and itself to create the new sum.
        /// </summary>
        /// <param name="n">Line count.</param>
        /// <returns>Sum number.</returns>
        public BigInteger ReadLine(int n)
        {
            // variables
            BigInteger x = 0;
            BigInteger y = 1;
            BigInteger sum = 0;

            // special case for 0
            if (n == 0)
            {
                return 0;
            }

            // special case for 1
            else if (n == 1)
            {
                return 1;
            }

            // add to form fibonacci sequence at after special cases
            for (int i = 2; i <= n; i++)
            {
                sum = x + y; // create the new sum number
                x = y; // shift x to y which is its next number
                y = sum; // shift y to sum which is its next number
            }

            return sum;
        }

        /// <summary>
        /// Overrides ReadToEnd. Prints the Fibonacci Sequence line by line.
        /// It is formatted so that it has a line count number : sum number then followed by a newline.
        /// </summary>
        /// <returns>String output for Fibonacci Sequence.</returns>
        public override string ReadToEnd()
        {
            StringBuilder sr = new StringBuilder(); // initialize stringbuilder

            // call readline repeatedly
            for (int i = 0; i < this.maximum; i++)
            {
                sr.Append((i + 1) + ": " + this.ReadLine(i) + "\r\n"); // format output
            }

            return sr.ToString();
        }
    }
}
