using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection servicesCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicesCollection);
            }

            return ServiceTool.Create(servicesCollection);
        }
    }
}
