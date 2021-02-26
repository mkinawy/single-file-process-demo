using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SingleFileProcessDemo.Entities;

namespace SingleFileProcessDemo.Processes.Account
{
    public class GetProfileProcess
    {
        public class Request : IRequest<Response>
        {
        }

        public class Response
        {
            public string Email { get; set; }
            public string FullName { get; set; }
            public int Age { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                // some auth code ...
                // some db fetching ...
                var userEntity = new UserEntity
                {
                    Id = 55,
                    Email = "jimmy@example.com",
                    Password = "hashed_password",
                    FullName = "Jimmy Tod",
                    Age = 23
                };

                var response = _mapper.Map<Response>(userEntity);
                return Task.FromResult(response);
            }
        }

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<UserEntity, Response>();
            }
        }
    }
}