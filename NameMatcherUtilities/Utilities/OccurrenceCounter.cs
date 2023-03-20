using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class OccurrenceCounter : IOccurrenceCounter
{
    private readonly string input;

    public OccurrenceCounter(string input)
    {
        this.input = input;
    }

    public string CountOccurrences()
    {
        string result = "";

        foreach (char uniqueChar in input.Distinct())
        {
            int count = 0;

            foreach (char inputIndex in input)
            {
                if (inputIndex.Equals(uniqueChar))
                {
                    count++;
                } 
            }

            result += count.ToString();
        }

        return result;
    }
}
