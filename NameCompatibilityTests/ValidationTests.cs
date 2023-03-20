using NUnit.Framework;
using GGLMatchesAssessment.Utilities;
namespace NameCompatibilityTests;


[TestFixture]
public class ValidatorTests
{
    [TestCase("hello", ExpectedResult = true)]
    [TestCase("HELLO", ExpectedResult = true)]
    [TestCase("h e l l o", ExpectedResult = true)]
    [TestCase("12345", ExpectedResult = false)]
    [TestCase("hello123", ExpectedResult = false)]
    [TestCase("hello world", ExpectedResult = true)]
    [TestCase("hello,world", ExpectedResult = false)]
    [TestCase("H3LLO@Wrld", ExpectedResult = false)]
    public bool Validate_Input_ReturnsExpected(string input)
    {
        var validator = new Validator(input);

        bool result = validator.Validate();

        return result;
    }

    [Test]
    public void Validate_CleanedInput_IsSet()
    {
        var validator = new Validator("hello");

        validator.Validate();

        Assert.AreEqual("hello", validator.CleanedInput);
    }
}
