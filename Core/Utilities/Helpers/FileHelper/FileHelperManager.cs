using Core.Utilities.Helpers.GuidHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filepath)
        {
           if(File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public string Update(string filepath, IFormFile file, string root)
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if(file.Length > 0)
            {
                if(!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string Guid = GuidHelperr.CreateGuid();
                string filepath=Guid +extension;
                using(FileStream fileStream = File.Create(root + filepath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filepath;
                }
              
            }
            return null;
        }
    }
}
