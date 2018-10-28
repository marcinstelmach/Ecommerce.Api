using System;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Entities
{
    public class Address : Entity
    {
        public string Street { get; protected set; }

        public string City { get; protected set; }

        public string Country { get; protected set; }

        public string PostCode { get; protected set; }

        public virtual User User { get; protected set; }

        public Address(string street, string city, string country, string postCode)
        {
            Id = Guid.NewGuid();
            Street = street;
            City = city;
            Country = country;
            PostCode = postCode;
        }

        protected Address()
        {
        }

        public void SetCity(string city)
            => City = city;

        public void SetCountry(string country)
            => Country = country;

        public void SetStreet(string street)
            => Street = street;

        public void SetPostCode(string postCode)
            => PostCode = postCode;
    }
}