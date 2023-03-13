using GGLMatchesAssessment.Interfaces;
using System.Diagnostics;

namespace GGLMatchesAssessment.Utilities;

public class MatchComputer
{
    private string input;
    private Stopwatch sw;
    private ILogger _logger;
    private IOccurrenceCounter _occuranceCounter;
    private ICountReducer _reducer;
    private IValidator _validator;

    public MatchComputer(string input)
    {
        this.input = input;
        sw = new Stopwatch();
        _logger = new Logger();
        _validator = new Validator(input);
    }

    public string Compute()
    {
        sw.Start();

        try
        {
            if (!_validator.Validate())
            {
                sw.Stop();

                throw new Exception("Invalid input");
            }
        }
        catch (Exception ex)
        {
            string errorMessage = $"{input} yielded: {ex.Message}";
            _logger.Log(errorMessage, sw);
            return errorMessage;
        }

        _occuranceCounter = new OccurrenceCounter(_validator.CleanedInput);
        _reducer = new CountReducer();

        string result = _occuranceCounter.CountOccurrences();

        int numb = _reducer.GetReducedNumbers(result);

        string output = (numb > 80) ? numb.ToString() + " good match" : numb.ToString();

        sw.Stop();

        _logger.Log($"Input string: {input}, Result: {output}", sw);

        return output;
    }
}
