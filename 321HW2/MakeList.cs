// Copyright (c) Linh Stitsel. All rights reserved.

namespace _321HW2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  This function loops through the sorted list to find the unique value.
    ///  While it finds the new unique value, it skips the consecutive duplicate values.
    /// </summary>
    public class MakeList
    {
        /// <summary>
        ///  This function takes a list parameter and adds values to it as according to the requirements.
        /// </summary>
        /// <param name="list">List to add to.</param>
        public static void AddToList(ref List<int> list)
        {
            Random rand = new Random(); // create list

            // add to list
            for (int i = 0; i <= 10000; i++)
            {
                list.Add(rand.Next(0, 20001));
            }
        }
    }
}
