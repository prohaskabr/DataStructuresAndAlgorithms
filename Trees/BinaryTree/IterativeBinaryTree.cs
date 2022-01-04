﻿namespace Trees.BinaryTree
{
    public class IterativeBinaryTree : Tree
    {
        protected override bool FindValue(int value)
        {
            var current = Node;

            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftNode;
                else if (value > current.Value)
                    current = current.RightNode;
                else
                    return true;
            }

            return false;
        }


        protected override void InsertValue(int value)
        {
            if (Node is null)
            {
                Node = new Node(value);
                return;
            }

            var current = Node;

            while (current != null)
            {
                if (value < current.Value)
                {
                    if (current.LeftNode is null)
                    {
                        current.LeftNode = new Node(value);
                        return;
                    }

                    current = current.LeftNode;
                }
                else
                {
                    if (current.RightNode is null)
                    {
                        current.RightNode = new Node(value);
                        return;
                    }

                    current = current.RightNode;
                }
            }

        }
    }
}
