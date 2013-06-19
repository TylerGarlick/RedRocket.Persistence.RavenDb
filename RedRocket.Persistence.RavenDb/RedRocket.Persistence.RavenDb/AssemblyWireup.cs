using FlitBit.IoC;
using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: WireupDependency(typeof(WireupThisAssembly))]
[assembly: Wireup(typeof(RedRocket.Persistence.RavenDb.AssemblyWireup))]
namespace RedRocket.Persistence.RavenDb
{
    public sealed class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {
            Container.Root
                     .ForGenericType(typeof(IReadOnlyRepository<>))
                     .Register(typeof(Repository<>))
                     .End();

            Container.Root
                     .ForGenericType(typeof(IRepository<>))
                     .Register(typeof(Repository<>))
                     .ResolveAnInstancePerScope()
                     .End();
        }
    }
}
