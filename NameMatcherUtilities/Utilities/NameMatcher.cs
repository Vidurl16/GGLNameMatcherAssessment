using GGLMatchesAssessment.Interfaces;
using NameMatcherUtilities.Interfaces;
using NameMatcherUtilities.Utilities;

namespace GGLMatchesAssessment.Utilities;

public class NameMatcher : INameMatcher
{
    private IGrouper _grouper;

    public NameMatcher(IGrouper grouper)
    {
        _grouper = grouper;
    }

    public List<string> MatchNames(List<(string name, char gender)> names)
    {
        var males = _grouper.GetDistinctMaleNames(names);
        var females = _grouper.GetDistinctFemaleNames(names);

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
            MatchComputer matcher = new MatchComputer(match);
            string output = matcher.Compute();
            results.Add($"{match}: {output}");

            Console.WriteLine(match + ": " + output);
        }

        return results;
    }


    public string MatchNames(string names)
    {
        MatchComputer matcher = new MatchComputer(names);

        string output = matcher.Compute();

        return output;
    }

    public double GetAverage(List<int> scores)
    {
        double average = 0;

        average = scores.Average();

        return average;
    }
}