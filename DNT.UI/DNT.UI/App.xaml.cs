using DNT.DAL;
using DNT.UI.ViewModels;
using DNT.UI.ViewModels.EditViewModels;
using DNT.UI.ViewModels.OverviewViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace DNT.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient(typeof(MainWindow));
            services.AddScoped<UserOverviewViewModel>();
            services.AddScoped<CompanyOverviewViewModel>();
            services.AddScoped<CardOverviewViewModel>();
            services.AddScoped<EditUserViewModel>();
            services.AddScoped<EditCompanyViewModel>();
            services.AddScoped<EditCardViewModel>();
            services.AddScoped<MainViewModel>();
            services.AddDBServices();
        } 
    }
}
