namespace SortingAlgorithms.Extensions
{
    public static class ArrayExtension
    {

        public static void Swap<T>(this T[] array, int sourceIndex, int targetIndex)
        {
            if (HasInvalidIndices(array, sourceIndex, targetIndex))
                return;

            var tempValue = array[sourceIndex];
            array[sourceIndex] = array[targetIndex];
            array[targetIndex] = tempValue;
        }

        private static bool HasInvalidIndices<T>(T[] array, int sourceIndex, int targetIndex)
        {
            return sourceIndex < 0 || targetIndex < 0 || sourceIndex > array.Length - 1 || targetIndex > array.Length - 1;
        }
    }
}
