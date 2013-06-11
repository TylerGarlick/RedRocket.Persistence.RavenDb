using FlitBit.IoC;
using FlitBit.Wireup;
using FlitBit.Wireup.Meta;
using RedRocket.Persistence.Common;

[assembly: WireupDependency(typeof(WireupThisAssembly))]
[assembly: Wireup(typeof(RedRocket.Persistence.RavenDb.AssemblyWireup))]
namespace RedRocket.Persistence.RavenDb
{
    public sealed class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {
            Container.Root
                     .ForGenericType(typeof(IRavenDbReadOnlyRepository<>))
                     .Register(typeof(RavenRepository<>))
                     .End();

            Container.Root
                     .ForGenericType(typeof(IRavenDbRepository<>))
                     .Register(typeof(RavenRepository<>))
                     .ResolveAnInstancePerScope()
                     .End();
        }
    }
}
