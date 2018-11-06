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

        public string GetCharmImagePath(string categoryUnique, string charmUnique)
        {
            var path = Path.Combine("wwwroot", "Images", "Charms", categoryUnique.AppendRandom(5), charmUnique.GetUniqueFileName());
            return path;
        }

        public string GetProductImagesPath(string categoryUnique, string productUnique)
        {
            var path = Path.Combine("wwwroot", "Images", "Products", categoryUnique, productUnique);
            return path;
        }

        public string GetPhysicalPath(string path)
        {
            return Path.Combine(hostingEnvironment.ContentRootPath, path);
        }
    }
}
