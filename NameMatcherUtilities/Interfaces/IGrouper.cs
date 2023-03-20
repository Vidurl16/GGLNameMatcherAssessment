namespace NameMatcherUtilities.Interfaces;

public interface IGrouper
{
    public List<(string name, char gender)> GetDistinctMaleNames(List<(string name, char gender)> names);
    public List<(string name, char gender)> GetDistinctFemaleNames(List<(string name, char gender)> names);

}
