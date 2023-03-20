using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class Validator : IValidator
{
    private readonly string input;
    public string CleanedInput { get;  set; }

    public Validator(string input)
    {
        this.input = input;
    }

    public bool Validate()
    {
        string cleanedInput = input.ToLower().Replace(" ", "");

        foreach (char c in cleanedInput)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }

        CleanedInput = cleanedInput;

        return true;
    }
}
