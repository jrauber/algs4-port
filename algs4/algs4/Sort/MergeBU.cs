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

/*************************************************************************
 *  Compilation:  javac MergeBU.java
 *  Execution:    java MergeBU < input.txt
 *  Dependencies: StdOut.java StdIn.java
 *  Data files:   http://algs4.cs.princeton.edu/22mergesort/tiny.txt
 *                http://algs4.cs.princeton.edu/22mergesort/words3.txt
 *   
 *  Sorts a sequence of strings from standard input using
 *  bottom-up mergesort.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java MergeBU < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java MergeBU < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *
 *************************************************************************/
namespace algs4.Sort
{
    /// <summary>
    /// The <tt>MergeBU</tt> class provides static methods for sorting an
    /// array using bottom-up mergesort.
    /// <p>
    /// For additional documentation, see <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> of
    /// <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    /// 
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    class MergeBU : AbstractSortBase
    {

        // This class should not be instantiated.
        private MergeBU() { }

        // stably merge a[lo..mid] with a[mid+1..hi] using aux[lo..hi]
        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];  // this copying is unneccessary
                else if (j > hi) a[k] = aux[i++];
                else if (less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }

        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void sort(IComparable[] a)
        {
            int N = a.Length;
            IComparable[] aux = new IComparable[N];
            for (int n = 1; n < N; n = n + n)
            {
                for (int i = 0; i < N - n; i += n + n)
                {
                    int lo = i;
                    int m = i + n - 1;
                    int hi = Math.Min(i + n + n - 1, N - 1);
                    merge(a, aux, lo, m, hi);
                }
            }
            //assert isSorted(a);
        }

        /**
         * Reads in a sequence of strings from standard input; bottom-up
         * mergesorts them; and prints them to standard output in ascending order. 
         */
        public static void Start()
        {
            //String[] a = StdIn.readAllStrings();
            String[] a = "S O R T E X A M P L E".Split(' ');
            MergeBU.sort(a);
            show(a);
        }
    }
}