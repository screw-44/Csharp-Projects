﻿using System;
using System.Windows;

namespace CalculatorFinal
{
    public class Tools
    {
        /// <summary>
        /// Cast String into Double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double CastString2Double(string str)
        {
            double result = 0;
            if (str.Contains('.'))
            {
                string[] parts = str.Split('.');
                double.TryParse(parts[0], out result);
                double _ = 0;
                double.TryParse(parts[1], out _);
                _ /= Math.Pow(10, parts[1].Length);
                if (result >= 0)
                    result += _;
                else
                    result -= _;
                return result;
            }

            double.TryParse(str, out result);
            return result;
        }

        /// <summary>
        /// Check wheather the stirng is valided.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>true for valid, false for invalid</returns>
        public static bool CastStrValidation(string str)
        {
            // If there are two dot in one num.
            string[] parts = str.Split('.');
            if (parts.Length > 2)
            {
                MessageBox.Show("Nums has two dot!!!!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// avoid case like "-+12123"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool TextStrValidation(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                char current = str[i];
                char next = str[i + 1];
                if (current == '-'
                    && (next == '-' || next == '+' || next == '×' || next == '÷'))
                {
                    MessageBox.Show("Inputs has two calculate sign!!!!");
                    return false;
                }
            }
            return true;
        }
    }
}

