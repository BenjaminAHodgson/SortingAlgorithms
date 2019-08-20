using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vector
{
    public class MergeSortTopDown : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            MergeSort(sequence, comparer);
        }

        private static void MergeSort<K>(K[] sequence, IComparer<K> comparer)
        {
            int n = sequence.Length;
            // For a top-down merge sort, we end it at an array size of 1.
            if(n < 2)
            {
                return;
            }
            // Define middle bound of our merge.
            int middle = (n / 2);
            // Create empty arrays for our left and right bounds.
            K[] left = new K[middle];
            K[] right = new K[n - middle];
        
            // Copy elements from our main array to our left and right bounds
            Array.Copy(sequence, 0, left, 0, left.Length);
            Array.Copy(sequence, middle, right, 0, right.Length);

            // Recursion to further split array.
            MergeSort(left, comparer);
            MergeSort(right, comparer);
            // Call for a merge on the left and right bounds.
            Merge(sequence, left, right, comparer);

        }

        private static void Merge<K>(K[] sequence, K[] left, K[] right, IComparer<K> comparer)
        {
            int i = 0;
            int j = 0;

            // 'i' represents index of left-bound, 'j' represents index of right bound. (i + j) represents index of the whole array.
            while((i + j) < sequence.Length)
            {
                // Finally implement our comparer on our left-bound and right-bound elements
                if (j == right.Length || (i < left.Length && comparer.Compare(left[i], right[j]) <= 0))
                {
                    sequence[i + j] = left[i++];
                }
                else
                {
                    sequence[i + j] = right[j++];
                }
            }
        }
    }
}
