using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using BinaryTreeClasesTests;

namespace BinaryTreeConsoleUI
{
    #region Comparer Classes
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

    public class CompareByYear : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();

            return first.Year.CompareTo(second.Year);
        }

    }

    public class PointComparator : IComparer<Point>
    {
        public int Compare(Point first, Point second)
        {
            return (first.X + second.X).CompareTo(second.X + second.Y);
        }
    }
    #endregion

    class Program
    {

        static void Main(string[] args)
        {
            #region Tests with <int> with default Comparer
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

            Console.WriteLine(String.Format("Contain 5? - {0}.\nContain 12312? - {1}",intTree.Contain(5), intTree.Contain(12312)));

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Tests with <int> with custom Comparer
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
            #endregion

            #region Tests with <string> with default Comparer
            Console.WriteLine("Tests with <string> with default Comparer");
            BinaryTree<string> stringTree = new BinaryTree<string>();
            stringTree.Add("a");
            stringTree.Add("t");
            stringTree.Add("s", "r", "p", "o");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree)
                Console.WriteLine(el);

            stringTree.Add("Monday");

            Console.WriteLine("\n\n");
            foreach (var el in stringTree)
                Console.WriteLine(el);


            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Tests with <string> with custom Comparer
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
            Console.WriteLine(String.Format("\nContain srp? - {0}.\nContain s? - {1}", stringTree1.Contain("srp"), stringTree1.Contain("s")));


            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Tests with <Book> with default Comparer
            Console.WriteLine("Tests with <Book> with default Comparer");
            Book book1 = new Book("Lewis Carroll", "Alice in Wonderland", 890, 1865);
            Book book2 = new Book("Patrick Süskind", "Perfume: The Story of a Murderer", 1029, 1985);
            Book book3 = new Book("Leo Tolstoy", "War and Peace", 1225, 1869);

            BinaryTree<Book> bookTree = new BinaryTree<Book>();
            bookTree.Add(book2, book1);

            Console.WriteLine("\n\n");
            foreach (var el in bookTree.PostOrderTravers())
                Console.WriteLine(el);

            bookTree.Add(book3);
            Console.WriteLine("\n\n");
            foreach (var el in bookTree.PostOrderTravers())
                Console.WriteLine(el);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Tests with <Book> with custom Comparer
            Console.WriteLine("Tests with <Book> with custom Comparer");

            bookTree = new BinaryTree<Book>(new CompareByYear());
            bookTree.Add(book3, book1);

            Console.WriteLine("\n\n");
            foreach (var el in bookTree)
                Console.WriteLine(el);

            bookTree.Add(book2);
            Console.WriteLine("\n\n");
            foreach (var el in bookTree)
                Console.WriteLine(el);
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Tests with <Point> with custom Comparer
            Console.WriteLine("Tests with <Point> with custom Comparer");

            BinaryTree<Point> pointTree = new BinaryTree<Point>(new PointComparator());
            pointTree.Add(new Point(0, 0), new Point(2, 2), new Point(-4, 3));

            Console.WriteLine("\n\n");
            foreach (var el in pointTree)
                Console.WriteLine(el);

            pointTree.Add(new Point(0, 1), new Point(1, 2), new Point(2, 1));
            Console.WriteLine("\n\n");
            foreach (var el in pointTree)
                Console.WriteLine(el);
            Console.ReadKey();
            Console.Clear();
            #endregion
        }
    }
}
