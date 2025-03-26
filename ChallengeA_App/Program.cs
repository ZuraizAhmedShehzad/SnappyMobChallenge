using ChallengeA_App;
using System.Text;

long targetFileSize = 10 * 1024 * 1024;
long currentFileSize = 0;

string solutionRoot = GetSolutionRoot()+ "\\ChallengeB_App";
string filePath = Path.Combine(solutionRoot, "random_object.txt");

using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
{
    while (currentFileSize < targetFileSize)
    {
        string randomObject = RandomObjectGenerator.GenerateRandomObject();
        string toWrite = currentFileSize == 0 ? randomObject : "," + randomObject;
        int byteCount = Encoding.UTF8.GetByteCount(toWrite);

        if (currentFileSize + byteCount > targetFileSize)
        {
            WriteFinalPadding(writer, targetFileSize - currentFileSize);
            break;
        }

        writer.Write(toWrite);
        currentFileSize += byteCount;
    }

    Console.WriteLine($"File created at {filePath}");
}

void WriteFinalPadding(StreamWriter writer, long remainingBytes)
{
    writer.Write(new string('a', (int)remainingBytes));
}

static string GetSolutionRoot()
{
    string currentDir = Directory.GetCurrentDirectory();
    DirectoryInfo dir = new DirectoryInfo(currentDir);
    while (dir != null && !dir.GetFiles("*.sln").Any())
    {
        dir = dir.Parent;
    }
    return dir?.FullName ?? throw new Exception("Solution root not found.");
}
