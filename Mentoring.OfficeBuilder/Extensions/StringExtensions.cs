using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mentoring.OfficeBuilder.Extensions
{
    public static class StringExtensions
    {
        public static (int value, decimal unitRatio) ConvertAttribute(this string input)
        {
            string value = GetValue(input);
            string unit = GetUnit(input);

            return (int.Parse(value), GetUnitRatio(unit));
        }

        private static decimal GetUnitRatio(string unit)
        {
            return unit switch
            {
                "px" => 1m,
                "pt" => 4 / 3,
                _ => 1m
            };
        }

        private static string GetValue(string input)
        {
            string pattern = @"\d";

            StringBuilder sb = new StringBuilder();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                sb.Append(m);
            }

            var value = sb.ToString();
            return value;
        }

        private static string GetUnit(string input)
        {
            string pattern = @"[A-Za-z]";

            StringBuilder sb = new StringBuilder();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                sb.Append(m);
            }

            var unit = sb.ToString();
            return unit;
        }
    }
}
