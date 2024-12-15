namespace Catalog.API.Domain.Common.Models
{
    public class BaseEntity<T>
    {
        public T Id { get; private set; }
    }
}
