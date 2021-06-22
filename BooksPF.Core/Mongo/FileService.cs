using BooksPF.Core.Abstract;
using BooksPF.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BooksPF.Core.Mongo
{
    public class FileService : IFileService
    {
        private readonly IMongoCollection<BookFile> files;
        private readonly IGridFSBucket bucket;
        public FileService(IDbClient client)
        {
            files = client.GetFilesCollection();
            bucket = client.GetBucket();
        }

        public async Task<ObjectId> UploadFile(IFormFile file)
        {
            var e = await bucket.UploadFromStreamAsync(file.FileName, file.OpenReadStream());
            return e;
        }

        public async Task<byte[]> DownloadFile(string fileId)
        {
            var result = await bucket.DownloadAsBytesAsync(ObjectId.Parse(fileId));
            return result;
        }
    }
}
