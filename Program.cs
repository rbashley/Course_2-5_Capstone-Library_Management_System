using System;

class LibraryManagement
{
    static void Main()
    {
        string[] books = new string[5];

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("Choose an option: add, remove, display, exit");
            string? input = Console.ReadLine();
            string choice = input == null ? "" : input.Trim().ToLower();

            if (choice == "add")
            {
                // Ensure there is space before adding a book
                if (HasSpace(books))
                {
                    AddBook(books);
                }
                else
                {
                    Console.WriteLine("Library is full, unable to add more books.");
                }
            }
            else if (choice == "remove")
            {
                // Ensure there are books before allowing removal
                if (HasBooks(books))
                {
                    RemoveBook(books);
                }
                else
                {
                    Console.WriteLine("No books available to remove.");
                }
            }
            else if (choice == "display")
            {
                DisplayBooks(books);
            }
            else if (choice == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please try again.");
            }
        }
    }

    static void AddBook(string[] books)
    {
        Console.Write("Enter the book title to add: ");
        string? input = Console.ReadLine();
        string bookTitle = input == null ? "" : input.Trim();

        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i]))
            {
                books[i] = bookTitle;
                Console.WriteLine($"'{bookTitle}' has been added.");
                return;
            }
        }

        Console.WriteLine("Library is full, unable to add more books.");
    }

    static void RemoveBook(string[] books)
    {
        Console.Write("Enter the book title to remove: ");
        string? input = Console.ReadLine();
        string bookTitle = input == null ? "" : input.Trim();

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] == bookTitle)
            {
                books[i] = "";
                Console.WriteLine($"'{bookTitle}' has been removed.");
                return;
            }
        }

        Console.WriteLine("Book not found in the library.");
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("\nBooks in the Library:");
        bool empty = true;

        foreach (string book in books)
        {
            if (!string.IsNullOrEmpty(book))
            {
                Console.WriteLine("- " + book);
                empty = false;
            }
        }

        if (empty)
        {
            Console.WriteLine("No books available in the library.");
        }
    }

    // Helper function to check if there are any books in the library
    static bool HasBooks(string[] books)
    {
        foreach (string book in books)
        {
            if (!string.IsNullOrEmpty(book))
            {
                return true;
            }
        }
        return false;
    }

    // Helper function to check if there is space to add a book
    static bool HasSpace(string[] books)
    {
        foreach (string book in books)
        {
            if (string.IsNullOrEmpty(book))
            {
                return true;
            }
        }
        return false;
    }
}