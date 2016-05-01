using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace BinaryTreeConsoleUI
{
    public class MyComparatorInt : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return -1;
            else if (x < y)
                return 1;
            else
                return 0;
        }
    }

    public class MyComparatorString : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < y.Length)
                return -1;
            else if (x.Length > y.Length)
                return 1;
            else
                return 0;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Tests with <int> with default Comparer");
            BinaryTree<int> intTree = new BinaryTree<int>();
            intTree.Add(1);
            intTree.Add(-4);
            intTree.Add(6, -3, 5, 9);

            Console.WriteLine("\n\n");
            foreach (var el in intTree)
                Console.WriteLine(el);

            intTree.Add(0);

            Console.WriteLine("\n\n");
            foreach (var el in intTree)
                Console.WriteLine(el);
            
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Tests with <int> with custom Comparer");
            BinaryTree<int> intTree1 = new BinaryTree<int>(new MyComparatorInt());
            intTree1.Add(1);
            intTree1.Add(-4);
            intTree1.Add(6, -3, 5, 9);

            Console.WriteLine("\n\n");
            foreach (var el in intTree1)
                Console.WriteLine(el);

            intTree1.Add(0);

            Console.WriteLine("\n\n");
            foreach (var el in intTree1)
                Console.WriteLine(el);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Tests with <string> with default Comparer");
            BinaryTree<string> stringTree = new BinaryTree<string>();
            stringTree.Add("a");
            stringTree.Add("t");
            stringTree.Add("s","r","p","o");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree)
                Console.WriteLine(el);

            stringTree.Add("Monday");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree)
                Console.WriteLine(el);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Tests with <string> with custom Comparer");
            BinaryTree<string> stringTree1 = new BinaryTree<string>(new MyComparatorString());
            stringTree1.Add("act");
            stringTree1.Add("theater");
            stringTree1.Add("srp", "Random Access Memory", "point", "override");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree1)
                Console.WriteLine(el);

            stringTree1.Add("Monday");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree1)
                Console.WriteLine(el);

            Console.ReadKey();
            Console.Clear();
        }
    }
}
