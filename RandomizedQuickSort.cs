using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    public class RandomizedQuickSort : ISorter
    {
        public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
        {
            QuickSort(sequence, comparer, 0, sequence.Length-1);
        }
        public static void QuickSort<K>(K[] sequence, IComparer<K> comparer, int left, int right)
        {
            // If left == right, we're done merging.
            if(left < right)
            {
                // Assign our pivot index a random value
                int pivotIndex = randomPartition(sequence, left, right, comparer);
                // Pass left bound and (pivot index - 1) to define left side of merge
                QuickSort(sequence, comparer, left, pivotIndex - 1);
                // Pass (pivot index + 1) as left bound and pass right bound to define right side of merge.
                QuickSort(sequence, comparer, pivotIndex + 1, right);
            }

        }

        public static int randomPartition<K>(K[] arr, int left, int right, IComparer<K> comparer)
        {
            Random rnd = new Random();
            // Selects random index within the bounds of our left and right merges.
            int pivotIndex = rnd.Next(left, right);
            // Define our pivot element
            K pivot = arr[pivotIndex];
            // Move the right-bound to our pivot element
            arr[pivotIndex] = arr[right];
            // Finally move the pivot element to our right bound.
            arr[right] = pivot;
            // Pass our array with the defined random pivot, left and right bounds.
            return Partition(arr, left, right, comparer);

        }

        public static int Partition<K>(K[] arr, int left, int right, IComparer<K> comparer)
        {
            // Retrieve our pivot element from the right-bound element.
            K pivot = arr[right];
            // Assign our left-bound to a new variable to be used in iteration.
            int i = left;
            // Iterate from our left-bound to an element before the right-bound
            for( int j = left; j < right; j++)
            {
                // Compare our pivot element with the current element.
                if(comparer.Compare(pivot, arr[j]) > 0)
                {
                    // Swap our elements @ indexes i and j
                    Swap(arr, i, j);
                    // Iterate i.
                    i++;
                }
            }
            // Assign our new pivot index element to the right-bound element
            arr[right] = arr[i];
            arr[i] = pivot;
            // Finally, return the new pivot index.
            return i;
        }

        private static void Swap<K>(K[] arr, int One, int Two)
        {
            K temp = arr[One];
            arr[One] = arr[Two];
            arr[Two] = temp;
        }
    }


}