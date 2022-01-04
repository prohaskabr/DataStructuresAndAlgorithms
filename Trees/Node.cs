namespace Trees
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
    }
}
