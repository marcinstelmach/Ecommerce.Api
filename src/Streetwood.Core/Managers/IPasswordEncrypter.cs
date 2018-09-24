namespace Streetwood.Core.Managers
{
    public interface IPasswordEncrypter
    {
        string GetSalt();

        string GetHash(string password, string salt);
    }
}
