using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class FileManager : IFileManager
    {
        public async Task MoveFile(IFormFile file, string directoryPath, string uniqueFileName)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var imagePath = Path.Combine(directoryPath, uniqueFileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                try
                {
                    await file.CopyToAsync(stream);
                }
                catch (Exception e)
                {
                    throw new StreetwoodException(ErrorCode.UnableToSavePhoto, e.Message, e);
                }
            }
        }

        public string GetUniqueName(string oryginalName)
        {
            var random = string.Empty;
            var index = oryginalName.LastIndexOf('.');
            var extension = string.Empty;
            if (index > -1)
            {
                extension = oryginalName.Substring(index);
            }

            var uniqueName = $"{oryginalName.Substring(0, index)}{random.AppendRandom(10)}{extension}";
            return uniqueName;
        }
    }
}
