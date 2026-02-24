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
            Program user = new Program();
            //user.ShowUserInfo();
            



        }

        public void ShowUserInfo()
        {
            Console.WriteLine("\nInput your information:  Name / Email / (Role: Member/Admin) ");
            Console.WriteLine("\nInput your name ");
            string ?name = Console.ReadLine();
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

        }

    }
}
