using BankAccount.Application.Interfaces.Services;
using BankAccount.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using MediatR;



namespace BankAccount.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
