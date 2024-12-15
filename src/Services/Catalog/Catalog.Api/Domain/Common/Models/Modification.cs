using Catalog.API.Common.Exceptions;

namespace Catalog.API.Domain.Common.Models
{
    public class Modification
    {
        public string ModifiedBy { get; private set; } = null!;
        public DateTime ModifiedAt { get; private set; }

        public Modification(string modifiedBy)
        {
            if (string.IsNullOrWhiteSpace(modifiedBy))
            {
                throw new BadRequestException("Invalid ModifiedBy");
            }
            ModifiedBy = modifiedBy;
            ModifiedAt = DateTime.Now;
        }
    }
}
