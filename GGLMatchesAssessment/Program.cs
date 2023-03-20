using GGLMatchesAssessment.Constants;
using GGLMatchesAssessment.Interfaces;
using GGLMatchesAssessment.Utilities;
using NameMatcherUtilities.Utilities;

namespace GGLMatchesAssessment;

public class Program
{
    public static void Main(string[] args)
    {
        ICSVHandler handler = new CSVHandler();
        INameMatcher nameMatcher = new NameMatcher(new NameGrouper());
        INameMatcher reverseNameMatcher = new ReverseNameMatcher(new NameGrouper());

        List<(string name, char gender)> names = handler.ReadCSVFile(PathConstants.csvPath);
        List<string> results = nameMatcher.MatchNames(names);
        List<string> reversedResults = reverseNameMatcher.MatchNames(names);

        string logsDirectory = @"\GGLMatchesAssessment\Logs";
        string outputPath = Path.Combine(logsDirectory, "output.txt");

        if (!Directory.Exists(logsDirectory))
        {
            Directory.CreateDirectory(logsDirectory);
        }

        File.WriteAllText(outputPath, "\nRegular results: \n");
        File.AppendAllLines(outputPath, results);

        File.AppendAllText(outputPath, "\nReversed Results:\n");
        File.AppendAllLines(outputPath, reversedResults);
    }
}
