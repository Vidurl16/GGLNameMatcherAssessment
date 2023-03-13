using GGLMatchesAssessment.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class NameMatcherController : ControllerBase
{
    private readonly NameMatcher _nameMatcher;

    public NameMatcherController(NameMatcher nameMatcher)
    {
        _nameMatcher = nameMatcher;
    }

    [HttpPost]
    public IActionResult MatchNames([FromBody] string name1, string name2)
    {
        string strInput = name1 + " matches " + name2;

        var results = _nameMatcher.MatchNames(strInput);

        return Ok(results);
    }
}
