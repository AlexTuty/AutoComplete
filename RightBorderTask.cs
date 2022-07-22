using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoComplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            while (true)
            {
                if (right - left == 1)
                    return right;
                var middle = ((long)left + right) / 2;
                if (string.Compare(phrases[(int)middle], prefix, StringComparison.OrdinalIgnoreCase) > 0
                    && !phrases[(int)middle].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    right = (int)middle;
                else
                    left = (int)middle;
            }
        }
    }
}
