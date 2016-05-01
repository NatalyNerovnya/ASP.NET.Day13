using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeClasesTests
{
    public class Book : IComparable<Book>
    {
        #region Properties
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Pages { get; private set; }
        public int Year { get; private set; }
        private static int nameId = 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Create instance of Book
        /// </summary>
        /// <param name="name">Name of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="year">Realeased</param>
        public Book(string author, string name, int pages, int year)
        {
            if(author == null || name == null)
                throw new ArgumentNullException();
            if (pages <= 0 || (year <= 700 && year > DateTime.Today.Year))
                throw new ArgumentException();
            Name = name;
            Author = author;
            Pages = pages;
            Year = year;
        }

        /// <summary>
        /// Create instance of Book
        /// </summary>
        /// <param name="name">Name of the Book(optional)</param>
        public Book(string name = "Unknown")
        {
            Name = name + nameId.ToString();
            nameId++;
            Author = string.Empty;
            Pages = 0;
            Year = 0;
        }
        #endregion


        /// <summary>
        /// Compare books by Name
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>Int32</returns>
        public int CompareTo(Book other)
        {
            if(other == null)
                throw new ArgumentNullException();
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"Name: {Name} \r\nAuthor: {Author} \r\nYear: {Year.ToString()} \r\nPages: {Pages.ToString()}\r\n";
        }

    }
}

