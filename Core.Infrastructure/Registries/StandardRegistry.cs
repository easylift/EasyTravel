using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Core.Infrastructure.Registries
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}
