using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Soccer.Web.Features.Commands.PlayerCommands;
using Soccer.Web.Features.Queries.PlayerQueries;
using Soccer.Web.Features.Queries.TeamQueries;
using Soccer.Web.ViewModels;


namespace Soccer.Web.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IValidator<CreatePlayerCommand> createCommandValidator;
        private readonly IValidator<UpdatePlayerCommand> updateCommandValidator;

        public PlayerController(
            IMediator mediator, 
            IMapper mapper,
            IValidator<CreatePlayerCommand> createCommandValidator,
            IValidator<UpdatePlayerCommand> updateCommandValidator) : base(mediator)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.createCommandValidator = createCommandValidator ?? throw new ArgumentNullException(nameof(createCommandValidator));
            this.updateCommandValidator = updateCommandValidator ?? throw new ArgumentNullException(nameof(updateCommandValidator));
        }

        // GET: PlayerController
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<PlayerSummaryViewModel> viewModel = new List<PlayerSummaryViewModel>();

            if(!string.IsNullOrEmpty(searchString))
            {
                var playerViewModel = await mediator.Send(new SearchPlayerByCnpQuery() {CNP = searchString});

                if (playerViewModel != null)
                {
                    viewModel = new List<PlayerSummaryViewModel> {playerViewModel};
                }
            }
            else
            {
                viewModel = await mediator.Send(new GetAllPlayersQuery());
            }
            
            return View(viewModel);
        }

 
        // GET: PlayerController/Create
        public async Task<IActionResult> Create()
        {
            await LoadTeams();

            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerViewModel viewModel)
        {
            var command = mapper.Map<CreatePlayerCommand>(viewModel);

            var result = await createCommandValidator.ValidateAsync(command);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, null);
                await LoadTeams();
                return View();
            }

            try
            {
                await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadTeams();
                return View();
            }
        }

        // GET: PlayerController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetPlayerByIdQuery { Id = id };
            var viewModel = await mediator.Send(query);

            if (viewModel == null)
            {
                return NotFound();
            }

            await LoadTeams();

            return View(viewModel);
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerViewModel viewModel)
        {
            var command = mapper.Map<UpdatePlayerCommand>(viewModel);

            var result = await updateCommandValidator.ValidateAsync(command);

            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, null);
                await LoadTeams();
                return View();
            }

            try
            {
                await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadTeams();
                return View();
            }
        }

        private async Task LoadTeams()
        {
            var teams = await mediator.Send(new GetAllTeamsQuery());
            ViewBag.Teams = teams.Select(team => new SelectListItem { Value = team.Id.ToString(), Text = team.Name });
        }
    }
}
