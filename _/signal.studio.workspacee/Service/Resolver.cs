using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal.Studio.Workspace.Service {
    public class Resolver {
        private static bool BuildState = false;
        private static IContainer Container { get; set; }
        private static void Build() {
            var builder = new ContainerBuilder();
            builder.RegisterType<StoreService>().As<IStoreService>().SingleInstance();
            Container = builder.Build();
            BuildState = true;
        }
        public static T Resolve<T>() {
            if (!BuildState) Build();
            using var scope = Container.BeginLifetimeScope();
            return scope.Resolve<T>();
        }
        public static void Dispose() {
            if (Container != null) Container.Dispose();
        }
    }
}
