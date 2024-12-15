using Catalog.API.Common.Exceptions;

namespace Catalog.API.Domain.Common.Models
{
    public class Creation
    {
        public string CreatedBy { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

        public Creation(string createdBy)
        {
            if (string.IsNullOrWhiteSpace(createdBy))
            {
                throw new BadRequestException("Invalid CreatedBy");
            }
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;
        }
    }
}
