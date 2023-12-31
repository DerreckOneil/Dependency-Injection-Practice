﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private static IContainer container;

        public static async Task Main() {
            Console.WriteLine("Hello world");

            container = new Container();
            //LINQ Example
            //TODO: Split this out into a different little C# program
            List<Transform> transforms = new List<Transform> {
                new Transform { localPosition = new Vector3(1, 2, 3) },
                new Transform { localPosition = new Vector3(1, 7, 3) },
                new Transform { localPosition = new Vector3(1, 2, 5) },
            };

            foreach (Vector3 vec in transforms.Select(t => t.localPosition).Where(l => l.y > 5))
                Console.WriteLine(vec);

            container.Bind<IHttpServer, MockHttpServer>();
            container.Bind<DependentClass>(); //You may see this

            //MAYBE you need to "build" the container here, depending on the DI framework

            DependentClass c = container.Resolve<DependentClass>();
            IHttpServer b = container.Resolve<IHttpServer>();

            Console.WriteLine("Waiting 2sec...");
            await Task.Delay(2000);
            Console.WriteLine("Returning back to the main program!");

            //WARNING: This does NOT call DependentClass's Dispose method!
            container.Dispose();
        }
    }
}
