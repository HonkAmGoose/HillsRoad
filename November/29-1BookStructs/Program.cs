using System;
using System.IO;

namespace BookStructs
{
    struct Book
    {
        // Declare the fields for the Books struct
        public string title;
        public string author;
        public string genre;
        public long isbn; // long is a 64-bit integer for the 13 digit isbn
        public double price;
        public int pages;
    }

    class Program
    {
        const string FILENAME = "books.bin";
        static void Main(string[] args)
        {
            // Declare Book1 of type Book
            Book book1 = new Book();

            // Assign values to the Book1 object
            book1.title = "A promised land";
            book1.author = "Barack Obama";
            book1.genre = "Politics";
            book1.isbn = 9780525633761;
            book1.price = 25.00;
            book1.pages = 768;

            Book book2 = new Book();
            book2.title = "Ready Player One";
            book2.author = "Ernest Cline";
            book2.genre = "Sci-fi";
            book2.isbn = 9780553459388;
            book2.price = 4.99;
            book2.pages = 374;

            Book[] books = new Book[2];
            books[0] = book1;
            books[1] = book2;

            OutputBook(books[0]);
            Console.WriteLine();
            OutputBook(books[1]);
        }
        static void OutputBook(Book book)
        {
            Console.WriteLine("The title is: " + book.title);
            Console.WriteLine("The author is: " + book.author);
            Console.WriteLine("The genre is: " + book.genre);
            Console.WriteLine("The isbn is: " + book.isbn);
            Console.WriteLine("The price is: " + book.price);
            Console.WriteLine("The number of pages is: " + book.pages);
        }
        static void OverwriteBook(Book book)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(FILENAME, FileMode.Create)))
            {

            }
        }
    }
}