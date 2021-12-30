using SortingAlgorithms.Extensions;

namespace SortingAlgorithms
{
    //O(n^2)
    public class InsertionSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var index = i - 1;
                var currentValue = numbers[i];

                while (index >= 0 && numbers[index] > currentValue)
                {
                    numbers[index + 1] = numbers[index];
                    index--;
                }

                numbers[index + 1] = currentValue;
            }

            return numbers;
        }
    }
}
