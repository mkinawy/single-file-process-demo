using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SingleFileProcessDemo.Entities;
using SingleFileProcessDemo.Models;

namespace SingleFileProcessDemo.Processes.Products
{
    public class SearchProductsProcess
    {
        public class Request : QueryModel, IRequest<PagerModel<Response>>
        {
        }

        public class Response
        {
            public string Name { get; set; }
            public float Price { get; set; }
        }

        public class Handler : IRequestHandler<Request, PagerModel<Response>>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public Task<PagerModel<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var total = Database.Products.Count;

                var products = Database.Products
                    .OrderByDescending(p => p.Id)
                    .Skip(request.Skip)
                    .Take(request.Size)
                    .ToList();
                var items = _mapper.Map<IEnumerable<Response>>(products);

                var pager = new PagerModel<Response>
                {
                    Page = request.Page,
                    Size = request.Size,
                    Total = total,
                    Items = items
                };

                return Task.FromResult(pager);
            }
        }

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<ProductEntity, Response>();
            }
        }
    }
}