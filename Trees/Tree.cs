using Trees.Enums;

namespace Trees
{
    public abstract class Tree
    {
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
            output.Write("Starting process");
        }

        public void DepthFirstTraversal(TraversingOrder traversingOrder, IOutputText output) {
            output.Write("Starting process");
        }

        protected abstract void InsertValue(int value);

        protected abstract bool FindValue(int value);
    }
}
