namespace BuildingBlocks.Result
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string? ErrorMsg { get; private set; }
        public List<string> Errors { get; private set; } = new();
        protected Result(bool isSuccess, string? errorMsg = null)
        {
            IsSuccess  = isSuccess;
            ErrorMsg = errorMsg;
        }
        public static Result Success() => new(true, null);
        public static Result Failure(string errorMsg) => new(false, errorMsg);
        public void Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (!result.IsSuccess)
                {
                    IsSuccess = false;
                    Errors.Add(result.ErrorMsg!);
                }
            }
        }
        public string CombineErrors()
        {
            return string.Join(", ", Errors);
        }

    }
}
