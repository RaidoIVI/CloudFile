using Microsoft.Extensions.FileProviders;
using DirectoryInfo = System.IO.DirectoryInfo;

namespace CloudFile.Data
{
     public interface IFileRepo
    {
        Task<IEnumerable<FileInfo>> GetList();
        Task<IFileInfo> GetFile(string name);
        Task Add(IFormFile file);
        Task Delete(string name);
    }

    public class FileRepo : IFileRepo
    {
        private readonly string _storage;

        public FileRepo(IWebHostEnvironment webHostEnvironment)
        {
            _storage = Path.Combine(webHostEnvironment.ContentRootPath, "Storage");
            var dir = new DirectoryInfo(_storage);
            if (!dir.Exists) dir.Create();
        }

        public async Task<IEnumerable<FileInfo>> GetList()
        {
            var dir = new DirectoryInfo(_storage);
            var result = await Task.Run(() => dir.EnumerateFiles());
            return result;
        }

        public async Task<IFileInfo> GetFile(string name)
        {
            IFileInfo result = null;
            var provider = new PhysicalFileProvider(_storage);
            if (provider.GetFileInfo(name).Exists) result = await Task.Run(() => provider.GetFileInfo(name));
            return result;
        }

        public async Task Add(IFormFile file)
        {
            await using var fileStream = new FileStream(Path.Combine(_storage,file.FileName ), FileMode.Create);
            await file.CopyToAsync(fileStream);
        }

        public async Task Delete(string name)
        {
            var file = new FileInfo( Path.Combine(_storage,name));
            if (file.Exists) await Task.Run(() => file.Delete());
        }
    }
}
