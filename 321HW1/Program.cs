using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _321HW1
{
    class Program
    {
        //main function
        static void Main(string[] args)
        {
            //local variables
            string userInput = null;
            string[] inputString = null;
            int value = 0;
            BST tree = new BST();
            Node root = null;

            //prompt user input
            Console.WriteLine("Enter a collection of numbers between [0-100], separated by spaces:");
            userInput = Console.ReadLine(); //read user input
            inputString = userInput.Split(' '); //split user input

            for (int i = 0; i < inputString.Length; i++)
            {
                value = Int32.Parse(inputString[i]);
                if (value >= 0 && value <= 100)
                {
                    root = tree.Insert(root, value);
                }
            }

            //print tree
            Console.Write("Tree contents: ");
            tree.SortedPrint(root);
            Console.WriteLine();

            //print count
            tree.CountPrint();

            //print height
            Console.WriteLine("Number of levels: " + tree.Height(root));

            //print minimum possible height
            Console.WriteLine("Minimum number of levels the tree can have: " + tree.MinHeight(root));

            //program done
            Console.WriteLine("Program Done");
            Console.ReadLine();
        }

        class Node
        {
            public int val; //value of node
            public Node left; //left node
            public Node right; //right node
        }

        class BST
        {
            private int count; //keeps count of number of values inserted
            //insert function
            public Node Insert(Node root, int newVal)
            {
                if (root == null) //set root if null
                {
                    root = new Node();
                    root.val = newVal;
                    count++; //increment value count after insert
                }

                else if (newVal < root.val) //values smaller than root go left
                {
                    root.left = Insert(root.left, newVal);
                }

                else if (newVal > root.val) //values bigger than node go right
                {
                    root.right = Insert(root.right, newVal);
                }

                return root;
            }
            public void SortedPrint(Node root)
            {
                //check if null
                if (root != null)
                {
                    //move left
                    SortedPrint(root.left);
                    //output data
                    Console.Write((root.val) + " ");
                    //move right
                    SortedPrint(root.right);
                }
                else return;
            }
            public void CountPrint()
            {
                //print value of count
                Console.WriteLine("Number of nodes: " + (count)); 
            }

            public int Height(Node root)
            {
                if (root != null)
                {
                    //recurse for max length between left and right subtree
                    return Math.Max(Height(root.left), Height(root.right)) + 1;
                }
                else return 0;
            }

            public int MinHeight(Node root)
            {
                //formula is log2(n)+1 as learned in advanced data structures
                double tempHeight = Math.Log10(2)*count + 1;
                //convert to whole number by parse to int
                int minHeight = Convert.ToInt32(tempHeight);
                return minHeight;
            }
        }
    }
}
