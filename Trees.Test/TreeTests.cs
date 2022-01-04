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

            tree.Node.Value.Should().Be(10);
            tree.Node.LeftNode.Should().BeNull();
            tree.Node.RightNode.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void TreeHasOneNode_NewValueIsSmall_InsertLeftNode(Tree tree)
        {
            const int expectedValue = 5;
            const int rootNodeValue = 10;
            tree.Insert(rootNodeValue);

            tree.Insert(expectedValue);

            tree.Node.Value.Should().Be(10);
            tree.Node.LeftNode.Should().NotBeNull();
            tree.Node.LeftNode.Value.Should().Be(expectedValue);
            tree.Node.RightNode.Should().BeNull();

        }

        [Theory]
        [MemberData(nameof(GetTrees))]
        public void TreeHasOneNode_NewValueIsGreater_InsertRightNode(Tree tree)
        {
            const int expectedValue = 15;
            const int rootNodeValue = 10;
            tree.Insert(rootNodeValue);

            tree.Insert(expectedValue);

            tree.Node.Value.Should().Be(10);
            tree.Node.RightNode.Should().NotBeNull();
            tree.Node.RightNode.Value.Should().Be(expectedValue);
            tree.Node.LeftNode.Should().BeNull();

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

            tree.Node.Value.Should().Be(10);

            tree.Node.LeftNode.Value.Should().Be(05);
            tree.Node.LeftNode.LeftNode.Value.Should().Be(03);
            tree.Node.LeftNode.RightNode.Value.Should().Be(07);

            tree.Node.RightNode.Value.Should().Be(15);
            tree.Node.RightNode.LeftNode.Value.Should().Be(12);
            tree.Node.RightNode.RightNode.Value.Should().Be(20);
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
            tree.Node.Value.Should().Be(searchedValue);
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
            tree.Node.LeftNode.Value.Should().Be(searchedValue);
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
            tree.Node.RightNode.Value.Should().Be(searchedValue);
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

        public static IEnumerable<Tree[]> GetTrees()
        {
            yield return new Tree[] { new RecursiveBinaryTree() };
            yield return new Tree[] { new IterativeBinaryTree() };
        }
    }
}

