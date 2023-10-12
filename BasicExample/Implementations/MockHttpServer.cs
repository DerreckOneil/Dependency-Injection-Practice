using System;
using System.Threading.Tasks;

namespace BasicExample {
    public class MockHttpServer : IHttpServer {
        public async Task Listen(int port) {
            Console.WriteLine("Started listening (for pretend)");
            await Task.Delay(1000);
            Console.WriteLine("Finished listening (for pretend)");
        }

        public void Stop() {
            Console.WriteLine("Stopped (for pretend)");
        }
    }
}
