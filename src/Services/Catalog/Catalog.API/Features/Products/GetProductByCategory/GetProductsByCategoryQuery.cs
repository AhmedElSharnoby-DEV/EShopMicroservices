using BuildingBlocks.CQRS;
using System.Diagnostics.CodeAnalysis;

namespace Catalog.API.Features.Products.GetProductByCategory
{
    public class GetProductsByCategoryQuery : IQuery<IEnumerable<GetProductsByCategoryResult>>, IParsable<GetProductsByCategoryQuery>
    {
        public string Category { get; set; } = null!;

        public static GetProductsByCategoryQuery Parse(string s, IFormatProvider? provider)
        {
            if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
            {
                return new GetProductsByCategoryQuery() { Category = s };
            }
            throw new Exception("Invalid Category");
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out GetProductsByCategoryQuery result)
        {
            if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s))
            {
                result = new GetProductsByCategoryQuery() {Category = s};
                return true;
            }
            result = null;
            return false;
        }
    }
}
