using Utils.Enums;
using Utils.Interfaces;

namespace Utils.Models
{
    public class Book: IEntity
    {
        private static int _id;
        public int ID { get; }
        public string Name { get; set; }    
        public string Author { get; set; }  
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; }

        public Book(string name, string author, int pageCount, bool isDeleted)
        {
            _id++;
            ID = _id;
            Name = name;
            Author = author;
            PageCount = pageCount;
            IsDeleted = isDeleted;
        }
    }
}
