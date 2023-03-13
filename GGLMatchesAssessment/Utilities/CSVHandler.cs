using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class CSVHandler : ICSVHandler
{
    public List<(string name, char gender)> ReadCSVFile(string filePath)
    {
        List<(string name, char gender)> names = new List<(string, char)>();

        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values.Length == 2)
                {
                    names.Add((values[0].Trim(), values[1].Trim().ToLower()[0]));
                }
            }
        }

        return names;
    }
}

