namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IPathManager
    {
        string GetCharmImagePath(string categoryUnique, string charmUnique);

        string GetProductImagesPath(string categoryUnique, string productUnique);

        string GetPhysicalPath(string path);
    }
}
