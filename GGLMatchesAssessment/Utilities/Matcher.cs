using GGLMatchesAssessment.Interfaces;
using System.Diagnostics;

namespace GGLMatchesAssessment.Utilities;

public class Matcher
{
    private string input;
    private Stopwatch sw;
    private ILogger _logger;
    private IValidator _validator;
    public Matcher(string input)
    {
        this.input = input;
        sw = new Stopwatch();
        _logger = new Logger();
        _validator = new Validator(input);
    }

    public string Match()
    {
        sw.Start();

        if (!_validator.Validate())
        {
            sw.Stop();

            _logger.Log($"Invalid input string: {input}", sw);

            return null;
        }

        OccurrenceCounter counter = new OccurrenceCounter(_validator.CleanedInput);
        CountReducer reducer = new CountReducer();

        string result = counter.CountOccurrences();

        int numb = reducer.GetReducedNumbers(result);

        string output = (numb > 80) ? numb.ToString() + " good match" : numb.ToString();

        sw.Stop();

        _logger.Log($"Input string: {input}, Result: {output}", sw);
        return output;
    }
}
