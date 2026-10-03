namespace DailyChecklist.Application.Utils.Result
{
    public sealed record Failure (int Code, string Message)
    {
        public static Failure NotFound => new(404, "Resource not found");
        public static Failure ValidationError => new(400, "Validation error occurred");
    }
}
