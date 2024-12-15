namespace BuildingBlocks.Responses
{
    public class Response<T> : Response where T : class
    {
        public T? Content { get; set; }
        public Response(T content)
        {
            Content = content;
            IsSuccess = true;
        }
    }
}
