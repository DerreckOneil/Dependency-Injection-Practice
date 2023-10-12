using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AOFL.KrakenIoc.Core.V1;
using AOFL.KrakenIoc.Core.V1.Interfaces;

namespace BasicExample {
    public struct Vector3 {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString() => "(" + x + ", " + y + ", " + z + ")";
    }
    public class Transform {
        public Vector3 localPosition;
    }

    public class Program {
        public static void Main() {
            Console.WriteLine("Hello world");

            IContainer container = new Container();

            //LINQ Example
            List<Transform> transforms = new List<Transform> {
                new Transform { localPosition = new Vector3(1, 2, 3) },
                new Transform { localPosition = new Vector3(1, 7, 3) },
                new Transform { localPosition = new Vector3(1, 2, 5) },
            };

            foreach (Vector3 vec in transforms.Select(t => t.localPosition).Where(l => l.y > 5))
                Console.WriteLine(vec);

            //container.Bind<IBattery, AAABattery>();
            container.Bind<IHttpServer, MockHttpServer>();
        }
    }
}
