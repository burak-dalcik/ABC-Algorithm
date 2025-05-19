using System;

namespace ABCAlg
{
    public static class TestFunctions
    {
        // Sphere fonksiyonu
        public static double Sphere(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i];
            }
            return sum;
        }
    }
} 