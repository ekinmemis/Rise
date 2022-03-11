using Autofac;
using Rise.Phone.Core.Caching;
using Rise.Core.Infrastructure;
using Rise.Core.Infrastructure.DependencyManagement;

namespace Rise.Phone.Core.Infrastructure
{
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => -3;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //register cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
        }
    }
}
