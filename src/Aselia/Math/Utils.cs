using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aselia.src.Aselia.Math {
    public static class MathU {
        public static float Pow(float b, int power) {
            float result = 1;
            for (int i = 0; i < power; i++) {
                result *= b;
            }
            return result;
        }

        public static float fastSqrt(float f) {
            float f2 = 0.5f * f;
            int n = BitConverter.ToInt32(BitConverter.GetBytes(f), 0);
            n = 1597463007 - (n >> 1);
            f = BitConverter.ToSingle(BitConverter.GetBytes(n), 0);
            f *= 1.5f - f2 * f * f;
            return f;
        }
    }
}
