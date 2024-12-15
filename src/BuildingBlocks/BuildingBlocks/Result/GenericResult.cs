namespace BuildingBlocks.Result
{
    public class Result<T> : Result
    {
        public T? Value { get; private set; }
        private Result(T value) : base(true) => Value = value;
        private Result(string errorMsg) : base(false, errorMsg) { }
        public static Result<T> Success(T value) => new Result<T>(value);
        public static new Result<T> Failure(string errorMsg) => new Result<T>(errorMsg);
    }
}
