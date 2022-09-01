using CQRS.WithMediatR._ASPNETCore.Context;
using CQRS.WithMediatR._ASPNETCore.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WithMediatR._ASPNETCore.Features.ProductFeatures.Commands
{
    public class CreateProductCommand:IRequest<string>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal BuyingPrice { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;
                product.Description = command.Description;
                _context.Products.Add(product);
                await _context.SaveChanges();
                return $"Product with id:{product.Id} created successfully";
            }
        }
    }
}
