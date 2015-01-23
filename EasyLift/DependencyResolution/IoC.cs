

using EasyLift.Registries;

namespace EasyLift.DependencyResolution {
    using StructureMap;
	
    public static class IoC {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<DefaultRegistry>();
                c.AddRegistry<TaskRegistry>();
                c.AddRegistry<MvcRegistry>();
                c.AddRegistry<ControllerRegistry>();
            });



        }
    }
}