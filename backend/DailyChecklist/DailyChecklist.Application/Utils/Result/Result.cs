namespace DailyChecklist.Application.Utils.Result
{
    public sealed class Result
    {
        public Failure? Failure { get; private set; }

        public bool IsSuccess => Failure == null;
        public bool IsFailure => !IsSuccess;

        private Result() { }

        private Result(Failure failure)
        {
            Failure = failure;
        }

        public static Result AsSuccess() => new();
        public static Result AsFailure(Failure failure) => new(failure);
    }
}
