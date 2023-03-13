using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        ICSVHandler handler = new CSVHandler();
        NameMatcher nameMatcher = new NameMatcher();

        string csvPath = @"C:\\Users\\Vidur\\Downloads\\Input_Vidur Lutchminarain.csv";

        List<(string name, char gender)> names = handler.ReadCSVFile(csvPath);

        List<string> results = nameMatcher.MatchNames(names);

        File.WriteAllLines("output.txt", results);
    }

}
