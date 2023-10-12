using System.Threading.Tasks;

namespace BasicExample {
    public interface IHttpServer {
        public Task Listen(int port);
        public void Stop();
    }
}
