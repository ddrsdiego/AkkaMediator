﻿using Castle.MicroKernel;
using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp.IoC
{
    public class ContravariantFilter : IHandlersFilter
    {
        public bool HasOpinionAbout(Type service)
        {
            if (!service.IsGenericType)
            {
                return false;
            }

            var genericType = service.GetGenericTypeDefinition();
            var genericArguments = genericType.GetGenericArguments();

            return genericArguments.Count() >= 1
                   && genericArguments.FirstOrDefault().GenericParameterAttributes.HasFlag(GenericParameterAttributes.Contravariant);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}
