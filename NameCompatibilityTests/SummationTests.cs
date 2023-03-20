using GGLMatchesAssessment.Utilities;
using NUnit.Framework;
namespace NameCompatibilityTests;

[TestFixture]
public class SummationTests
{
    private CountReducer _reducer;

    [SetUp]
    public void SetUp()
    {
        _reducer = new CountReducer();
    }

    [Test]
    public void GIVEN_ArrayOfThreeNumbers_WHEN_Summing_THEN_ReturnSum()
    {
        string input = "433221";

        int output = 60;

        int result = _reducer.GetReducedNumbers(input);

        Assert.AreEqual(output, result);
    }

    [Test]
    public void GIVEN_ArrayOfFourNumbers_WHEN_Summing_THEN_ReturnSum()
    {
        string input = "54321";

        int output = 96;

        int result = _reducer.GetReducedNumbers(input);

        Assert.AreEqual(output, result);
    }

    [Test]
    public void GIVEN_JackAndJill_WHEN_Summing_THEN_ReturnSum()
    {
        string input = "22211111112";

        int output = 60;

        int result = _reducer.GetReducedNumbers(input);

        Assert.AreEqual(output, result);
    }
}