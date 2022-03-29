using BankAccount.Application.Interfaces.Repositories;
using BankAccount.Infrastructure.Persistence;
using BankAccount.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("BankAccountInMemoryDb"));
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IAccountRepo, AccountRepo>();
        }
    }
}
