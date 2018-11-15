namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IPathManager
    {
        string GetCharmImagePath(string categoryUnique);

        string GetProductImagesPath(string categoryUnique, string productUnique);

        string GetProductPath(string categoryUnique, string productUnique);

        string GetPhysicalPath(string path);
    }
}
