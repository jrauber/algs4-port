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
 *  Compilation:  javac Merge.java
 *  Execution:    java Merge < input.txt
 *  Dependencies: StdOut.java StdIn.java
 *  Data files:   http://algs4.cs.princeton.edu/22mergesort/tiny.txt
 *                http://algs4.cs.princeton.edu/22mergesort/words3.txt
 *   
 *  Sorts a sequence of strings from standard input using mergesort.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java Merge < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java Merge < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *  
 *************************************************************************/

namespace algs4.Sort
{
    /// <summary>
    /// The <tt>Merge</tt> class provides static methods for sorting an
    /// array using mergesort.
    /// <p>
    /// For additional documentation, see <a href="http://algs4.cs.princeton.edu/22mergesort">Section 2.2</a> of
    /// <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    /// For an optimized version, see {@link MergeX}.
    /// 
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    class Merge : AbstractSortBase
    {
        // This class should not be instantiated.
        private Merge() { }

        // stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
        private static void merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi, int recLevel)
        {
            Console.WriteLine(String.Format("{0}merge lo={1} mid={2} hi={3}", "".PadLeft(++recLevel), lo, mid, hi));

            // precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted subarrays
            //assert isSorted(a, lo, mid);
            //assert isSorted(a, mid+1, hi);

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];   // this copying is unnecessary
                else if (j > hi) a[k] = aux[i++];
                else if (less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }

            // postcondition: a[lo .. hi] is sorted
            //assert isSorted(a, lo, hi);
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void sort(IComparable[] a, IComparable[] aux, int lo, int hi, int recLevel)
        {
            Console.WriteLine(String.Format("{0}sort lo={1} hi={2}","".PadLeft(++recLevel), lo, hi));

            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, aux, lo, mid, recLevel);
            sort(a, aux, mid + 1, hi, recLevel);
            merge(a, aux, lo, mid, hi, recLevel);
        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void sort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            sort(a, aux, 0, a.Length - 1, 0);
            //assert isSorted(a);
        }



        /***********************************************************************
         *  Index mergesort
         ***********************************************************************/
        // stably merge a[lo .. mid] with a[mid+1 .. hi] using aux[lo .. hi]
        private static void merge(IComparable[] a, int[] index, int[] aux, int lo, int mid, int hi, int recLevel)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = index[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) index[k] = aux[j++];
                else if (j > hi) index[k] = aux[i++];
                else if (less(a[aux[j]], a[aux[i]])) index[k] = aux[j++];
                else index[k] = aux[i++];
            }
        }

        /**
         * Returns a permutation that gives the elements in the array in ascending order.
         * @param a the array
         * @return a permutation <tt>p[]</tt> such that <tt>a[p[0]]</tt>, <tt>a[p[1]]</tt>,
         *    ..., <tt>a[p[N-1]]</tt> are in ascending order
         */
        public static int[] indexSort(IComparable[] a)
        {
            int N = a.Length;
            int[] index = new int[N];
            for (int i = 0; i < N; i++)
                index[i] = i;

            int[] aux = new int[N];
            sort(a, index, aux, 0, N - 1, 0);
            return index;
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void sort(IComparable[] a, int[] index, int[] aux, int lo, int hi, int recLevel)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, index, aux, lo, mid, recLevel);
            sort(a, index, aux, mid + 1, hi, recLevel);
            merge(a, index, aux, lo, mid, hi, recLevel);
        }

        // print array to standard output
        private static void show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                //StdOut.println(a[i]);
            }
        }

        /**
         * Reads in a sequence of strings from standard input; mergesorts them; 
         * and prints them to standard output in ascending order. 
         */
        public static void Start()
        {
            //String[] a = StdIn.readAllStrings();
            String[] a = "S O R T E X A M P L E".Split(' ');
            Merge.sort(a);
            show(a);
        }
    }
}