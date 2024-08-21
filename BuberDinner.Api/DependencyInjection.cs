using BuberDinner.Api.Common.Mapping;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Api;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddMappings();
    services.AddControllers();
    services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
    return services;
  }
}