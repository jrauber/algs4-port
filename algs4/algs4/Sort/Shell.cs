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

/*************************************************************************
 *  Compilation:  javac Shell.java
 *  Execution:    java Shell < input.txt
 *  Dependencies: StdOut.java StdIn.java
 *  Data files:   http://algs4.cs.princeton.edu/21sort/tiny.txt
 *                http://algs4.cs.princeton.edu/21sort/words3.txt
 *   
 *  Sorts a sequence of strings from standard input using shellsort.
 *
 *  Uses increment sequence proposed by Sedgewick and Incerpi.
 *  The nth element of the sequence is the smallest integer >= 2.5^n
 *  that is relatively prime to all previous terms in the sequence.
 *  For example, incs[4] is 41 because 2.5^4 = 39.0625 and 41 is
 *  the next integer that is relatively prime to 3, 7, and 16.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java Shell < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java Shell < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *
 *
 *************************************************************************/

using System;

namespace algs4.Sort
{
    /// <summary>
    /// The <tt>Shell</tt> class provides static methods for sorting an
    /// array using Shellsort with Knuth's increment sequence (1, 4, 13, 40, ...).
    /// <p>
    /// For additional documentation, see <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> of
    /// <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    ///
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    class Shell : AbstractSortBase
    {

        // This class should not be instantiated.
        private Shell() { }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void sort(IComparable[] a)
        {
            int N = a.Length;

            // 3x+1 increment sequence:  1, 4, 13, 40, 121, 364, 1093, ... 
            int h = 1;
            while (h < N/3)
            {
                h = 3 * h + 1;               
            }

            while (h >= 1)
            {
                // h-sort the array
                for (int i = h; i < N; i++)
                {
                    for (int j = i; j >= h && less(a[j], a[j - h]); j -= h)
                    {
                        exch(a, j, j - h);
                    }
                }
                //assert isHsorted(a, h); 
                h /= 3;
            }
            //assert isSorted(a);
        }


        // is the array h-sorted?
        private static bool isHsorted(IComparable[] a, int h)
        {
            for (int i = h; i < a.Length; i++)
                if (less(a[i], a[i - h])) return false;
            return true;
        }

        /**
         * Reads in a sequence of strings from standard input; Shellsorts them; 
         * and prints them to standard output in ascending order. 
         */

        /**
         * Reads in a sequence of strings from standard input; selection sorts them; 
         * and prints them to standard output in ascending order. 
         */
        public static void Start()
        {
            //String[] a = StdIn.readAllStrings();

            String[] a = "S O R T E X A M P L E".Split(' ');
            Shell.sort(a);
            show(a);
        }
    }
}