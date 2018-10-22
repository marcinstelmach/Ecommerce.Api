namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface IPathManager
    {
        string GetCharmImagePath(string category, string charm);

        string GetCharmImagePath(string category, string charm, string imageName);

        string GetProductImagesPath(string category, string product);

        string GetProductImagesPath(string category, string product, string imageName);

        string GetPhysicalPath(string path);
    }
}
