using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksPF.Core.Abstract
{
    public interface IFileService
    {
        public Task<ObjectId> UploadFile(IFormFile file);
        public Task<byte[]> DownloadFile(string fileId);
    }
}
