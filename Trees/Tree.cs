using Trees.Enums;

namespace Trees
{
    public abstract class Tree
    {
        private IOutputText output;
        private Queue<Node> nodesQueue;

        public Node Node { get; set; }

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
            VisitNodes(Node);
        }

        public void DepthFirstTraversal(TraversingOrder traversingOrder, IOutputText output)
        {
            this.output = output;

            switch (traversingOrder)
            {
                case TraversingOrder.PreOrder:
                    PreOrderTraversal(Node);
                    break;
                case TraversingOrder.InOrder:
                    InOrderTraversal(Node);
                    break;
                case TraversingOrder.PostOrder:
                    PostOrderTraversal(Node);
                    break;
                default:
                    break;
            }
        }

        protected abstract void InsertValue(int value);

        protected abstract bool FindValue(int value);

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

        private void PreOrderTraversal(Node node) {

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
