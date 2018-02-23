using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Serial
    {
        internal long matrixMultiplySerial(double[][] matrixA, double[][] matrixB, int n)
        {
            double[][] output = new double[n][];
            for (int i = 0; i < n; i++)
            {
                output[i] = new double[n];
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        output[i][j] += matrixB[k][j] * matrixA[i][k];
                    }
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
        }
    }
}