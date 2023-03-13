using GGLMatchesAssessment.Interfaces;

namespace GGLMatchesAssessment.Utilities;

public class CountReducer
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

        char[] secondHalfArray = secondHalf.ToCharArray();

        Array.Reverse(secondHalfArray);

        string reversedSecondHalf = new string(secondHalfArray);

        if (secondHalfArray.Length < firstHalf.Length)
        {
            reversedSecondHalf += "0";
        }

        if (secondHalf.Length > firstHalf.Length)
        {
            firstHalf += "0";
        }

        string output = "";

        for (int i = 0; i < firstHalf.Length; i++)
        {
            int sum = (int)Char.GetNumericValue(firstHalf[i]) + (int)Char.GetNumericValue(reversedSecondHalf[i]);
            output += sum;
        }

        int value = Convert.ToInt32(output);

        if (value < 0 || value > 100)
        {
            return process(value.ToString());
        }
        else
        {
            return value;
        }
    }
}




