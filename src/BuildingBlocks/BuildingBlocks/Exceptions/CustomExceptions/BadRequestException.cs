namespace BuildingBlocks.Exceptions.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            :base(message)
        {     
        }
    }
}
