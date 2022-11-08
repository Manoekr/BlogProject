using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        string Upload(List<IFormFile> file, string root);
        void Delete(string filePath);
        string Update(List<IFormFile> file, string filePath, string root);
    }
}
