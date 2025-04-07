using System;
using System.Collections.Generic;

     
namespace ConsoleApp4
    {
        class Book
        {
            public string Title;
            public string Author;
            public string ISBN;
            public bool Availability;

            public Book(string title, string author, string isbn, bool availability = true)
            {
                Title = title;
                Author = author;
                ISBN = isbn;
                Availability = availability;
            }
        }

        class Library
        {
            private List<Book> Books;

            public Library()
            {
                Books = new List<Book>();
            }

            public void AddBook(Book book)
            {
                Books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added ");
            }

            public void SearchBook(string title)
            {
                List<Book> searchbook = new List<Book>();

                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].Title.IndexOf(title) >= 0)
                    {
                    searchbook.Add(Books[i]);
                    }
                }

                if (searchbook.Count > 0)
                {
                    Console.WriteLine("Books found");
                    for (int i = 0; i < searchbook.Count; i++)
                    {
                        Console.WriteLine($"Title: {searchbook[i].Title}, Author: {searchbook[i].Author}, Available: {searchbook[i].Availability}");
                    }
                }
                else
                {
                    Console.WriteLine("No books found");
                }
            }

            public void BorrowBook(string title)
            {
                List<Book> borrowbook = new List<Book>();

                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].Title.IndexOf(title) >= 0 && Books[i].Availability)
                    {
                    borrowbook.Add(Books[i]);
                    }
                }

                if (borrowbook.Count > 0)
                {
                    for (int i = 0; i < borrowbook.Count; i++)
                    {
                    borrowbook[i].Availability = false;
                        Console.WriteLine($"You have borrowed '{borrowbook[i].Title}'");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{title}' is not availabl");
                }
            }

            public void ReturnBook(string title)
            {
                List<Book> returnBook = new List<Book>();

                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[i].Title.IndexOf(title) >= 0 && !Books[i].Availability)
                    {
                    returnBook.Add(Books[i]);
                    }
                }

                if (returnBook.Count > 0)
                {
                    for (int i = 0; i < returnBook.Count; i++)
                    {
                    returnBook[i].Availability = true;
                        Console.WriteLine($"Book '{returnBook[i].Title}' has been returned");
                    }
                }
                else
                {
                    Console.WriteLine($"Book '{title}' was not borrowed");
                }
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                Library library = new Library();

                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
                library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

                Console.WriteLine("\nSearching and borrowing books...");
                library.SearchBook("Gatsby");
                library.BorrowBook("Gatsby");
                library.SearchBook("1984");
                library.BorrowBook("1984");
                library.BorrowBook("Harry Potter");

                Console.WriteLine("\nReturning books...");
                library.ReturnBook("Gatsby");
                library.ReturnBook("Harry Potter");

                Console.ReadLine();
            }
        }
    }



