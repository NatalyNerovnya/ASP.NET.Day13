using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTree<T> : CheckParameters, IEnumerable<T>
    {
        #region Fields
        private class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public T data;

        }
        private Node node;
        private readonly IComparer<T> comparer;
        #endregion

        #region Constructors
        public BinaryTree()
        {
            if (typeof(T).GetInterface("IComparable`1") != null)
                comparer = Comparer<T>.Default;
            else
                throw new InvalidOperationException("Not implement the interface \"IComparable<>\"");
        }

        public BinaryTree(IComparer<T> comparer)
        {
            CheckRef(comparer);
            this.comparer = comparer;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adding elements
        /// </summary>
        /// <param name="arr">Array of elements</param>
        public void Add(params T[] arr)
        {
            CheckRef(arr);
            for (int i = 0; i < arr.Length; i++)
                Add(arr[i], ref node);
        }

        /// <summary>
        /// Add one elemets to the tree
        /// </summary>
        /// <param name="n"></param>
        public void Add(T n)
        {
            Add(n, ref node);
        }

        /// <summary>
        /// Tell weather tree contain some element
        /// </summary>
        /// <param name="n">Element</param>
        /// <returns>True if element exist in tree</returns>
        public bool Contain(T n)
        {
            return Contain(n, node);
        }

        /// <summary>
        /// InOrderTravers
        /// </summary>
        /// <returns>Inumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in InOrderTravers(node))
                yield return element;
        }

        public IEnumerable<T> InOrderTravers()
        {
            return InOrderTravers(node);
        }
        public IEnumerable<T> PreOrderTravers()
        {
            return PreOrderTravers(node);
        }
        public IEnumerable<T> PostOrderTravers()
        {
            return PostOrderTravers(node);
        }
        #endregion

        #region Private Methods
        #region Travers
        private IEnumerable<T> PreOrderTravers(Node subtree)
        {
            yield return subtree.data;
            if (subtree.left != null)
                foreach (var el in PreOrderTravers(subtree.left))
                    yield return el;
            if (subtree.right != null)
                foreach (var el in PreOrderTravers(subtree.right))
                    yield return el;
        }

        private IEnumerable<T> PostOrderTravers(Node subtree)
        {
            if (subtree.left != null)
                foreach (var el in PostOrderTravers(subtree.left))
                    yield return el;
            if (subtree.right != null)
                foreach (var el in PostOrderTravers(subtree.right))
                    yield return el;
            yield return subtree.data;
        }

        private IEnumerable<T> InOrderTravers(Node subtree)
        {
            if (subtree.left != null)
                foreach (var el in InOrderTravers(subtree.left))
                    yield return el;
            yield return subtree.data;
            if (subtree.right != null)
                foreach (var el in InOrderTravers(subtree.right))
                    yield return el;
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsEmpty(Node tree)
        {
            if (tree == null)
                return true;
            return false;
        }

        private void Add(T n, ref Node subtree)
        {
            if (IsEmpty(subtree))
            {
                subtree = new Node();
                subtree.data = n;
            }
            else if (comparer.Compare(n, subtree.data) > 0)
            {
                Add(n, ref subtree.right);
                subtree.right.parent = subtree;
            }
            else
            {
                Add(n, ref subtree.left);
                subtree.left.parent = subtree;
            }
        }

        private bool Contain(T n, Node subtree)
        {
            if (IsEmpty(subtree))
                return false;

            if (comparer.Compare(n, subtree.data) == 0)
                return true;
            else if (comparer.Compare(n, subtree.data) > 0)
                return Contain(n, subtree.right);
            else
                return Contain(n, subtree.left);
        }
        #endregion

    }
}
