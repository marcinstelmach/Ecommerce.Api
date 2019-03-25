using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Implementations;

namespace Streetwood.Test.Helpers
{
    public class UserHelper
    {
        public static User CreateUser()
        {
            var user = new User("test@gmail.com", "John", "Smith");
            user.SetPassword("1qaz@WSX", new Encrypter());
            return user;
        }

        public static async Task<string> AuthenticateUser(HttpClient httpClient, string email, string password)
        {
            var request = new
            {
                Email = email,
                Password = password
            };

            var result = await httpClient.PostAsJsonAsync("api/auth", request);
            var message = await result.Content.ReadAsStringAsync();
            var tokenModel = JsonConvert.DeserializeObject<TokenModel>(message);
            return tokenModel.Token;
        }
    }
}