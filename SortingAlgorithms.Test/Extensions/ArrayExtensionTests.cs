using FluentAssertions;
using SortingAlgorithms.Extensions;
using Xunit;

namespace SortingAlgorithms.Test.Extensions
{
    public class ArrayExtensionTests
    {
        [Fact]
        public void SwapArrayItens()
        {

            var array = new[] { 3, 2, 1 };
            var expectedArray = new[] { 1, 2, 3 };

            array.Swap(0, 2);

            array.Should().BeEquivalentTo(expectedArray, opt => opt.WithStrictOrdering());
        }

        [Fact]
        public void FirstIndexIsOutOfIndex_notSwap()
        {
            var array = new[] { 3, 2, 1 };
            var expectedArray = new[] { 3, 2, 1 };

            array.Swap(-1, 2);

            array.Should().BeEquivalentTo(expectedArray, opt => opt.WithStrictOrdering());
        }

        [Fact]
        public void LastIndexIsOutOfIndex_notSwap()
        {
            var array = new[] { 3, 2, 1 };
            var expectedArray = new[] { 3, 2, 1 };

            array.Swap(0, 3);

            array.Should().BeEquivalentTo(expectedArray, opt => opt.WithStrictOrdering());
        }
    }
}
