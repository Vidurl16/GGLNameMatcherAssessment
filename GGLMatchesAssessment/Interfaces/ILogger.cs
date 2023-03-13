using System.Diagnostics;

namespace GGLMatchesAssessment.Interfaces;

public interface ILogger
{
    void Log(string message, Stopwatch stopwatch);
}
