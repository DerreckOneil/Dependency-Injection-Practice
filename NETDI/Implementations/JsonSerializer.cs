using System;

namespace NETDI {
    public class JsonSerializer : ITextSerializer, IDisposable {
        public string Serialize<T>(object value) {
            return "{\n    \"testValue\": 72\n}\n";
        }

        public void Dispose() {
            Console.WriteLine(nameof(JsonSerializer) + "'s Dispose()");
        }
    }
}
