using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class BinarySearchTree
    {

        public Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                AddRecursively(value, root);
            }
        }

        private void AddRecursively(int value, Node node)
        {
            if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    AddRecursively(value, node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node(value);
                }
                else
                {
                    AddRecursively(value, node.right);
                }
            }
        }

        public int SumValues()
        {
            return SumValuesRecursively(root);
        }

        private int SumValuesRecursively(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.value + SumValuesRecursively(node.left) + SumValuesRecursively(node.right);
            }
        }
        public int CountInternalNodes()
        {
            return CountInternalNodesRecursively(root);
        }

        private int CountInternalNodesRecursively(Node node)
        {
            if (node == null || (node.left == null && node.right == null))
            {
                return 0;
            }
            else
            {
                return 1 + CountInternalNodesRecursively(node.left) + CountInternalNodesRecursively(node.right);
            }
        }
    }
}
