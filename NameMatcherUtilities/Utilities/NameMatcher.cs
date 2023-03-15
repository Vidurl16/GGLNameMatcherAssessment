using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class NameMatcher : INameMatcher
{
    public List<string> MatchNames(List<(string name, char gender)> names)
    {
        var males = GetDistinctMaleNames(names);
        var females = GetDistinctFemaleNames(names);

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

    private List<(string name, char gender)> GetDistinctMaleNames(List<(string name, char gender)> names)
    {
        var males = names
            .Where(n => n.gender == 'm')
            .GroupBy(n => n.name)
            .Select(g => g.First())
            .ToList();

        return males;
    }
    private List<(string name, char gender)> GetDistinctFemaleNames(List<(string name, char gender)> names)
    {
        var females = names
            .Where(n => n.gender == 'f')
            .GroupBy(n => n.name)
            .Select(g => g.First())
            .ToList();

        return females;
    }

    public string MatchNames(string names)
    {
        MatchComputer matcher = new MatchComputer(names);

        string output = matcher.Compute();

        return output;
    }
}