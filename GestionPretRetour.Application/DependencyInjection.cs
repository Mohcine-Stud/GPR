using Microsoft.Extensions.DependencyInjection;
using MediatR;
using GestionPretRetour.Application.Persistence.Repositories;
using GestionPretRetour.Application.Orders.Services;
using GestionPretRetour.Application.Returns.Services;

namespace GestionPretRetour.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<ICreateOrderService, CreateOrderService>();
        services.AddScoped<IReturnOrderBooksService, ReturnOrderBooksService>();
        services.AddScoped<IPenaltyService, PenaltyService>();

        return services;
    }
}
