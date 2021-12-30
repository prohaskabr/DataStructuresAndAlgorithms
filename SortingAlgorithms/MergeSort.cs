namespace SortingAlgorithms
{
    //O(n log(n))
    public class MergeSort : INumberSorter
    {
        public int[] SortNumbers(int[] numbers)
        {
            Sort(numbers);
            return numbers;
        }

        private void Sort(int[] numbers)
        {
            if (numbers.Length < 2)
                return;

            var middle = numbers.Length / 2;
            var left = new int[middle];
            var right = new int[numbers.Length - middle];

            for (var i = 0; i < middle; i++)
                left[i] = numbers[i];

            for (var i = middle; i < numbers.Length; i++)
                right[i - middle] = numbers[i];


            Sort(left);
            Sort(right);

            Merge(left, right, numbers);
        }

        private void Merge(int[] left, int[] right, int[] result)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            if (leftIndex < left.Length)
                AddRemaining(left, result, leftIndex, resultIndex);

            if (rightIndex < right.Length)
                AddRemaining(right, result, rightIndex, resultIndex);
        }

        private static void AddRemaining(int[] remaningData, int[] result, int fromIndex, int insertIndex)
        {
            while (fromIndex < remaningData.Length)
            {
                result[insertIndex] = remaningData[fromIndex];
                fromIndex++;
                insertIndex++;
            }
        }
    }
}
