using Autofac;

namespace SignalStudio.Core {
    public class SignalStudioResolver {
        private static bool BuildState = false;
        private static IContainer Container { get; set; }
        private static void Build() {
            var builder = new ContainerBuilder();
            Container = builder.Build();
            BuildState = true;
        }
        public static T Resolve<T>() {
            if (!BuildState) Build();
            using var scope = Container.BeginLifetimeScope();
            return scope.Resolve<T>();
        }

    }
}
