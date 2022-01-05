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

        public void BreadthFirstTraversal(IOutputText output) {
            this.output = output;
            nodesQueue = new Queue<Node>();
            VisitNodes(Node);
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

        public void DepthFirstTraversal(TraversingOrder traversingOrder, IOutputText output) {
            output.Write("Starting process");
        }

        protected abstract void InsertValue(int value);

        protected abstract bool FindValue(int value);
    }
}
