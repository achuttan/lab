using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Algorithms
{
    public static class Sorting
    {
        public static List<int> QuickSort(List<int> array, int start, int end)
        {
            if (start < end)
            {
                // Partition the array into two based on a pivot item. The array items to left of pivot is smaller and those on right are greater than the pivot item.
                int partitionIndex = PartitionArray(array, start, end);
                // Recursively sort the partitions
                QuickSort(array, start, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, end);
            }
            
            return array;
        }

        private static int PartitionArray(List<int> list, int start, int end)
        {
            int partitionIndex = start; // Start from first item
            int pivotItem = list[end]; // Assume last item as pivot

            // Check all items from start to the last but one index of array
            for (int i = start; i < end; i++)
            {
                if (list[i] <= pivotItem)
                {
                    // If current item is less than pivot item, swap the item at partition index with the current item. This keeps the current item on the left partition.
                    // If the partition index and current index is the same, the item remains in the same position.
                    int temp1 = list[i];
                    list[i] = list[partitionIndex];
                    list[partitionIndex] = temp1;
                    // Increment the partition index
                    partitionIndex++;
                }
            }

            // By now all items till the partition index should be less than the pivot which is still the last item. 
            // Swap them to get the pivot item to its final position.
            int temp2 = list[end];
            list[end] = list[partitionIndex];
            list[partitionIndex] = temp2;

            return partitionIndex;
        }
    }
}
