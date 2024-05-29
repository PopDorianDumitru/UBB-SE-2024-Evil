using System.Configuration;
using System.Data;
using System.Windows;
using All_Things_Evil.Controllers;
using All_Things_Evil.Repos;
using All_Things_Evil.Services;
using All_Things_Evil.Validators;
using All_Things_Evil.ViewModels;
using All_Things_Evil.Views.WindowFactory;
using Microsoft.Extensions.DependencyInjection;
using UBB_SE_2024_Evil.Controllers;

namespace All_Things_Evil
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            this.serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICreditCardService, CreditCardService>();
            services.AddSingleton<ICreditCardValidator, CreditCardValidator>();
            services.AddSingleton<IWindowFactory, WindowFactory>();
            services.AddTransient<IScamBotsViewModel, ScamBotsViewModel>();
            services.AddSingleton<ICreditCardProxyRepository, CreditCardProxyRepository>();
            services.AddSingleton<ISubscriptionServiceViewModel, SubscriptionServiceViewModel>();
            services.AddSingleton<ISweetStealingViewModel, SweetStealingViewModel>();
            services.AddTransient<IFightingGameViewModel, FightingGameViewModel>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<IGameProxyRepository, GameProxyRepository>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SweetSpartacusPage window = new SweetSpartacusPage(serviceProvider.GetRequiredService<IWindowFactory>());
            window.Show();
        }
    }
}
