﻿using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Microsoft.AspNet.SignalR;

namespace SignalR.Castle.Windsor
{
    public class WindsorDependencyResolver : DefaultDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.ResolveAll(serviceType).Cast<object>() : base.GetServices(serviceType);
        }
    }
}