using Autofac;
using Pretriage.Services;

namespace Pretriage
{
    public class PretiageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<ExcelService>().As<IExcelService>();
            builder.RegisterType<PretriageService>().As<IPretriageService>();
            builder.RegisterType<UserService>().As<IUserService>();

        }
    }
}

