using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyVote.Application.Services;


namespace MyVote.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoterService, VoterService>();

            return services;
        }
    }
}
