namespace GGLMatchesAssessment.Interfaces;

public interface ICSVHandler
{
    public List<(string name, char gender)> ReadCSVFile(string filePath);
}
