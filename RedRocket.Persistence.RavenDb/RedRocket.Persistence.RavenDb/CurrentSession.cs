using System;
using FlitBit.IoC;
using FlitBit.IoC.Meta;
using Raven.Client;
using RedRocket.Persistence.RavenDb.Configuration;

namespace RedRocket.Persistence.RavenDb
{
    public interface ICurrentSession
    {
        IDocumentSession Session { get; }
    }

    [ContainerRegister(typeof(ICurrentSession), RegistrationBehaviors.Default, ScopeBehavior = ScopeBehavior.InstancePerScope)]
    public class CurrentSession : ICurrentSession, IDisposable
    {
        readonly IRavenDbConfiguration _config;
        public IDocumentSession Session { get; private set; }

        public CurrentSession(IRavenDbConfiguration config)
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