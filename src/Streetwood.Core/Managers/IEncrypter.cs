namespace Streetwood.Core.Managers
{
    public interface IEncrypter
    {
        string GetSalt();

        string GetHash(string password, string salt);
    }
}
