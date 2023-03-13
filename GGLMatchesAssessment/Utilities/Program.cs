using GGLMatchesAssessment.Utilities;
namespace GGLMatchesAssessment.Utilities;

public class Program
{
    static void Main(string[] args)
    {
        CSVHandler handler = new CSVHandler();
        string csvPath = "C:\\Users\\Vidur\\Downloads\\Input_Vidur Lutchminarain.csv";

        List<(string name, char gender)> names = handler.ReadCSVFile(csvPath);

        List<string> results = MatchNames(names);

        File.WriteAllLines("output.txt", results);
    }

    private static List<string> MatchNames(List<(string name, char gender)> names)
    {
        var males = names.Where(n => n.gender == 'm').GroupBy(n => n.name).Select(g => g.First()).ToList();
        var females = names.Where(n => n.gender == 'f').GroupBy(n => n.name).Select(g => g.First()).ToList();

        List<string> matches = new List<string>();

        foreach (var male in males)
        {
            foreach (var female in females)
            {
                matches.Add($"{male.name} matches {female.name}");
            }
        }

        List<string> results = new List<string>();

        foreach (var match in matches)
        {
            Matcher matcher = new Matcher(match);
            string output = matcher.Match();
            results.Add($"{match}: {output}");

            Console.WriteLine(match + ": " + output);
        }

        return results;
    }
}