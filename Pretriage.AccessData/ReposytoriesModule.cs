using Autofac;
using Pretriage.AccessData.Repositories;


namespace Pretriage.AccessData
{
    public class ReposytoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ConfigRepository>().As<IConfigRepository>();
            builder.RegisterType<PretriageRepository>().As<IPretriageRepository>();
            builder.RegisterType<UnitRepository>().As<IUnitRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
