using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            // Define our empty array to store necessary elements of our sequence.
           K[] temp = new K[sequence.Length];
           MergeSort(sequence, temp, comparer);
        }

        public static void MergeSort<K>(K[] sequence, K[] temp, IComparer<K> comparer)
        {
            // m represents width of our current merge, beginning at 1 and doubling each time.
            int m;
            for(m = 1; m < sequence.Length; m = 2*m)
            {
                int start;
                for(start = 0; start < sequence.Length; start = (start + 2*m) )
                {
                    // Here we pass our current left and right bounds of our merge, to avoid inconsistencies (with an
                    // uneven array etc.) We use Math.Min.
                   Merge(sequence, start, Math.Min(start+m, sequence.Length), Math.Min(start+2*m, sequence.Length), temp, comparer);
                }

            }


        }
        private static void Merge<K>(K[] sequence, int start, int middle, int end, K[] temp, IComparer<K> comparer)
        {
            // Here we use i j k to represent the bounds of our merge.
            int i, j, k;
            i = start;
            j = middle;
            k = start;
            // Will exit once we've reached the end of either bound.
            while(i < middle || j < end)
            {
                // Ensuring we define the last round of the merge, as this needs to behave differently.
                if(i < middle && j < end)
                {
                    // We compare our elements using the original array.
                    if(comparer.Compare(sequence[i], sequence[j]) < 0)
                    {
                        // Assign to the temp array and iterate through our original array.
                        temp[k++] = sequence[i++];
                    }
                    else
                    {
                        // Same as above except we iterate through the right bound of our array.
                        temp[k++] = sequence[j++];
                    }
                }
                // If we have reached the final element in our merge, we need to assign it the remaining value of the right-bound.
                else if(i == middle)
                {
                    temp[k++] = sequence[j++];
                }
                // Same as above.
                else if(j == end)
                {
                    temp[k++] = sequence[i++];
                }

            }
            // Finally copy the temp (sorted array) to our original array to be printed and checked.
            for(i = start; i < end; i++)
            {
                sequence[i] = temp[i];
            }

        }






    }







}