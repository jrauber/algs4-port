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
 *  Compilation:  javac Selection.java
 *  Execution:    java  Selection < input.txt
 *  Dependencies: StdOut.java StdIn.java
 *  Data files:   http://algs4.cs.princeton.edu/21sort/tiny.txt
 *                http://algs4.cs.princeton.edu/21sort/words3.txt
 *   
 *  Sorts a sequence of strings from standard input using selection sort.
 *   
 *  % more tiny.txt
 *  S O R T E X A M P L E
 *
 *  % java Selection < tiny.txt
 *  A E E L M O P R S T X                 [ one string per line ]
 *    
 *  % more words3.txt
 *  bed bug dad yes zoo ... all bad yet
 *  
 *  % java Selection < words3.txt
 *  all bad bed bug dad ... yes yet zoo    [ one string per line ]
 *
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace algs4.Sort
{
    /// <summary>
    /// The <tt>Selection</tt> class provides static methods for sorting an
    /// array using selection sort.
    /// <p>
    /// For additional documentation, see <a href="http://algs4.cs.princeton.edu/21elementary">Section 2.1</a> of
    /// <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
    ///
    /// C# translation by J. Rauber from Java by Robert Sedgewick and Kevin Wayne.
    /// </summary>
    public class Selection : AbstractSortBase
    {
        // This class should not be instantiated.
        private Selection() { }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        public static void sort(IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (less(a[j], a[min]))
                    {
                        min = j;
                    }
                }
                exch(a, i, min);
                //assert isSorted(a, 0, i);
            }
            //assert isSorted(a);
        }

        /**
         * Rearranges the array in ascending order, using a comparator.
         * @param a the array
         * @param c the comparator specifying the order
         */
        public static void sort(string[] a, Comparer<String> c)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                int min = i;
                for (int j = i + 1; j < N; j++)
                {
                    if (less(c, a[j], a[min]))
                    {
                        min = j;      
                    }
                }
                exch(a, i, min);
                //assert isSorted(a, c, 0, i);
            }
            //assert isSorted(a, c);
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
         * Reads in a sequence of strings from standard input; selection sorts them; 
         * and prints them to standard output in ascending order. 
         */
        public static void Start()
        {
            //String[] a = StdIn.readAllStrings();

            String[] a = "S O R T E X A M P L E".Split(' ');
            Selection.sort(a);
            show(a);
        }
    }
}