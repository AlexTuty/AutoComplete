﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoComplete
{
    // Внимание!
    // Есть одна распространенная ловушка при сравнении строк: строки можно сравнивать по-разному:
    // с учетом регистра, без учета, зависеть от кодировки и т.п.
    // В файле словаря все слова отсортированы методом StringComparison.OrdinalIgnoreCase.
    // Во всех функциях сравнения строк в C# можно передать способ сравнения.
    public class LeftBorderTask
    {
        /// <returns>
        /// Возвращает индекс левой границы.
        /// То есть индекс максимальной фразы, которая не начинается с prefix и меньшая prefix.
        /// Если такой нет, то возвращает -1
        /// </returns>
        /// <remarks>
        /// Функция должна быть рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            // IReadOnlyList похож на List, но у него нет методов модификации списка.
            if (right - left == 1)
                return left;
            var middle = ((long)left + right) / 2;
            if (string.Compare(phrases[(int)middle], prefix, StringComparison.OrdinalIgnoreCase) < 0)
                return GetLeftBorderIndex(phrases, prefix, (int)middle, right);
            else
                return GetLeftBorderIndex(phrases, prefix, left, (int)middle);
        }
    }
}
