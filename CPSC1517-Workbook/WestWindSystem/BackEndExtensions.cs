using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//***************************************************************
// Required namespaces
using WestWindSystem.BLL;
using WestWindSystem.DAL;
//***************************************************************

namespace WestWindSystem
{
    public static class BackEndExtensions
    {
        public static void WWBackEndDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            // Now, register all services that will be used by the system(context setup)
            // and will be provided by the system (BLL services)

            // Register the context service
            // "options" contains the connection string information
            services.AddDbContext<WestWindContext>(options);

            // Register EACH service class (BLL classes)
            // Each service class will have an AddTransient<T>() method call

            // AddTransient<T>() method to add service classes, where T is the class name
            // AddTransient is called a factory method
            services.AddTransient<CustomerServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<WestWindContext>();

                // Create an instance of the service class (CustomerServices)
                // supplying the context reference to the service class - this is where we
                // pass in the required context to the internal constructor (must be
                // performed from within the assembly, which this class (BackEndExtensions) is.
                return new CustomerServices(context!);
            });

			services.AddTransient<CategoryServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new CategoryServices(context!);
			});

			services.AddTransient<ProductServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new ProductServices(context!);
			});

			services.AddTransient<SupplierServices>((serviceProvider) =>
			{
				var context = serviceProvider.GetService<WestWindContext>();
				return new SupplierServices(context!);
			});
		}
    }
}
