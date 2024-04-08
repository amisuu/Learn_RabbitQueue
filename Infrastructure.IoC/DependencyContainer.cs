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
using Transfer.Application.Interfaces;
using Transfer.Application.Services;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;

namespace Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(options =>
            {
                var scopeFactory = options.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(options.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<TransferEventHandler>();

            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
        }
    }
}
