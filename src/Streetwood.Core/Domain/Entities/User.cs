using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Managers;

namespace Streetwood.Core.Domain.Entities
{
    public class User : Entity
    {
        private readonly List<Order> orders = new List<Order>();
        private readonly List<Address> addresses = new List<Address>();

        public string Email { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string Salt { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public int PhoneNumber { get; protected set; }

        public string ChangePasswordToken { get; protected set; }

        public UserStatus UserStatus { get; protected set; }

        public UserType Type { get; protected set; }

        public virtual IReadOnlyCollection<Address> Addresses => addresses;

        public virtual IReadOnlyCollection<Order> Orders => orders;

        public User(string email, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            SetEmail(email.ToLowerInvariant());
            SetFirstName(firstName);
            SetLastName(lastName);
            CreationDateTime = DateTime.UtcNow;
            Type = UserType.Customer;
            UserStatus = UserStatus.Active;
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

        public void AddAddress(Address address)
            => addresses.Add(address);

        public void SetUserStatus(UserStatus status)
            => UserStatus = status;

        public void SetChangePasswordToken(IStringGenerator generator)
            => ChangePasswordToken = generator.Generate(50);
    }
}