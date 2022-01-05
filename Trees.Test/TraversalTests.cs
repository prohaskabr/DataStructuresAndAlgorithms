using NSubstitute;
using Trees.BinaryTree;
using Trees.Enums;
using Xunit;

namespace Trees.Test
{
    /*
                 20
               /    \
             10      30
            /  \    /  
           06  14  24 
          /  \       \
         03  08      26
     */
    public class TraversalTests
    {
        [Fact]
        public void BreadthFirst_TraversalTreeInExpectedOrder()
        {
            var outputText = Substitute.For<IOutputText>();
            var tree = new RecursiveBinaryTree();
            PopulateTree(tree);

            tree.BreadthFirstTraversal(outputText);

            AssertOutputOrder(outputText, 20, 10, 30, 06, 14, 24, 03, 08, 26);
        }

        [Theory]
        [InlineData(TraversingOrder.PreOrder, 20, 10, 6, 3, 8, 14, 30, 24, 26)]
        [InlineData(TraversingOrder.InOrder, 3, 6, 8, 10, 14, 20, 24, 26, 30)]
        [InlineData(TraversingOrder.PostOrder, 3, 8, 6, 14, 10, 26, 24, 30, 20)]
        public void DepthFirst_TraversalTreeInExpectedOrder(TraversingOrder order, params int[] result)
        {
            var outputText = Substitute.For<IOutputText>();
            var tree = new RecursiveBinaryTree();
            PopulateTree(tree);

            tree.DepthFirstTraversal(order, outputText);

            AssertOutputOrder(outputText, result);
        }


        private static void AssertOutputOrder(IOutputText outputText, params int[] numbers)
        {
            outputText.Received(numbers.Length).Write(Arg.Any<int>());
            Received.InOrder(() =>
            {
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[0]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[1]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[2]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[3]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[4]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[5]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[6]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[7]));
                outputText.Received(1).Write(Arg.Is<int>(x => x == numbers[8]));
            });
        }

        private static void PopulateTree(RecursiveBinaryTree tree)
        {
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(6);
            tree.Insert(14);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(24);
            tree.Insert(26);
        }
    }
}
