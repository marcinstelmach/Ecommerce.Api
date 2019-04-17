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

        public string Email { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string Salt { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public DateTime CreationDateTime { get; protected set; }

        public string ChangePasswordToken { get; protected set; }

        public string RefreshToken { get; protected set; }

        public UserStatus UserStatus { get; protected set; }

        public UserType Type { get; protected set; }

        public string FullName => $"{FirstName} {LastName}";

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

        public void SetPassword(string password, IEncrypter encrypter)
        {
            Salt = encrypter.GetSalt();
            PasswordHash = encrypter.GetHash(password, Salt);
        }

        public void SetFirstName(string firstName)
            => FirstName = firstName;

        public void SetLastName(string lastName)
            => LastName = lastName;

        public void SetRefreshToken(string token)
            => RefreshToken = token;

        public void AddOrder(Order order)
            => orders.Add(order);

        public void SetUserStatus(UserStatus status)
            => UserStatus = status;

        public void SetChangePasswordToken(IStringGenerator generator)
            => ChangePasswordToken = generator.Generate(50);

        public void SetChangePasswordToken()
            => ChangePasswordToken = string.Empty;
    }
}