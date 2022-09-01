using CQRS.WithMediatR._ASPNETCore.Context;
using CQRS.WithMediatR._ASPNETCore.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WithMediatR._ASPNETCore.Features.ProductFeatures.Queries
{
    public class GettAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductsQueryHandler :IRequestHandler<GettAllProductsQuery, IEnumerable<Product>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GettAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if(productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
