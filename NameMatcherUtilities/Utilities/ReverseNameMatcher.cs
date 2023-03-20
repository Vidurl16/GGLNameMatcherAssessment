using GGLMatchesAssessment.Interfaces;
using GGLMatchesAssessment.Utilities;
using NameMatcherUtilities.Interfaces;

namespace NameMatcherUtilities.Utilities;

public class ReverseNameMatcher : INameMatcher
{
    private IGrouper _grouper;

    public ReverseNameMatcher(IGrouper grouper)
    {
        _grouper = grouper;
    }

    public List<string> MatchNames(List<(string name, char gender)> names)
    {
        var males = _grouper.GetDistinctMaleNames(names);
        var females = _grouper.GetDistinctFemaleNames(names);

        List<int> scores = new List<int>();
        List<string> matches = new List<string>();

        foreach (var male in males)
        {
            foreach (var female in females)
            {
                matches.Add($"{female.name} matches {male.name}");
            }
        }

        List<string> results = new List<string>();

        foreach (var match in matches)
        {
            MatchComputer matcher = new MatchComputer(match);

            string output = matcher.Compute();

            if (int.TryParse(output, out int score))
            {
                scores.Add(score);
            }

            results.Add($"{match}: {output}");

            Console.WriteLine(match + ": " + output);
        }

        double average = GetAverage(scores);

        Console.WriteLine("\n\nAverage match score: " + average);

        return results;
    }

    public double GetAverage(List<int> scores)
    {
        double average = 0;

        average = scores.Average();

        return average;
    }
}
