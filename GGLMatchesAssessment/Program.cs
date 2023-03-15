using GGLMatchesAssessment.Constants;
using GGLMatchesAssessment.Interfaces;
using GGLMatchesAssessment.Utilities;

namespace GGLMatchesAssessment;

public class Program
{
    public static void Main(string[] args)
    {
        ICSVHandler handler = new CSVHandler();
        NameMatcher nameMatcher = new NameMatcher();

        string csvPath = PathConstants.csvPath;

        List<(string name, char gender)> names = handler.ReadCSVFile(csvPath);

        List<string> results = nameMatcher.MatchNames(names);

        File.WriteAllLines("output.txt", results);
    }

}
