using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    FileResult SaveContentToFile(string path, string content); //VAD och VART man sparar.
    FileResult GetContentFromFile(string path);
}

