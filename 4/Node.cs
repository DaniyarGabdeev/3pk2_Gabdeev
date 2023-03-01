using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }
}
