using CloudFile.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CloudFile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public FileController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _fileManager.GetList();
            return Ok(result);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetFile(string name)
        {
            var result = await _fileManager.GetFile(name);
            return PhysicalFile(result.PhysicalPath, "application/octet-stream", new Guid() + result.PhysicalPath,
                true);
        }

        [HttpPost]
        public async Task Add(IFormFile fileCreate)
        {
            await _fileManager.Add(fileCreate);
        }

        [HttpDelete]
        public async Task Delete(string name)
        {
            await _fileManager.Delete(name);
        }
    }
}

