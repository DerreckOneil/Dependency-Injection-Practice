using System;

namespace BasicExample {
    public class DependentClass : IDisposable {
        private IHttpServer server;

        public DependentClass(IHttpServer server) {
            this.server = server;

            Console.WriteLine(nameof(DependentClass) + "'s ctor");
            if (server != null)
                server.Listen(65535);
        }

        public void Dispose() {
            server.Stop();
            Console.WriteLine("Dispose()");
        }
    }
}
