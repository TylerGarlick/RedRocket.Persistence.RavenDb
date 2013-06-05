using System;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Raven.Client;

namespace RedRocket.Persistence.RavenDb
{
    public interface ICurrentSession
    {
        IDocumentSession Session { get; }
    }

    [ContainerRegister(typeof(ICurrentSession), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.InstancePerScope)]
    public class CurrentSession : ICurrentSession, IDisposable
    {
        readonly IDocumentStoreConfiguration _config;
        public IDocumentSession Session { get; private set; }

        public CurrentSession(IDocumentStoreConfiguration config)
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