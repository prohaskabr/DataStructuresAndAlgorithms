using SortingAlgorithms.Extensions;

namespace SortingAlgorithms
{
    //O(n^2)
    public class QuickSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            Sort(numbers, 0, numbers.Length - 1);

            return numbers;
        }

        private void Sort(int[] numbers, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = Partition(numbers, start, end);

            Sort(numbers, start, boundary - 1);
            Sort(numbers, boundary, end);
        }

        private int Partition(int[] numbers, int start, int end)
        {
            var pivot = numbers[end];
            var boundary = start - 1;

            for (var i = start; i <= end; i++)
            {
                if (numbers[i] <= pivot)
                {
                    boundary++;
                    numbers.Swap(i, boundary);
                }
            }
            return boundary;
        }
    }
}
