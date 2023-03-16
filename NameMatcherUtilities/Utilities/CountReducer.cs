using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class CountReducer : ICountReducer
{
    public int GetReducedNumbers(string input)
    {
        int result = process(input);

        return result;
    }

    public int process(string input)
    {
        int mid = input.Length / 2;

        string firstHalf = input.Substring(0, mid);
        string secondHalf = input.Substring(mid);

        string reversedSecondHalf = GetReversedArray(secondHalf);

        if (secondHalf.Length < firstHalf.Length)
        {
            reversedSecondHalf += "0";
        }

        if (secondHalf.Length > firstHalf.Length)
        {
            firstHalf += "0";
        }

        int value = ComputeOutput(firstHalf, reversedSecondHalf);

        return CheckOutputValue(value);
    }

    private int CheckOutputValue(int value)
    {
        if (value < 0 || value > 100)
        {
            return process(value.ToString());
        }
        else
        {
            return value;
        }
    }

    private string GetReversedArray(string input)
    {
        char[] secondHalfArray = input.ToCharArray();

        Array.Reverse(secondHalfArray);

        string reversedSecondHalf = new string(secondHalfArray);

        return reversedSecondHalf;
    }

    private int ComputeOutput(string firstHalf, string reversedSecondHalf)
    {
        string output = "";

        for (int i = 0; i < firstHalf.Length; i++)
        {
            int sum = (int)Char.GetNumericValue(firstHalf[i]) + (int)Char.GetNumericValue(reversedSecondHalf[i]);

            output += sum;
        }

        return Convert.ToInt32(output);
    }
}