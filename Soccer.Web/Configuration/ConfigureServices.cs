using FluentValidation;

using MediatR;

using Soccer.Core.Interfaces;
using Soccer.Infrastructure.Data;
using Soccer.Web.Application.Commands.PlayerCommands;

namespace Soccer.Web.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreatePlayerCommand).Assembly);
        services.AddValidatorsFromAssemblyContaining<CreatePlayerCommandValidator>();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }
}