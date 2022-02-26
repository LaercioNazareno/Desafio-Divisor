using System;
using Microsoft.Extensions.DependencyInjection;
using Desafio.Application.UserCases;
using Desafio.Application.Interfaces;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Services;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Data.Repositories;

namespace Desafio.infra.IoC
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            RegisterScoped(serviceCollection);
        }
        private static void RegisterScoped(IServiceCollection serviceCollection)
        {
            //Aplicação
            serviceCollection.AddScoped(typeof(IUseCaseDivisibility), typeof(UserCaseDivisibility));

            //Domínio
            serviceCollection.AddScoped(typeof(IDivisibilityDomain), typeof(DivisibilityDomain));

            //Repositorio
            serviceCollection.AddScoped(typeof(IRepository), typeof(Repository));
        }
    }
}
