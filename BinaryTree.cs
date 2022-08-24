using System;
using System.Collections.Generic;
					
public class Program
{
    public static void Main()
    {
        BinarySearchTree newBinaryTree = new BinarySearchTree();
        newBinaryTree.addNode(9);
        newBinaryTree.addNode(5);
        newBinaryTree.addNode(11);
        newBinaryTree.addNode(3);
        newBinaryTree.addNode(7);


        Console.WriteLine("Depth-first (preorder): ");
        newBinaryTree.depthPreOrder(newBinaryTree.root);
        Console.WriteLine();

        Console.WriteLine("Breadth-first: ");
        newBinaryTree.breadthFirst(newBinaryTree.root);
        Console.WriteLine();


    }
}

class Node
{
    public Node left, right;
    public int number;
}

class BinarySearchTree
{
    public Node root;

    public int addNode(int number)
    {
        Node before = null, after = this.root;

        while (after != null)
        {
            before = after;
            if (number < after.number)
            {
                after = after.left;
            }
            else if (number > after.number)
            {
                after = after.right;
            }
            else
            {
                return 0;
            }
        }

        Node newNode = new Node();
        newNode.number = number;

        if (this.root == null)
        {
            this.root = newNode;
        }
        else
        {
            if (number < before.number)
            {
                before.left = newNode;
            }
            else
            {
                before.right = newNode;
            }
        }
        return 0;
    }

    public void depthPreOrder(Node parent)
    {
        if (parent != null)
        {
            Console.Write(parent.number + " ");
            depthPreOrder(parent.left);
            depthPreOrder(parent.right);
        }
    }

    public void breadthFirst(Node parent)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(parent);
        while (queue.Count != 0)
        {
            Node tempNode = queue.Dequeue();
            Console.Write(tempNode.number + " ");

            if (tempNode.left != null)
            {
                queue.Enqueue(tempNode.left);
            }

            if (tempNode.right != null)
            {
                queue.Enqueue(tempNode.right);
            }
        }
    }
}

