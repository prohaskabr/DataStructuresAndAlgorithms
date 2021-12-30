using SortingAlgorithms.Extensions;

namespace SortingAlgorithms
{
    //O(n^2)
    public class BubbleSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            return Sort(numbers);
        }

        private int[] Sort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var isSorted = true;
                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j] < numbers[j - 1])
                    {
                        numbers.Swap( j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    break;
            }

            return numbers;
        } 
    }
}
