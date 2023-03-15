namespace GGLMatchesAssessment.Interfaces;

public interface IValidator
{
    bool Validate();
    public string CleanedInput { get; set; }
}
