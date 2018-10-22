using System.IO;
using Microsoft.AspNetCore.Hosting;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class PathManager : IPathManager
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public PathManager(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public string GetCharmImagePath(string category, string charm)
        {
            var path = Path.Combine("Images", "Charms", category.AppendRandom(5), charm.AppendRandom(5));
            return path;
        }

        public string GetCharmImagePath(string category, string charm, string imageName)
        {
            return Path.Combine(GetCharmImagePath(category, charm), imageName.AppendRandom(5));
        }

        public string GetProductImagesPath(string category, string product)
        {
            var path = Path.Combine("Images", "Products", category.AppendRandom(5), product.AppendRandom(5));
            return path;
        }

        public string GetProductImagesPath(string category, string product, string imageName)
        {
            return Path.Combine(GetProductImagesPath(category, product), imageName.AppendRandom(5));
        }

        public string GetPhysicalPath(string path)
        {
            return Path.Combine(hostingEnvironment.ContentRootPath, path);
        }
    }
}
