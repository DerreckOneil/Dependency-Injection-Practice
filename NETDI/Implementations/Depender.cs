using System;

namespace NETDI {
    public class Depender {
        private ITextSerializer serializer;

        private string name;
        private float radius;
        private float diameter;

        public Depender(ITextSerializer serializer, string name, float radius) {
            this.serializer = serializer;

            this.name = name;
            this.radius = radius;
            this.diameter = 2 * radius;

            Console.WriteLine(name + " -- " + radius + " -- " + diameter);
        }
    }
}
