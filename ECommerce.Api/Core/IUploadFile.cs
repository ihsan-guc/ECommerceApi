﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ECommerce.Api.Core
{
    public interface IUploadFile
    {
        string UploadFileImage(IFormFile file, int ApplicationUserId);
    }
    public class UploadFile : IUploadFile
    {
        public IWebHostEnvironment WebHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public string UploadFileImage(IFormFile file, int ApplicationUserId)
        {
            string filename = null;

            if (file != null)
            {
                string uploadDir = Path.Combine("Images");
                filename = ApplicationUserId.ToString() + file.FileName;
                string filepath = Path.Combine(uploadDir, filename);
                var fileContents = Directory.GetFiles(uploadDir);
                foreach (var item in fileContents)
                {
                    if (item.Contains(ApplicationUserId.ToString()))
                    {
                        File.Delete(item);
                    }
                }
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    filename = fileStream.Name;
                }
            }
            return filename;
        }
    }
}
