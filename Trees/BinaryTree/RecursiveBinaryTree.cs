namespace Trees.BinaryTree
{
    public class RecursiveBinaryTree : Tree
    {
        protected override bool FindValue(int value)
        {
            if (RootNode is null)
                return false;

            return TryFindValue(RootNode, value);
        }


        protected override void InsertValue(int value)
        {
            if (RootNode is null)
                RootNode = new Node(value);
            else
                TryInsertValue(RootNode, value);
        }

        private bool TryFindValue(Node node, int value)
        {
            if (node is null)
                return false;

            if (node.Value == value)
                return true;
            else if (value < node.Value)
                return TryFindValue(node.LeftNode, value);
            else
                return TryFindValue(node.RightNode, value);
        }

        private void TryInsertValue(Node node, int value)
        {
            if (value < node.Value)
            {
                if (node.LeftNode is null)
                {
                    node.LeftNode = new Node(value);
                    return;
                }

                TryInsertValue(node.LeftNode, value);
            }
            else
            {
                if (node.RightNode is null)
                {
                    node.RightNode = new Node(value);
                    return;
                }

                TryInsertValue(node.RightNode, value);
            }
        }
    }
}
