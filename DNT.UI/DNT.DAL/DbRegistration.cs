using DNT.DAL.DBUtils;
using DNT.DAL.Interfaces;
using DNT.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DNT.DAL
{
    public static class DbRegistration
    {
        public static IServiceCollection AddDBServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            return services;
        }
    }
}
