namespace SortingAlgorithms
{
    //O(n+k)
    public class CountingSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            var maxNumber = GetMaxNumber(numbers);

            var countArray = GetOccurrencesNumbers(numbers, maxNumber);

            PopulateResult(numbers, countArray);

            return numbers;
        }

        private static void PopulateResult(int[] numbers, int[] countArray)
        {
            var currentIndex = 0;
            for (int i = 0; i < countArray.Length; i++)
            {
                for (int j = 0; j < countArray[i]; j++)
                {
                    numbers[currentIndex] = i;
                    currentIndex++;
                }
            }
        }

        private static int[] GetOccurrencesNumbers(int[] numbers, int total)
        {
            var countArray = new int[total + 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                countArray[numbers[i]]++;
            }

            return countArray;
        }

        private static int GetMaxNumber(int[] numbers)
        {
            var maxNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                    maxNumber = numbers[i];
            }

            return maxNumber;
        }
    }
}
