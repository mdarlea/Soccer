using AutoMapper;
using Soccer.Core.Entities.GameAggregate;
using Soccer.Core.Entities.PlayerAggregate;
using Soccer.Core.Entities.TeamAggregate;
using Soccer.Web.Features.Commands.PlayerCommands;
using Soccer.Web.Models;
using Soccer.Web.ViewModels;

namespace Soccer.Web
{
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

            CreateMap<GameTeam, GameTeamModel>()
                .ForMember(x => x.TeamId,
                    opt => opt.MapFrom(x => x.Team.Id));

            CreateMap<GameTeam, GameTeamSummaryViewModel>()
                .ForMember(
                    x => x.TeamName,
                    opt => opt.MapFrom(x => x.Team.Name));

            CreateMap<Game, GameModel>()
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
