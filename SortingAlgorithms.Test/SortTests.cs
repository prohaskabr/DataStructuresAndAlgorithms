using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace SortingAlgorithms.Test
{
    public class SortTests
    {
        public SortTests()
        {

        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void EmptyCollection_returnEmptyCollection(INumberSorter sortObj)
        {
            var numbers = new int[0];

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(numbers, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void OneItemCollection_returnOneItemCollection(INumberSorter sortObj)
        {
            var numbers = new int[] { 1 };

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(numbers, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void CollectionAlreadySorted_returnSameCollection(INumberSorter sortObj)
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(numbers, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void CollectionWithTwoItems_returnSortedCollection(INumberSorter sortObj)
        {
            var numbers = new[] { 2, 1 };
            var expectedNumbers = new[] { 1, 2 };

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(expectedNumbers, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void CollectionWithMultipleItems_returnSortedCollection(INumberSorter sortObj)
        {
            var numbers = new[] { 2, 1, 6, 5, 4, 3, 10, 8, 9, 7 };
            var expectedNumbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(expectedNumbers, opt => opt.WithStrictOrdering());
        }

        [Theory]
        [MemberData(nameof(GetSortAlgorithms))]
        public void CollectionWithDuplicatedtems_returnSortedCollection(INumberSorter sortObj)
        {
            var numbers = new[] { 5, 4, 4, 3, 3, 3, 2, 1, 1, 5 };
            var expectedNumbers = new[] { 1, 1, 2, 3, 3, 3, 4, 4, 5, 5 };

            var result = sortObj.SortNumbers(numbers);

            result.Should().BeEquivalentTo(expectedNumbers, opt => opt.WithStrictOrdering());
        }

        public static IEnumerable<INumberSorter[]> GetSortAlgorithms()
        {
            yield return new INumberSorter[]{
                new BubbleSort(),
            };

            yield return new INumberSorter[]{
                new SelectionSort(),
            };

            yield return new INumberSorter[]{
                new InsertionSort(),
            };

            yield return new INumberSorter[]{
                new MergeSort(),
            };

            yield return new INumberSorter[] {
            new QuickSort(),
            };

            yield return new INumberSorter[] {
            new CountingSort(),
            };

            yield return new INumberSorter[] {
            new BucketSort(),
            };
        }
    }
}
