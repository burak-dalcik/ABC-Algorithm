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

        // Rosenbrock fonksiyonu
        public static double Rosenbrock(double[] x)
        {
            double sum = 0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                sum += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + Math.Pow(x[i] - 1, 2);
            }
            return sum;
        }

        // Rastrigin fonksiyonu
        public static double Rastrigin(double[] x)
        {
            double sum = 10 * x.Length;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * x[i] - 10 * Math.Cos(2 * Math.PI * x[i]);
            }
            return sum;
        }
    }
} 