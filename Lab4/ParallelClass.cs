using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    class ParallelClass
    {

        internal long matrixMultiplyParallelLoop(double[][] matrixA, double[][] matrixB, int n)
        {
            double[][] output = new double[n][];
            for (int i = 0; i < n; i++)
            {
                output[i] = new double[n];
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Parallel.For(0, n, i => {
                for (int j = 0; j < n; j++)
                {
                    double total = 0;
                    for (int k = 0; k < n; k++)
                    {
                        total += matrixB[k][j] * matrixA[i][k];
                    }
                    output[i][j] = total;
                }
            });
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;
            /*
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(output[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            */
        }
    }

}
