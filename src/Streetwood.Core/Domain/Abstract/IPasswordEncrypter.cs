namespace Streetwood.Core.Domain.Abstract
{
    public interface IPasswordEncrypter
    {
        string GetSalt();

        string GetHash(string password, string salt);
    }
}
