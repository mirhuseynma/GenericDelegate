using Utils.Exceptions;
using Utils.Interfaces;


namespace Utils.Models
{
    public class Library : IEntity
    {
        private static int _id;
        public int ID { get; }
        public int BookLimit { get; set; }
        private static List<Book> Books = new List<Book>();

        public Library()
        {
            _id++;
            ID = _id;
            BookLimit=100;
        }

        public void AddBook(Book book)
        {
            bool exists = Books.Any(b => b.Name == book.Name);
            if (exists || book.IsDeleted == true)
                throw new AlreadyExsistsException($"{book.Name}:This book already exists or there is a deleted.");
            else if (Books.Count >= BookLimit)
                throw new CapacityLimitException("Library limit exceeded.");
            Books.Add(book);   
        }

        public void GetBookByID(int id)
        {
            Book? book = Books.Find(Books => Books.ID == id); 
            Console.WriteLine("\nBooks by the ID you are looking for...\n");
            if (book == null)
                throw new NullReferenceException($"ID can't be zero or .");
            else if (book.ID != id)
                throw new NotFoundException($"Book with ID {id} not found.");
            Console.WriteLine($"ID: {book.ID}, Name: {book.Name}, Author: {book.Author}, PageCount: {book.PageCount}, IsDeleted: {book.IsDeleted}");
        }

        public List<Book> GetAllBooks()
        {
            List<Book> newBooks = Books;
            Console.WriteLine("\nYour books...");
            foreach (var book in newBooks)
            {
                Console.WriteLine($"\nID: {book.ID}, Name: {book.Name}, Author: {book.Author}, PageCount: {book.PageCount}, IsDeleted: {book.IsDeleted}");
            }
            return newBooks;
        }

        public void DeleteBook(int id)
        {
            Book? book = Books.Find(bookId => bookId.ID == id);
            List<Book> newBooks = Books;
            if (book == null)
                throw new NullReferenceException($"Id cannot be zero.");
            else if (book.ID != id)
                throw new NotFoundException($"Book with ID {id} not found.");
            else if (book.IsDeleted == false)
                book.IsDeleted = true;
            newBooks.Remove(book);
        } 

        public void EditBookName(int id)
        {
            Console.WriteLine("\nEnter the new name for the book:\n");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
                throw new NullReferenceException("Book name cannot be null or empty.");
            Book? book = Books.Find(bookId => bookId.ID == id);
            if (book == null)
                throw new NullReferenceException($"Id cannot be zero.");
            else if (book.ID != id)
                throw new NotFoundException($"Book with ID {id} not found.");
            book.Name = newName;
        }

        public void FilterBookByPageCount(int minCount, int maxCount)
        {
            List<Book> filterByPageCount = Books.Where(pageCount => pageCount.PageCount >=minCount && pageCount.PageCount <= maxCount).ToList();
            Console.WriteLine($"\nBooks with page count between {minCount} and {maxCount}:");
            foreach (var book in filterByPageCount)
            {
                Console.WriteLine($"\nID: {book.ID}, Name: {book.Name}, Author: {book.Author}, PageCount: {book.PageCount}, IsDeleted: {book.IsDeleted}");
            }
        }


    }
}
