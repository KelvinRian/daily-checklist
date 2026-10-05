namespace DailyChecklist.Application.Utils.Result
{
    public sealed record Failure (int Code, string Message)
    {
    }
}
