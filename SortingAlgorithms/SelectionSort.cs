using SortingAlgorithms.Extensions;

namespace SortingAlgorithms
{
    //O(n^2)
    public class SelectionSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)
            {
                int minIndex = getMinValueIndex(numbers, i);
                numbers.Swap(i, minIndex);
            }

            return numbers;
        }

        private static int getMinValueIndex(int[] numbers, int startIndex)
        {
            var minValueIndex = startIndex;

            for (int i = startIndex; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[minValueIndex])
                    minValueIndex = i;
            }

            return minValueIndex;
        }
    }
}
