namespace BuildingBlocks.Exceptions.CustomExceptions
{
    public class ValidationException : Exception
    {
        public readonly List<string> _failures;

        public ValidationException(string message)
            :base(message)
        {
            _failures = null!;
        }
        public ValidationException(List<string> failures)
        {
            _failures = failures;
        }
    }
}
