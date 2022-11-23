using CloudFile.Data;
using Microsoft.Extensions.FileProviders;

namespace CloudFile.Domain
{
    public interface IFileManager
    {
        Task<IEnumerable<FileInfo>> GetList();
        Task<IFileInfo> GetFile(string name);
        Task Add(IFormFile file);
        Task Delete(string name);
    }

    public class FileManager : IFileManager
    {
        private readonly IFileRepo _fileRepo;

        public FileManager(IFileRepo fileRepo)
        {
            _fileRepo = fileRepo;
        }

        public async Task<IEnumerable<FileInfo>> GetList()
        {
            var result = await _fileRepo.GetList();
            return result;
        }

        public async Task<IFileInfo> GetFile(string name)
        {
            var result = await _fileRepo.GetFile(name);
            return result;
        }

        public async Task Add(IFormFile file)
        {
            await _fileRepo.Add(file);
        }

        public async Task Delete(string name)
        {
            await _fileRepo.Delete(name);
        }
    }
}
