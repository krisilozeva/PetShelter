using Microsoft.Extensions.DependencyInjection;
using PetShelter.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PetShelter.Shared.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static void AutoBind(this IServiceCollection source, params Assembly[] assemblies)
        {
            source.Scan(scan => scan.FromAssemblies(assemblies)
            .AddClasses(classes => classes.WithAttribute<AutoBindAttributes>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
