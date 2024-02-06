using CoreLibrary.Data;
using CoreLibrary.Models;
using CoreLibrary.Repositories;
using CoreLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P05_01_DI_Contactos_MAROTO_angel.Validators;
using P05_01_DI_Contactos_MAROTO_angel.ViewModels;
using P05_01_DI_Contactos_MAROTO_angel.Views;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace P05_01_DI_Contactos_MAROTO_angel;

public partial class App : Application
{

    // Se ejecuta antes de que se inicialice App.xaml
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ConfigLanguage();

        if (CheckDatabaseConnection())
        {
            var serviceProvider = ConfigureServices();
            // Obligamos a que cargue desde aquí no desde App.xaml para que poder utilizar IoC
            var window = serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
        }
        else
        {
            MessageBox.Show("No se pudo conectar a la base de datos.\nCree y levante el contenedor Docker siguiendo los pasos en la carpeta /Scripts/README.md.", "Error de conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
    }

    private static bool CheckDatabaseConnection()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost,1433;Database=WorkSpaceDB;User Id=sa;Password=StrongPassw0rd;TrustServerCertificate=true;")
                .Options;
        try
        {
            using (var dbContext = new AppDbContext(dbContextOptions))
            {
                var openConnectionTask = dbContext.Database.OpenConnectionAsync();

                // Esperar hasta que la conexión se abra o hasta que pasen 4 segundos
                var completedTask = Task.WhenAny(openConnectionTask, Task.Delay(4000));

                if (completedTask.Result == openConnectionTask)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            return false;
        }
    }

    private void ConfigLanguage()
    {
        var langCode = P05_01_DI_Contactos_MAROTO_angel.Properties.Settings.Default.SelectedLanguage;
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
    }

    private static ServiceProvider ConfigureServices()
    {
        IServiceCollection servicesCollection = new ServiceCollection();

        // Views
        servicesCollection.AddScoped<MainWindow>();
        servicesCollection.AddScoped<HomeView>();
        servicesCollection.AddScoped<EmployeeView>();
        servicesCollection.AddScoped<DepartmentView>();
        servicesCollection.AddScoped<ChartView>();
        servicesCollection.AddScoped<SettingsView>();

        // ViewModels
        servicesCollection.AddScoped<MainViewModel>();
        servicesCollection.AddScoped<HomeViewModel>();
        servicesCollection.AddScoped<EmployeeViewModel>();
        servicesCollection.AddScoped<DepartmentViewModel>();
        servicesCollection.AddScoped<ChartViewModel>();
        servicesCollection.AddScoped<SettingsViewModel>();

        // Validator
        servicesCollection.AddScoped<DepartmentValidator>();
        servicesCollection.AddScoped<EmployeeValidator>();

        // Services
        servicesCollection.AddSingleton<IDataService<Department>, DepartmentService>();
        servicesCollection.AddSingleton<IDataService<Employee>, EmployeeService>();

        // Repositories
        servicesCollection.AddSingleton<IRepository<Department>, DepartmentRepositoryImpl>();
        servicesCollection.AddSingleton<IRepository<Employee>, EmployeeRepositoryImpl>();

        // DataBaseContext
        servicesCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=WorkSpaceDB;User Id=sa;Password=StrongPassw0rd;TrustServerCertificate=true;"));

        // Transit para futura API por los Endpoints

        return servicesCollection.BuildServiceProvider();
    }
}
