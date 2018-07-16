using System;

namespace ObaOba.API.Models
{
    public class User
    {
        public User(string name, string lastName, string email, DateTime dateCreated)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            DateCreated = dateCreated;
        }
        public int Id {get;set;}
        public string Name {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public byte[] PasswordHash {get;set;}
        public byte[] PasswordSalt {get;set;}
        public DateTime DateCreated {get;set;}  
        public DateTime? DateUpdated {get;set;}
    }
}