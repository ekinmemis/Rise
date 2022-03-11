using Autofac;
using Rise.Core.Infrastructure;
using Rise.Core.Infrastructure.DependencyManagement;

namespace Rise.Phone.Services.Infrastructure
{
    /// <summary>
    /// Defines the <see cref="DependencyRegistrar" />.
    /// </summary>
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Gets the Order.
        /// </summary>
        public int Order => -1;

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="builder">The builder<see cref="ContainerBuilder"/>.</param>
        /// <param name="typeFinder">The typeFinder<see cref="ITypeFinder"/>.</param>
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterGeneric(typeof(ServiceBase<>)).As(typeof(IServiceBase<>)).InstancePerLifetimeScope();

            builder.RegisterType<PersonService>().As<IPersonService>().InstancePerLifetimeScope();
            builder.RegisterType<ContactService>().As<IContactService>().InstancePerLifetimeScope();
        }
    }
}
