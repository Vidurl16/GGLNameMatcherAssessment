using NameMatcherUtilities.Interfaces;

namespace NameMatcherUtilities.Utilities;

public class NameGrouper : IGrouper
{
    public List<(string name, char gender)> GetDistinctMaleNames(List<(string name, char gender)> names)
    {
        var males = names
            .Where(n => n.gender == 'm')
            .GroupBy(n => n.name)
            .Select(g => g.First())
            .ToList();

        return males;
    }

    public List<(string name, char gender)> GetDistinctFemaleNames(List<(string name, char gender)> names)
    {
        var females = names
            .Where(n => n.gender == 'f')
            .GroupBy(n => n.name)
            .Select(g => g.First())
            .ToList();

        return females;
    }
}
