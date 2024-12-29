using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DSA
{
    internal class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node(int val)
        {
            this.val = val;
        }
    }
    internal class Trees
    {
        internal static void Begin()
        {
            Node root = MakeTree(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            char choice = 'n';
            do
            {
                Console.WriteLine("Pick your choice:\n1. Inorder Traversal\n2. Preorder Traversal\n3. Postorder Traversal\n");
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        InorderTraversal(root);
                        Console.WriteLine();
                        break;
                    case '2':
                        PreorderTraversal(root);
                        Console.WriteLine();
                        break;
                    case '3':
                        PostorderTraversal(root);
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press 'n' to exit.\n");
                choice = char.ToLower(Console.ReadKey(true).KeyChar);
            } while (choice != 'n');
        }
        internal static Node MakeTree(int[] arr)
        {
            Node node = new Node(arr[0]);
            node.left = new Node(arr[1]);
            node.right = new Node(arr[2]);
            node.left.left = new Node(arr[3]);
            node.left.right = new Node(arr[4]);
            node.right.left = new Node(arr[5]);
            node.right.right = new Node(arr[6]);
            return node;
        }
        internal static void InorderTraversal(Node node)
        {
            if (node == null)
                return;
            InorderTraversal(node.left);
            Console.WriteLine(node.val);
            InorderTraversal(node.right);
        }
        internal static void PreorderTraversal(Node node)
        {
            if (node == null)
                return;
            Console.WriteLine(node.val);
            PreorderTraversal(node.left);
            PreorderTraversal(node.right);
        }
        internal static void PostorderTraversal(Node node)
        {
            if (node == null)
                return;
            PostorderTraversal(node.left);
            PostorderTraversal(node.right);
            Console.WriteLine(node.val);
        }
    }
}
