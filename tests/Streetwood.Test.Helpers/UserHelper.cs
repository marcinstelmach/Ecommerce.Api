using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class UserHelper
    {
        public static User CreateUser()
            => new User("email@gmai.com", "John", "Smith", 123456789);
    }
}