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
 *  Compilation:  javac MergeX.java
 *  Execution:    java MergeX < input.txt
 *  Dependencies: StdOut.java StdIn.java
 *  Data files:   http://algs4.cs.princeton.edu/22mergesort/tiny.txt
 *                http://algs4.cs.princeton.edu/22mergesort/words3.txt
 *   
 *  Sorts a sequence of strings from standard input using an
 *  optimized version of mergesort.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java MergeX < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java MergeX < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *
 *************************************************************************/
namespace algs4.Sort
{
    /// <summary>
    /// The <tt>MergeX</tt> class provides static methods for sorting an
    /// array using an optimized version of mergesort.
    /// <p>
    /// For additional documentation, see <a href="http://algs4.cs.princeton.edu/22mergesort">Section 2.2</a> of
    /// <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    /// 
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    class MergeX : AbstractSortBase
    {
        private static readonly int CUTOFF = 7;  // cutoff to insertion sort

        // This class should not be instantiated.
        private MergeX() { }

        private static void merge(IComparable[] src, IComparable[] dst, int lo, int mid, int hi)
        {

            // precondition: src[lo .. mid] and src[mid+1 .. hi] are sorted subarrays
            //assert isSorted(src, lo, mid);
            //assert isSorted(src, mid+1, hi);

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) dst[k] = src[j++];
                else if (j > hi) dst[k] = src[i++];
                else if (less(src[j], src[i])) dst[k] = src[j++];   // to ensure stability
                else dst[k] = src[i++];
            }

            // postcondition: dst[lo .. hi] is sorted subarray
            //assert isSorted(dst, lo, hi);
        }

        private static void sort(IComparable[] src, IComparable[] dst, int lo, int hi)
        {
            // if (hi <= lo) return;
            if (hi <= lo + CUTOFF)
            {
                insertionSort(dst, lo, hi);
                return;
            }
            int mid = lo + (hi - lo) / 2;
            sort(dst, src, lo, mid);
            sort(dst, src, mid + 1, hi);

            // if (!less(src[mid+1], src[mid])) {
            //    for (int i = lo; i <= hi; i++) dst[i] = src[i];
            //    return;
            // }

            // using System.arraycopy() is a bit faster than the above loop
            if (!less(src[mid + 1], src[mid]))
            {
                Array.Copy(src, lo, dst, lo, hi - lo + 1);
                return;
            }

            merge(src, dst, lo, mid, hi);
        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void sort(IComparable[] a)
        {
            IComparable[] aux = (IComparable[])a.Clone();
            sort(aux, a, 0, a.Length - 1);
            //assert isSorted(a);
        }


        // sort from a[lo] to a[hi] using insertion sort
        private static void insertionSort(IComparable[] a, int lo, int hi)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && less(a[j], a[j - 1]); j--)
                    exch(a, j, j - 1);
        }

        /**
         * Reads in a sequence of strings from standard input; mergesorts them
         * (using an optimized version of mergesort); 
         * and prints them to standard output in ascending order. 
         */
        public static void Start()
        {
            //String[] a = StdIn.readAllStrings();

            String[] a = "S O R T E X A M P L E".Split(' ');
            MergeX.sort(a);
            show(a);
        }
    }
}