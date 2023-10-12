using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace NETDI {
    public class Program {
        public static async Task Main(string[] args) {
            //A. (async I/O in the background, but does NOT NEED ANOTHER THREAD)
            //Task<string> readTask = File.ReadAllTextAsync("C:/example.txt");

            //B. MOST-LIKELY uses another thread
            Task<int> doSomeHeavy = Task.Run(() => {
                int sum = 0;
                for (int i = 0; i < 100000000; i++)
                    sum++;
                return sum;
            });

            Console.WriteLine("Hello, World!");

            //Dependency Injection
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ITextSerializer, JsonSerializer>();
            services.AddSingleton<Depender>((provider) => {
                ITextSerializer dependency = provider.GetService<ITextSerializer>();
                return new Depender(dependency, "Foo Bar", 7.4f);
            });

            using (ServiceProvider provider = services.BuildServiceProvider()) {
                Depender d = provider.GetService<Depender>();
            }

            int result = await doSomeHeavy;
            //string fileText = await readTask;
        }
    }
}