using Core.Utilities.Helper.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(List<IFormFile> file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(List<IFormFile> file, string root)
        {
            if (file.Count > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(root);
                string guid = GuiddHelper.CreateGuid() + ".jpg";
                string filePath = guid + extension;
                foreach (var formfile in file)
                {
                    using (FileStream fileStream = File.Create(root + filePath))
                    {
                        formfile.CopyTo(fileStream);
                        fileStream.Flush();
                        return filePath;
                    }
                }
            }
            return null;
        }
    }
}
