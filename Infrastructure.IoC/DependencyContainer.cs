using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.Commands;
using Banking.Domain.CommandsHandlers;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using Infrastructure.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>();

            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
        }
    }
}
