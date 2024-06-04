namespace SisMedico.Mvc.Extensions;

public static class CopiarArquivo
{
    public static void Copiar(IFormFile file, string filePath)
    {
        // if (!System.IO.File.Exists(filePath))
        //{
        using (var fileStream = File.Create(filePath))
        {
            file.CopyTo(fileStream);
            fileStream.Flush();
        }
        //}
    }
}
