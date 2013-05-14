using FlitBit.IoC;
using FlitBit.Wireup;
using FlitBit.Wireup.Meta;
using RedRocket.Persistence.Common;
using RedRocket.Persistence.RavenDb;

[assembly: WireupDependency(typeof(FlitBit.IoC.WireupThisAssembly))]
[assembly: Wireup(typeof(RedRocket.Persistence.RavenDb.AssemblyWireup))]
namespace RedRocket.Persistence.RavenDb
{
    public sealed class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {
            Container.Root
                     .ForGenericType(typeof(IReadOnlyRepository<>))
                     .Register(typeof(RavenRepository<>))
                     .End();

            Container.Root
                     .ForGenericType(typeof(IRepository<>))
                     .Register(typeof(RavenRepository<>))
                     .ResolveAnInstancePerScope()
                     .End();

            Container.Root
                     .ForType<ICurrentDocumentSession>()
                     .Register<CurrentDocumentSession>()
                     .ResolveAnInstancePerScope()
                     .End();

            Container.Root
                     .ForType<IDocumentStoreConfiguration>()
                     .Register<DocumentStoreConfiguration>()
                     .ResolveAsSingleton()
                     .End();

            Container.Root
                     .ForType<IRavenBootstrapper>()
                     .Register<RavenBootstrapper>()
                     .ResolveAsSingleton()
                     .End();

     
        }
    }
}
