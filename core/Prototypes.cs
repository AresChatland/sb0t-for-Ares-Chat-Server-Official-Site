﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
    static class Prototypes
    {
        private static Random rnd = new Random();

        public static void ForEachWhere<T>(this List<T> list, Action<T> @foreach, Predicate<T> @where)
        {
            for (int i = 0; i < list.Count; i++)
                if (@where(list[i]))
                    @foreach(list[i]);
        }

        public static void Randomize<T>(this List<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static int NextEndLine(this List<byte> list)
        {
            for (int i = 0; i < list.Count; i++)
                if (i < (list.Count - 1))
                    if (list[i] == 13)
                        if (list[i + 1] == 10)
                            return i;

            return -1;
        }

        public static bool CanTakeLine(this List<byte> list)
        {
            return list.NextEndLine() > -1;
        }

        public static String TakeLine(this List<byte> list)
        {
            int index = list.NextEndLine();

            if (index > -1)
            {
                String str = Encoding.Default.GetString(list.ToArray(), 0, index);
                list.RemoveRange(0, (index + 2));
                return str;
            }

            return String.Empty;
        }
    }
}
