#region License
/* alg4-port
 * Copyright (C) 2014 J.Rauber
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections;

namespace algs4.Sort
{
    /// <summary>
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    public class AbstractSortBase
    {
        public static int[] indexSort(IComparable[] a)
        {
            int N = a.Length;
            int[] index = new int[N];
            for (int i = 0; i < N; i++)
                index[i] = i;

            for (int i = 0; i < N; i++)
                for (int j = i; j > 0 && less(a[index[j]], a[index[j - 1]]); j--)
                    exch(index, j, j - 1);

            return index;
        }

        protected static bool less(IComparable v, IComparable w)
        {
            return (v.CompareTo(w) < 0);
        }

        protected static bool less(IComparer c, Object v, Object w)
        {
            return (c.Compare(v, w) < 0);
        }

        protected static void exch(Object[] a, int i, int j)
        {
            Object swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }

        private static void exch(int[] a, int i, int j)
        {
            int swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }

        private static bool isSorted(IComparable[] a)
        {
            return isSorted(a, 0, a.Length - 1);
        }

        private static bool isSorted(IComparable[] a, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
                if (less(a[i], a[i - 1])) return false;
            return true;
        }

        private static bool isSorted(Object[] a, IComparer c)
        {
            return isSorted(a, c, 0, a.Length - 1);
        }

        private static bool isSorted(Object[] a, IComparer c, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
                if (less(c, a[i], a[i - 1])) return false;
            return true;
        }

        protected static void show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                //StdOut.println(a[i]);
            }
        }
    }
}
