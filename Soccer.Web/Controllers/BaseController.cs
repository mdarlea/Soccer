using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Soccer.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
