using System.Collections.Generic;
using System.Diagnostics;
using Singularity;

namespace SingularityEnumerable
{
    public static class Program
    {
        public static void Main()
        {
            var container = new Container(builder => {
                builder.Register<ICommon, Dependency1>();
                builder.Register<ICommon, Dependency2>();
            });

            var instances = container.GetInstance<IReadOnlyCollection<ICommon>>();
            // instances.Count == 1

            var instance = container.GetInstance<Dependency2>();
            // Singularity.Exceptions.DependencyResolveException: Failed to resolve dependency SingularityEnumerable.Dependency2
        }
    }

    public interface ICommon
    {

    }

    public class Dependency1 : ICommon
    {

    }

    public class Dependency2 : ICommon
    {
        public Dependency2(ITransitiveDependency unregistered)
        {

        }
    }

    public interface ITransitiveDependency
    {

    }
}
