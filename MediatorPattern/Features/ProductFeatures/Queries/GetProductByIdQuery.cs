using MediatorPattern.Context;
using MediatorPattern.Model;
using MediatR;

namespace MediatorPattern.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }


        public class GetAllProductsByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsByIdHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
