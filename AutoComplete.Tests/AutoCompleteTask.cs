using NUnit.Framework;
using System;

namespace AutoComplete.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCaseSource(typeof(RightBorderCase), nameof(RightBorderCase.DataCases))]
        public void SearhRightBorderIndex(string[] phrases, string prefix, int expected)
        {
            var indexRight = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Length);
            Assert.AreEqual(expected, indexRight);
        }
    }

    internal class RightBorderCase
    {
        internal static object[] DataCases =
        {
            new object[] { new[] { "a", "ab", "abc" }, "aa", 1 },
            new object[] { new[] { "a", "ab", "abc" }, "abb", 2 },
            new object[] { new[] { "ab", "ab", "ab", "ab" }, "aa", 0 },
            new object[] { new[] { "ab", "ab", "ab", "ab" }, "a", 4 },
            new object[] { new[] { "a", "bcd", "bcefg", "bcefh", "bcf", "bcff", "zzz" }, "a", 1 },
            new object[] { new[] { "a", "ab" }, "", 2 }
        };
    }
}