using System;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Raven.Client;

namespace RedRocket.Persistence.RavenDb
{
    public interface ICurrentDocumentSession
    {
        IDocumentSession Session { get; }
    }

    [ContainerRegister(typeof(ICurrentDocumentSession), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.InstancePerScope)]
    public class CurrentDocumentSession : ICurrentDocumentSession, IDisposable
    {
        readonly IDocumentStoreConfiguration _config;
        public IDocumentSession Session { get; private set; }

        public CurrentDocumentSession(IDocumentStoreConfiguration config)
        {
            _config = config;
            Session = _config.DocumentStore.OpenSession();
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}