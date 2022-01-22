using Trees.Enums;

namespace Trees.BinaryTree
{
    public abstract class Tree
    {
        private IOutputText output;
        private Queue<Node> nodesQueue;

        public Node RootNode { get; set; }

        public void Insert(int value)
        {
            InsertValue(value);
        }

        public bool Find(int value)
        {
            return FindValue(value);
        }

        public void BreadthFirstTraversal(IOutputText output)
        {
            this.output = output;
            nodesQueue = new Queue<Node>();
            VisitNodes(RootNode);
        }

        public void DepthFirstTraversal(TraversingOrder traversingOrder, IOutputText output)
        {
            this.output = output;

            switch (traversingOrder)
            {
                case TraversingOrder.PreOrder:
                    PreOrderTraversal(RootNode);
                    break;
                case TraversingOrder.InOrder:
                    InOrderTraversal(RootNode);
                    break;
                case TraversingOrder.PostOrder:
                    PostOrderTraversal(RootNode);
                    break;
                default:
                    break;
            }
        }

        public int Height()
        {
            return GetHeight(RootNode);
        }

        public int MinValue()
        {
            return GetMinValue(RootNode);
        }

        public int MinValueFromBinarySearchTree()
        {
            if (RootNode is null)
                return -1;

            var current = RootNode;

            while (current.LeftNode != null)
            {
                current = current.LeftNode;
            }

            return current.Value;
        }

        public Node[] GetNodesAtLevel(int level)
        {
            return GetNodesAt(level, RootNode).ToArray();
        }

        private List<Node> GetNodesAt(int level, Node node)
        {
            if (level == 0)
                return new List<Node>{ node };

            var result = new List<Node>();

            if(node.LeftNode != null)
                result.AddRange(GetNodesAt(level -1, node.LeftNode));

            if (node.RightNode != null)
                result.AddRange(GetNodesAt(level - 1, node.RightNode));

            return result;
        }

        public bool Equals(Tree other)
        {
            return Equals(RootNode, other.RootNode);
        }

        protected abstract void InsertValue(int value);

        protected abstract bool FindValue(int value);


        private bool Equals(Node node1, Node node2)
        {

            if (node1 is null && node2 is null)
                return true;

            if (node1 is null || node2 is null)
                return false;

            return node1.Value.Equals(node2.Value) &&
                Equals(node1.LeftNode, node2.LeftNode) &&
                Equals(node1.RightNode, node2.RightNode);
        }

        private int GetMinValue(Node node)
        {
            if (node is null)
                return -1;

            if (node.IsLeaf)
                return node.Value;

            var leftValue = GetMinValue(node.LeftNode);
            var rightValue = GetMinValue(node.RightNode);

            if (leftValue == -1)
                leftValue = rightValue + 1;

            if (rightValue == -1)
                rightValue = leftValue + 1;

            return Math.Min(node.Value, Math.Min(leftValue, rightValue));
        }

        private int GetHeight(Node node)
        {
            if (node is null)
                return -1;

            if (node.IsLeaf)
                return 0;

            return Math.Max(GetHeight(node.LeftNode), GetHeight(node.RightNode)) + 1;
        }

        private void VisitNodes(Node node)
        {
            if (node is null)
                return;

            nodesQueue.Enqueue(node);

            while (nodesQueue.Any())
            {
                var currentNode = nodesQueue.Dequeue();
                output.Write(currentNode.Value);

                if (currentNode.LeftNode != null)
                    nodesQueue.Enqueue(currentNode.LeftNode);

                if (currentNode.RightNode != null)
                    nodesQueue.Enqueue(currentNode.RightNode);
            }
        }

        private void PreOrderTraversal(Node node)
        {

            if (node is null)
                return;

            output.Write(node.Value);
            PreOrderTraversal(node.LeftNode);
            PreOrderTraversal(node.RightNode);
        }

        private void InOrderTraversal(Node node)
        {
            if (node is null)
                return;

            InOrderTraversal(node.LeftNode);
            output.Write(node.Value);
            InOrderTraversal(node.RightNode);
        }

        private void PostOrderTraversal(Node node)
        {
            if (node is null)
                return;

            PostOrderTraversal(node.LeftNode);
            PostOrderTraversal(node.RightNode);
            output.Write(node.Value);
        }

    }
}
