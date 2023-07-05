using System;
using System.Collections.Generic;

namespace BooksAndAudiobooksRental
{
    public class Book
    {
        public string author;
        public string title;
        public bool available;
    }

    public class Audiobook : Book
    {
        public string narrator;
    }

    public class Collection : Audiobook
    {
        public List<Book> books = new List<Book>();
        public List<Audiobook> audiobooks = new List<Audiobook>();

        public void Add()
        {
            Console.WriteLine("Do you want to add a book or an audiobook?");
            Console.WriteLine("1 - Book, 2 - Audiobook");
            string response = Console.ReadLine();

            if (response == "1")
            {
                Console.WriteLine("Enter the author, followed by the title of the book");
                books.Add(new Book()
                {
                    author = Console.ReadLine(),
                    title = Console.ReadLine(),
                    available = true
                });
            }
            else if (response == "2")
            {
                Console.WriteLine("Enter the author, title, and narrator of the audiobook");
                audiobooks.Add(new Audiobook()
                {
                    author = Console.ReadLine(),
                    title = Console.ReadLine(),
                    narrator = Console.ReadLine(),
                    available = true
                });
            }
            else
            {
                Add();
            }
        }

        public void Display()
        {
            Console.WriteLine("Available books:");
            foreach (var book in books)
            {
                if (book.available)
                {
                    Console.WriteLine("Book available: " + book.title);
                }
            }

            Console.WriteLine("Available audiobooks:");
            foreach (var audiobook in audiobooks)
            {
                if (audiobook.available)
                {
                    Console.WriteLine("Audiobook available: " + audiobook.title);
                }
            }
        }

        public void RentBook()
        {
            Console.WriteLine("Which book would you like to rent?");
            Console.WriteLine("Available books:");
            List<Book> availableBooks = new List<Book>();

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                if (book.available)
                {
                    Console.WriteLine(i + 1 + ". " + book.title);
                    availableBooks.Add(book);
                }
            }

            int response = Convert.ToInt32(Console.ReadLine());

            if (response >= 1 && response <= availableBooks.Count)
            {
                Book selectedBook = availableBooks[response - 1];
                selectedBook.available = false;
                Console.WriteLine("Thank you for renting the book: " + selectedBook.title);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Which book would you like to return?");
            List<Book> unavailableBooks = new List<Book>();

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                if (!book.available)
                {
                    Console.WriteLine(i + 1 + ". " + book.title);
                    unavailableBooks.Add(book);
                }
            }

            int response = Convert.ToInt32(Console.ReadLine());

            if (response >= 1 && response <= unavailableBooks.Count)
            {
                Book selectedBook = unavailableBooks[response - 1];
                selectedBook.available = true;
                Console.WriteLine("Thank you for returning the book: " + selectedBook.title);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the application!");
            Collection collection = new Collection();

            // Add sample books
            collection.books.Add(new Book()
            {
                author = "George Orwell",
                title = "1984",
                available = true
            });

            collection.books.Add(new Book()
            {
                author = "J.R.R. Tolkien",
                title = "The Lord of the Rings",
                available = true
            });

            collection.books.Add(new Book()
            {
                author = "Harper Lee",
                title = "To Kill a Mockingbird",
                available = true
            });

            // Add sample audiobooks
            collection.audiobooks.Add(new Audiobook()
            {
                author = "Agatha Christie",
                title = "Murder on the Orient Express",
                narrator = "Kenneth Branagh",
                available = true
            });

            collection.audiobooks.Add(new Audiobook()
            {
                author = "Michelle Obama",
                title = "Becoming",
                narrator = "Michelle Obama",
                available = true
            });

            collection.audiobooks.Add(new Audiobook()
            {
                author = "Stephen King",
                title = "The Shining",
                narrator = "Campbell Scott",
                available = true
            });

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose what you want to do");

                Console.WriteLine("1. Add a book or audiobook");
                Console.WriteLine("2. Display available books and audiobooks");
                Console.WriteLine("3. Rent a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Exit");

                int response;
                bool validResponse = int.TryParse(Console.ReadLine(), out response);

                if (validResponse)
                {
                    switch (response)
                    {
                        case 1:
                            collection.Add();
                            break;
                        case 2:
                            collection.Display();
                            break;
                        case 3:
                            collection.RentBook();
                            break;
                        case 4:
                            collection.ReturnBook();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid selection.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please enter a number.");
                }

            } while (true);
        }
    }
}
