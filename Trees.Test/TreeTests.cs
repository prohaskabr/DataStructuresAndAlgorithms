using FluentAssertions;
using System.Collections.Generic;
using Trees.BinaryTree;
using Xunit;

namespace Trees.Test
{
    public class TreeTests
    {

        public TreeTests()
        {

        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void TreeHasNoNode_InsertRootNode(Tree tree)
        {
            const int expectedValue = 10;

            tree.Insert(expectedValue);

            tree.RootNode.Value.Should().Be(10);
            tree.RootNode.LeftNode.Should().BeNull();
            tree.RootNode.RightNode.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void TreeHasOneNode_NewValueIsSmall_InsertLeftNode(Tree tree)
        {
            const int expectedValue = 5;
            const int rootNodeValue = 10;
            tree.Insert(rootNodeValue);

            tree.Insert(expectedValue);

            tree.RootNode.Value.Should().Be(10);
            tree.RootNode.LeftNode.Should().NotBeNull();
            tree.RootNode.LeftNode.Value.Should().Be(expectedValue);
            tree.RootNode.RightNode.Should().BeNull();

        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void TreeHasOneNode_NewValueIsGreater_InsertRightNode(Tree tree)
        {
            const int expectedValue = 15;
            const int rootNodeValue = 10;
            tree.Insert(rootNodeValue);

            tree.Insert(expectedValue);

            tree.RootNode.Value.Should().Be(10);
            tree.RootNode.RightNode.Should().NotBeNull();
            tree.RootNode.RightNode.Value.Should().Be(expectedValue);
            tree.RootNode.LeftNode.Should().BeNull();

        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void MultipleNodes_CreateExpectedTree(Tree tree)
        {
            var values = new[] { 10, 05, 15, 03, 07, 12, 20 };

            foreach (var item in values)
            {
                tree.Insert(item);
            }

            tree.RootNode.Value.Should().Be(10);

            tree.RootNode.LeftNode.Value.Should().Be(05);
            tree.RootNode.LeftNode.LeftNode.Value.Should().Be(03);
            tree.RootNode.LeftNode.RightNode.Value.Should().Be(07);

            tree.RootNode.RightNode.Value.Should().Be(15);
            tree.RootNode.RightNode.LeftNode.Value.Should().Be(12);
            tree.RootNode.RightNode.RightNode.Value.Should().Be(20);
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void NoNode_returnFalse(Tree tree)
        {
            var result = tree.Find(1);

            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void NoNodeWithValue_returnFalse(Tree tree)
        {
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);

            var result = tree.Find(1);

            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void RootNodeHasSearchValue_returnTrue(Tree tree)
        {
            const int searchedValue = 1;
            tree.Insert(searchedValue);

            var result = tree.Find(searchedValue);

            result.Should().BeTrue();
            tree.RootNode.Value.Should().Be(searchedValue);
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void LeftNodeHasSearchValue_returnTrue(Tree tree)
        {
            const int searchedValue = 1;
            tree.Insert(10);
            tree.Insert(searchedValue);

            var result = tree.Find(searchedValue);

            result.Should().BeTrue();
            tree.RootNode.LeftNode.Value.Should().Be(searchedValue);
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void RightNodeHasSearchValue_returnTrue(Tree tree)
        {
            const int searchedValue = 10;
            tree.Insert(5);
            tree.Insert(searchedValue);

            var result = tree.Find(searchedValue);

            result.Should().BeTrue();
            tree.RootNode.RightNode.Value.Should().Be(searchedValue);
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void NodeValueExist_returnTrue(Tree tree)
        {
            const int searchedValue = 10;
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(searchedValue);

            var result = tree.Find(searchedValue);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(2, 7, 4, 9, 1, 6, 8, 10)]
        [InlineData(3, 10, 3, 15, 1, 2, 13, 16, 18)]
        public void CalculateTreeHeight_returnHeight(int expectedHeight, params int[] treeNodes)
        {
            var tree = new TestTree();

            foreach (var item in treeNodes)
            {
                tree.Insert(item);
            }

            var result = tree.Height();

            result.Should().Be(expectedHeight);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5, 10, 20, 5)]
        [InlineData(3, 10, 5, 6, 3, 20, 15, 21)]
        [InlineData(3, 10, 5, 6, 3, 20, 15, 21, 25)]
        public void CalculateTreeMinValuet_returnMinValue(int expectedMinValue, params int[] treeNodes)
        {
            var tree = new TestTree();

            foreach (var item in treeNodes)
            {
                tree.Insert(item);
            }

            var result = tree.MinValueFromBinarySearchTree();

            result.Should().Be(expectedMinValue);
        }

        [Fact]
        public void TreeAreEquals_returnTrue()
        {
            var tree = new TestTree();
            var otherTree = new TestTree();

            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(30);

            otherTree.Insert(20);
            otherTree.Insert(10);
            otherTree.Insert(30);

            var result = tree.Equals(otherTree);

            result.Should().BeTrue();
        }

        [Fact]
        public void TreeAreNotEquals_returnFalse()
        {
            var tree = new TestTree();
            var otherTree = new TestTree();

            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(30);
            tree.Insert(12);

            otherTree.Insert(20);
            otherTree.Insert(10);
            otherTree.Insert(30);

            var result = tree.Equals(otherTree);

            result.Should().BeFalse();
        }

        public static IEnumerable<Tree[]> GetTrees()
        {
            yield return new Tree[] { new RecursiveBinaryTree() };


            yield return new Tree[] { new IterativeBinaryTree() };
        }
    }
}

