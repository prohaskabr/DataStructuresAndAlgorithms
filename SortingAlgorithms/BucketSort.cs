namespace SortingAlgorithms
{
    //O(n^2)
    public class BucketSort : INumberSorter
    {
        private const int MaxBucket = 10;
        public int[] SortNumbers(int[] numbers)
        {
            List<List<int>> buckets = CreateBuckets(numbers);

            var insertIndex = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();

                foreach (var item in bucket)
                {
                    numbers[insertIndex] = item;
                    insertIndex++;
                }
            }

            return numbers;

        }

        private static List<List<int>> CreateBuckets(int[] numbers)
        {
            var buckets = new List<List<int>>();
            var maxNumberInCollection = numbers.Length > 0 ? numbers.Max() : 0;

            for (int i = 0; i < MaxBucket; i++)
            {
                buckets.Add(new List<int>());
            }

            foreach (var number in numbers)
            {
                buckets[number * (MaxBucket - 1) / maxNumberInCollection].Add(number);
            }

            return buckets;
        }
    }
}
