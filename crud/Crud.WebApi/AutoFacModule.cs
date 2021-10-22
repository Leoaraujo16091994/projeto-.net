using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.WebApi
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Crud.Infrastructure.AutoFacModule());

            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                   .AsSelf()
                   .InstancePerLifetimeScope();
        }

    }
}
