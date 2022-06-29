using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soccer.Core.Entities.GameAggregate;
using Soccer.Web.Features.Commands.GameCommands;
using Soccer.Web.Features.Queries.GameQueries;
using Soccer.Web.Features.Queries.TeamQueries;
using Soccer.Web.Models;
using Soccer.Web.ViewModels;

namespace Soccer.Web.Controllers
{
    public class GameController : BaseController
    {
        private readonly IValidator<CreateGameCommand> createCommandValidator;
        private readonly IValidator<UpdateGameCommand> updateCommandValidator;

        public GameController(
            IMediator mediator,
            IValidator<CreateGameCommand> createCommandValidator,
            IValidator<UpdateGameCommand> updateCommandValidator) : base(mediator)
        {
            this.createCommandValidator = createCommandValidator ?? throw new ArgumentNullException(nameof(createCommandValidator));
            this.updateCommandValidator = updateCommandValidator ?? throw new ArgumentNullException(nameof(updateCommandValidator));
        }

        // GET: GameController
        public async Task<IActionResult> Index()
        {
            var viewModel = await mediator.Send(new GetAllGamesQuery());
            return View(viewModel.ToList());
        }

        // GET: GameController/Create
        public async Task<IActionResult> Create()
        {
            var teams = await mediator.Send(new GetAllTeamsQuery());

            var viewModel = new GameViewModel
            {
                AllTeams = teams.Select(t => new SelectTeamViewModel
                {
                    TeamId = t.Id,
                    TeamName = t.Name
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: GameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameViewModel viewModel)
        {
            var utcDateTime = new DateTime(
                viewModel.Date.Year, 
                viewModel.Date.Month, 
                viewModel.Date.Day, 
                viewModel.Time.Hour, 
                viewModel.Time.Minute, 
                viewModel.Time.Second);
            utcDateTime = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);

            var command = new CreateGameCommand
            {
                DateAndTime = utcDateTime,
                TeamScores = viewModel.AllTeams.Where(team => team.IsSelected).Select(team => new TeamScoreModel
                {
                    Score = team.Score,
                    TeamId = team.TeamId,
                }).ToList(),
                IsFinalScore = viewModel.IsFinalScore
            };

            var result = await createCommandValidator.ValidateAsync(command);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, null);
                return View(viewModel);
            }

            try
            {
                await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
        }

        // GET: GameController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetGameByIdQuery { Id = id };
            var model = await mediator.Send(query);

            if (model == null)
            {
                return NotFound();
            }

            var viewModel = new GameViewModel
            {
                Id = model.Id,
                Date = model.Date,
                Time = model.Time,
                IsFinalScore = model.GameTeams.Any(ts => ts.GameWon == true)
            };
            
            var teams = await mediator.Send(new GetAllTeamsQuery());

            foreach (var team in teams)
            {
                var teamScore = model.GameTeams.SingleOrDefault(ts => ts.TeamId == team.Id);

                if (teamScore != null)
                {
                    var selectTeamViewModel = new SelectTeamViewModel
                    {
                        TeamId = team.Id,
                        TeamName = team.Name,
                        IsSelected = true,
                        Score = teamScore?.Score ?? 0
                    };

                    viewModel.AllTeams.Add(selectTeamViewModel);
                }
            }

            return View(viewModel);
        }

        // POST: GameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameViewModel viewModel)
        {
            var command = new UpdateGameCommand
            {
                GameId = viewModel.Id,
                TeamScores = viewModel.AllTeams.Select(team => new TeamScoreModel
                {
                    Score = team.Score,
                    TeamId = team.TeamId,
                }).ToList(),
                IsFinalScore = viewModel.IsFinalScore
            };

            var result = await updateCommandValidator.ValidateAsync(command);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, null);
                return View(viewModel);
            }

            try
            {
                await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(viewModel);
            }
        }
    }
}
