

using System;

namespace Algorithms_BinarySearchTree
{

    public class tree
    {
        public Node root { get; set; }

        public void Insert(int x)
        {
            if (root == null)
            {
                root = new Node() { value = x };
            }
            else
            {
                AddNode(root, new Node
                {
                    value = x
                });
            }

        }


        static void AddNode(Node node, Node add)
        {
            if (add.value < node.value)
            {
                // идти в левое поддерево
                if (node.left != null)
                {
                    AddNode(node.left, add);
                }
                else
                {
                    node.left = add;
                }
            }
            else if (add.value > node.value)
            {
                // идти в правое поддерево
                if (node.right != null)
                {
                    AddNode(node.right, add);
                }
                else
                {
                    node.right = add;
                }
            }
        }


        public void Traverse(Node node)
        {
            // заход в левое поддерево
            if (node.left != null)
            {
                Traverse(node.left);
            }

            // обработка
            Console.Write($" {node.value}");

            // заход в правое поддерево
            if (node.right != null)
            {
                Traverse(node.right);
            }
        }

        public void Search(int x)
        {

            var found = Search(root, x, level: 0, null);
            /*
            if (found.node != null)
              Console.WriteLine($"Нашли!  {found.node.value} на уровне {found.level} "); 
            else
                Console.WriteLine($"Не нашли значения {x} ");
            */
        }

        private (Node node, Node Parent) SearchMin(Node node, Node Parent)
        {
            Node minChild;


            if (node.left == null && node.right == null)
                minChild = null;

            else if (node.left == null)
                minChild = node.right;
            else if (node.right == null)
                minChild = node.left;
            else
            {
                minChild = node.left;
                Parent = node;
                while (minChild.right != null)
                {
                    Parent = minChild;
                    minChild = minChild.right;
                }
            }
            return (minChild, Parent);
        }

        static (Node node, int level, Node Parent) Search(Node node, int value, int level, Node Parent)
        {
            if (value < node.value)
            {
                if (node.left != null)
                {
                    return Search(node.left, value, level + 1, node);
                }
                else
                {
                    return (null, 0, node);
                }
            }
            else if (value > node.value)
            {
                if (node.right != null)
                {
                    return Search(node.right, value, level + 1, node);
                }
                else
                {
                    return (null, 0, node);
                }
            }
            else
            {
                return (node, level, Parent);
            }
        }

        public void Remove(int x)
        {
            var found = Search(root, x, 0, null);

            if (found.node == null)
            { 
            }
            else if (found.node.value == root.value && found.node.left == null)
            {
                root = found.node.right;
            }
            else
            {

                if (found.node.left != null && found.node.right != null)
                {
                    //Console.WriteLine($"Удаляем значение {x} с двумя потомками");
                    var minChild = SearchMin(found.node, found.Parent);
                    found.node.value = minChild.node.value;

                    removeConnect(minChild.node, minChild.Parent);

                }
                else
                {
                    //Console.WriteLine($"Удаляем значение {x} с одним потомком");
                    removeConnect(found.node, found.Parent);
                }
            }
        }



        static void removeConnect(Node node, Node parent)
        {
            Node child = null;
            if (node.left == null && node.right != null)
            {
                child = node.right;
            }
            else if (node.right == null && node.left != null)
            {
                child = node.left;
            }

            if (parent.left != null && parent.left.value == node.value)
            {
                parent.left = child;
            }
            else if (parent.right !=null && parent.right.value == node.value)
            {
                parent.right = child;
            }
        }


        public class Node
        {

            public int value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

        }
    }
}
