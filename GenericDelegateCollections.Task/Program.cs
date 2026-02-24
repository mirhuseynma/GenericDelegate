using Utils;
using Utils.Models;
using Utils.Enums;
using System.Security.Cryptography.X509Certificates;
namespace GenericDelegateCollections.Task
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            User user1 = new User("Alice", "alice@example.com", Roles.Member);
            User user2 = new User("Bob", "bob@example.com", Roles.Member);
            
            Book book1 = new Book("The Great Bell", "F. Scott Fitzgerald", 600, false);
            Book book2 = new Book("The Great Gatsby", "Harper Lee", 250, false);
            Book book3 = new Book("To Kill a Mockingbird", "Harper Lee", 300, false);
            Book book4 = new Book("1984", "George Orwell", 400, false);
            Book book5 = new Book("Brave New World", "Aldous Huxley", 350, false);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            //library.DeleteBook(1);
            //library.GetBookByID(2);
            //library.GetAllBooks();
            //library.EditBookName(2);
            //library.GetAllBooks();
            library.FilterBookByPageCount(150, 340);

            // User object...
            
            
            Console.WriteLine("\nInput your information:  Name / Email / (Role: Member/Admin) ");
            Console.WriteLine("\nInput your name \n");
            string? name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                return;
            }
            Console.WriteLine("\nInput your Email ");
            string? email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email cannot be empty. Please enter a valid email.");
                return;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Invalid email format. Please enter a valid email.");
                return;
            }
            Console.WriteLine("\nInput your role (Member/Admin) ");
            string? role = Console.ReadLine();
            if (string.IsNullOrEmpty(role))
            {
                Console.WriteLine("Role cannot be empty. Please enter 'Member' or 'Admin'.");
                return;
            }
            bool isParsed = Enum.TryParse(role, true, out Roles userRole);

            if (!isParsed)
            {
                Console.WriteLine("Invalid role. Please enter 'Member' or 'Admin'.");
                return;
            }
            User newUser = new User(name, email, userRole);
            Console.WriteLine(newUser.ShowInfo());
            

            //Library object...
            while (true)
            {
                Console.WriteLine("Menu\n1. Add book\n2. Get book by id\n3. Get all books\n4. Delete book by id\n5. Edit book name\n6. Filter by page count\n0. Quit");
                Console.WriteLine("Input your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if(newUser.Role != Roles.Admin)
                        {
                            Console.WriteLine("Only Admin can add books to the library.");
                            break;
                        }
                        Console.WriteLine("Input book name: ");
                        string? bookName = Console.ReadLine();
                        Console.WriteLine("Input book author: ");
                        string? bookAuthor = Console.ReadLine();
                        Console.WriteLine("Input book page count: ");
                        int pageCount = Convert.ToInt32(Console.ReadLine());
                        Book newBook = new Book(bookName, bookAuthor, pageCount, false);
                        library.AddBook(newBook);
                        Console.WriteLine("Book added successfully.");
                        break;
                    case 2:
                        Console.WriteLine("Enter book ID: ");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        library.GetBookByID(bookId);
                        break;
                    case 3:
                        library.GetAllBooks();
                        break;
                    case 4:
                        if (newUser.Role != Roles.Admin)
                        {
                            Console.WriteLine("Only Admin can delete books from the library.");
                            break;
                        }
                        Console.WriteLine("Enter book ID to delete: ");
                        int deleteBookId = Convert.ToInt32(Console.ReadLine());
                        library.DeleteBook(deleteBookId);
                        Console.WriteLine("Book deleted successfully.");
                        break;
                    case 5:
                        if (newUser.Role != Roles.Admin)
                        {
                            Console.WriteLine("Only Admin can edit books in the library.");
                            break;
                        }
                        Console.WriteLine("Enter book ID to edit: ");
                        int editBookId = Convert.ToInt32(Console.ReadLine());
                        library.EditBookName(editBookId);
                        Console.WriteLine("Book name updated successfully.");
                        break;
                    case 6:
                        Console.WriteLine("Enter minimum page count: ");
                        int minPageCount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter maximum page count: ");
                        int maxPageCount = Convert.ToInt32(Console.ReadLine());
                        library.FilterBookByPageCount(minPageCount, maxPageCount);
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from the menu.");
                        break;
                }
            }
        }

    }
}
