using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

class OccurrenceCounter : IOccurrenceCounter
{
    private readonly string input;

    public OccurrenceCounter(string input)
    {
        this.input = input;
    }

    public string CountOccurrences()
    {
        string result = "";

        // Loop through each unique character in the input string
        foreach (char c in input.Distinct())
        {
            int count = 0;

            // Loop through the input string to count how many times the character occurs
            foreach (char ch in input)
            {
                if (ch.Equals(c))
                {
                    count++;
                }
            }

            // Add the character count to the result string
            result += count.ToString();
        }

        return result;
    }
}
