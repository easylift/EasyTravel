

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace EasyLift.DependencyResolution
{
    /// <summary>
    /// The structure map web api dependency scope.
    /// </summary>
    public class StructureMapWebApiDependencyScope : StructureMapDependencyScope, IDependencyScope
    {
        public StructureMapWebApiDependencyScope(IContainer container)
            : base(container) {
        }
    }
}
