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

        List<(string name, char gender)> names = handler.ReadCSVFile(PathConstants.csvPath);

        List<string> results = nameMatcher.MatchNames(names);

        List<string> reversedResults = nameMatcher.MatchNamesReversed(names);

        File.WriteAllText("output.txt", "\nRegular results: \n");
        File.AppendAllLines("output.txt", results);
        File.AppendAllText("output.txt", "\nReversed Results:\n");
        File.AppendAllLines("output.txt", reversedResults);
    }
}
