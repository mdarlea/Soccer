using AutoMapper;

using Soccer.Core.Entities.GameAggregate;
using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Entities.TeamAggregate;
using Soccer.Web.Application.Commands.PlayerCommands;
using Soccer.Web.Application.Responses;
using Soccer.Web.ViewModels;

using GameTeam = Soccer.Core.Entities.GameAggregate.GameTeam;

namespace Soccer.Web
{
    /// <summary>
    /// Configure mappings from domain entities to DTO models and view models
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Team, TeamViewModel>();

            CreateMap<Player, PlayerSummaryViewModel>()
                .ForMember(
                    x => x.TeamName,
                    opt => opt.MapFrom(x => x.Team.Name));
            CreateMap<Player, PlayerViewModel>()
                .ForMember(
                    x => x.TeamId,
                    opt => opt.MapFrom(x => x.Team.Id))
                .ForMember(
                    x => x.StreetAddress,
                    opt => opt.MapFrom(x => x.Address.Street))
                .ForMember(
                    x => x.City,
                    opt => opt.MapFrom(x => x.Address.City))
                .ForMember(
                    x => x.PostalCode,
                    opt => opt.MapFrom(x => x.Address.PostalCode))
                .ForMember(
                    x => x.Country,
                    opt => opt.MapFrom(x => x.Address.Country));

            CreateMap<GameTeam, Application.Responses.GameTeam>()
                .ForMember(x => x.TeamId,
                    opt => opt.MapFrom(x => x.Team.Id));

            CreateMap<GameTeam, GameTeamSummaryViewModel>()
                .ForMember(
                    x => x.TeamName,
                    opt => opt.MapFrom(x => x.Team.Name));

            CreateMap<Game, GameResponse>()
                .ForMember(
                    x => x.Date,
                    opt => opt.MapFrom(x => x.DateAndTime.Date))
                .ForMember(
                    x => x.Time,
                    opt => opt.MapFrom(x => x.DateAndTime.DateTime));

            CreateMap<Game, GameSummaryViewModel>()
                .ForMember(
                    x => x.Date,
                    opt => opt.MapFrom(x => x.DateAndTime.Date))
                .ForMember(
                    x => x.Time,
                    opt => opt.MapFrom(x => x.DateAndTime.DateTime));


            CreateMap<PlayerViewModel, CreatePlayerCommand>();
            CreateMap<PlayerViewModel, UpdatePlayerCommand>();
        }
    }
}
