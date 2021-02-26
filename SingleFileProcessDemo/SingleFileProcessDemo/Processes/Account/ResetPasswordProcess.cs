using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace SingleFileProcessDemo.Processes.Account
{
    public class ResetPasswordProcess
    {
        public class Request : IRequest<Response>
        {
            public string Email { get; set; }
        }

        public class Response
        {
            public bool Success { get; set; }
            public bool EmailSent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                // do some authentication ...
                // retrieve from db ...
                // generate reset link ...
                // send email to user ...

                return Task.FromResult(new Response
                {
                    Success = true,
                    EmailSent = true,
                });
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
            }
        }
    }
}