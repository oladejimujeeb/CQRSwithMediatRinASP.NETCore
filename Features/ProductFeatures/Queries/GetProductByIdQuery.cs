using CQRS.WithMediatR._ASPNETCore.Context;
using CQRS.WithMediatR._ASPNETCore.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WithMediatR._ASPNETCore.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var prod = await _context.Products.FindAsync(query.Id);
                if(prod == null) return null;
                return prod;
            }
        }

    }
}
