using HotelBooking.Domain.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Entities
{
    public class User : BaseEntity
    {
        [BsonElement("FirstName")]
        public string FirstName { get; private set; } = string.Empty;

        [BsonElement("LastName")]
        public string LastName { get; private set; } = string.Empty;

        [BsonElement("Email")]
        [EmailAddress]
        public string Email { get; private set; } = string.Empty;

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; private set; } = string.Empty;

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; private set; } = string.Empty;

        [BsonElement("Cpf")]
        public string Cpf { get; private set; } = string.Empty;

        [BsonElement("DateOfBirth")]
        public DateTime DateOfBirth { get; private set; }

        [BsonElement("UserLevel")]
        public UserLevel UserLevel { get; private set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; private set; } = true;

        [BsonElement("EmailChecked")]
        public bool EmailChecked { get; private set; } = true; //Change to false when validation email will be implemented

        public User(){}
        public User(string firstName, string lastName, string email, string passwordHash, string phoneNumber, string cpf, DateTime dateOfBith, UserLevel userLevel, bool isActive, bool emailChecked)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            Cpf = cpf;
            DateOfBirth = dateOfBith;
            UserLevel = userLevel;
            IsActive = isActive;
            EmailChecked = emailChecked;
        }

        public void Update(string firstName, string lastName, string email, string phoneNumber, string cpf, DateTime dateOfBirth, UserLevel userLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
            UserLevel = userLevel;
        }

        public void Inactive()
        {
            LastName += " - Excluído";
            IsActive = false;
        }
    }
}
