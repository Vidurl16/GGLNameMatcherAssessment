namespace GGLMatchesAssessment.Interfaces;

public interface INameMatcher
{
    public List<string> MatchNames(List<(string name, char gender)> names);
}
