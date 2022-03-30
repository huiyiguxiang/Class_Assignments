// Copyright (c) Linh Stitsel. All rights reserved.

namespace _321HW2
{
    using System.Collections.Generic;

    /// <summary>
    ///  Class with different methods to count the distinct values in the list.
    /// </summary>
    public class DistinctFinder
    {
        /// <summary>
        ///  This function inserts values from the list into a hash set
        ///  Because a hash set does not allow duplicates, distinct integers are
        ///  already included in the set.
        /// </summary>
        /// <param name="list">Count of elements in hash set.</param>
        /// <returns>Random integers list.</returns>
        public static int HSMethod(ref List<int> list)
        {
            HashSet<int> hashSet = new HashSet<int>(); // create hashset

            // add to hashset
            for (int i = 0; i < list.Count; i++)
            {
                hashSet.Add(list[i]);
            }

            return hashSet.Count;
        }

        /// <summary>
        ///  This function loops through the list to find the unique value.
        ///  Then, it has a nested loop that goes again to avoid putting duplicate values in the count.
        /// </summary>
        /// <param name="list">Count of unique values.</param>
        /// <returns>Random integers list.</returns>
        public static int O1StorageMethod(ref List<int> list)
        {
            int count = 0; // initialize count

            for (int i = 0; i < list.Count; i++)
            {
                bool isDuplicate = false; // assume not duplicate
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        isDuplicate = true; // dont add to count when duplicate found
                    }
                }

                if (isDuplicate == false)
                {
                    count++; // add to count when non duplicate found
                }
            }

            return count;
        }

        /// <summary>
        ///  This function loops through the sorted list to find the unique value.
        ///  While it finds the new unique value, it skips the consecutive duplicate values.
        /// </summary>
        /// <param name="list">Count of unique values.</param>
        /// <returns>Random integers list.</returns>
        public static int SortedMethod(ref List<int> list)
        {
            list.Sort(); // sort the list
            int count = 1; // initialize count

            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 < list.Count && list[i] != list[i + 1])
                {
                    count++; // add to count and skip duplicates
                }
            }

            return count;
        }
    }
}
