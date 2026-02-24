
using Utils.Enums;
using Utils.Interfaces;

namespace Utils.Models
{
    public class User : IEntity
    {
        private static int _id;
        public int ID { get; }
        
        public string UserName { get; set; }
        public string Email{ get; set; }
        public Roles Role{ get; set; }


        public User(string userName, string email, Roles role)
        {
            _id++;
            ID = _id;
            UserName = userName;
            Email = email;
            Role = role;
        }

        public string ShowInfo()
        {
            return $"ID: {ID}, UserName: {UserName}, Email: {Email}, Role: {Role}";
        }

    }
}
