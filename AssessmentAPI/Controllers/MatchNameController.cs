using GGLMatchesAssessment.Utilities;
using Microsoft.AspNetCore.Mvc;
using NameMatcherUtilities.Interfaces;
using NameMatcherUtilities.Utilities;

namespace AssessmentAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchNameController : ControllerBase
{
   
    [HttpPost(Name ="ComputeMatch")]
    public string GetResult(string name1, string name2)
    {
        string input = name1 + " matches " + name2;

        NameMatcher _nameMatcher = new NameMatcher(new NameGrouper());

        string result = _nameMatcher.MatchNames(input);

        return result;

    }
}
