using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Entities
{
    public class User : Entity
    {
        private readonly List<Order> orders = new List<Order>();

        [MaxLength(50)]
        public string Email { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string Salt { get; protected set; }

        [MaxLength(30)]
        public string FirstName { get; protected set; }

        [MaxLength(40)]
        public string LastName { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public int PhoneNumber { get; protected set; }

        public UserType Type { get; protected set; }

        public IReadOnlyCollection<Order> Orders => orders;

        public User(string email, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            SetEmail(email.ToLowerInvariant());
            SetFirstName(firstName);
            SetLastName(lastName);
            CreationDateTime = DateTime.UtcNow;
            Type = UserType.Customer;
        }

        protected User()
        {
        }

        public void SetEmail(string email)
            => Email = email;

        public void SetPassword(string password, IPasswordEncrypter encrypter)
        {
            Salt = encrypter.GetSalt();
            PasswordHash = encrypter.GetHash(password, Salt);
        }

        public void SetFirstName(string firstName)
            => FirstName = firstName;

        public void SetLastName(string lastName)
            => LastName = lastName;

        public void SetPhoneNumber(int number)
            => PhoneNumber = number;

        public void AddOrder(Order order)
            => orders.Add(order);
    }
}