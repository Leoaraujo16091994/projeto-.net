using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure
{
   public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(AutoFacModule).Assembly)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
