using BuildingBlocks.CQRS;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Catalog.API.Features.Products.GetProductById
{
    public class GetProductByIdQuery : IQuery<GetProductByIdResult>, IParsable<GetProductByIdQuery>
    {
        public Guid Id { get; set; }

        public static GetProductByIdQuery Parse(string s, IFormatProvider? provider)
        {
            if(!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s) && Guid.TryParse(s, out Guid id))
            {
                return new GetProductByIdQuery() { Id = id };
            }
            throw new Exception("Invalid Provided Product Id");
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out GetProductByIdQuery result)
        {
            if (!string.IsNullOrEmpty(s) && !string.IsNullOrWhiteSpace(s) && Guid.TryParse(s, out Guid id))
            {
                result = new GetProductByIdQuery() { Id = id };
                return true;
            }
            result = null;
            return false;
        }
    }
}
