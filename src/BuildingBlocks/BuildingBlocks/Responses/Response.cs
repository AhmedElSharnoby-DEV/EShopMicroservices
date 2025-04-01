namespace BuildingBlocks.Responses
{
    public class Response<T> where T : class
    {
        public T? Content { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string>? Errors { get; private set; }
        public static Response<T> Success(T Content)
        {
            return new Response<T>()
            {
                Content = Content
            };
        }
        public static Response<T> Fail(List<string> errors)
        {
            return new Response<T>()
            {
                Errors = errors
            };
        }
        public static Response<T> Fail(string error)
        {
            return new Response<T>()
            {
                Errors = new List<string>() { error }
            };
        }

    }
}
