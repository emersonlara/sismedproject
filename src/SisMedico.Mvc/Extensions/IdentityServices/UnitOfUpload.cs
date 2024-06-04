using SisMedico.Mvc.Intra;

namespace SisMedico.Mvc.Extensions.IdentityServices;

public class UnitOfUpload : IUnitOfUpload
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UnitOfUpload(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async void UploadImage(IFormFile file)
    {
        var totalBytes = file.Length;
        var fileName = file.FileName.Trim('"');
        fileName = fileName.Contains("\\") ? fileName.Substring(fileName.LastIndexOf("\\") + 1) : fileName;

        var buffer = new byte[3 * 1024];
        using (var output = File.Create(ObterCaminhoMaisNomeDoArquivo(fileName)))
        {
            using (var input = file.OpenReadStream())
            {
                int readBytes;
                while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    await output.WriteAsync(buffer, 0, readBytes);
                    totalBytes += readBytes;
                }
            }
        }
    }

    private string ObterCaminhoMaisNomeDoArquivo(string fileName)
    {
        var path = _webHostEnvironment.WebRootPath + "\\uploads\\";
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        return path + fileName;
    }
}
