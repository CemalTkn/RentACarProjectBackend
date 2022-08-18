using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileManager : IFileHelper
    {

        IGuidHelper _guidHelper;
        public FileManager(IGuidHelper guidHelper)
        {
            _guidHelper = guidHelper;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = _guidHelper.CreateGuid();
                string newPath = guid + extension;
                using (FileStream fileStream = File.Create(root + newPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return newPath;
                }
            }
            return null;
        }
    }
}
