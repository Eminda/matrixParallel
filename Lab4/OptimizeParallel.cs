using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class OptimizeParallel
    {
        internal long matrixMultiplyParallelLoop(double[][] matrixA, double[][] matrixB, int n)
        {
            double[][] output = new double[n][];

            double[][] bTranspose = new double[n][];

            for (int i = 0; i < n; i++)
            {
                bTranspose[i] = new double[n];
                output[i] = new double[n];
            }
            //create transpose of matrixB as bTranspose
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bTranspose[i][j] = matrixB[j][i];
                }
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Parallel.For(0, n, i =>
            {
                double[] tempT = matrixA[i];
                for (int j = 0; j < n; j++)
                {
                    double total = 0;

                    double[] temp = bTranspose[j];
                    for (int k = 0; k < n; k += 40)
                    {
                        total += temp[k] * tempT[k]
                       + temp[k + 1] * tempT[k + 1]
                       + temp[k + 2] * tempT[k + 2]
                       + temp[k + 3] * tempT[k + 3]
                       + temp[k + 4] * tempT[k + 4]
                       + temp[k + 5] * tempT[k + 5]
                      + temp[k + 6] * tempT[k + 6]
                       + temp[k + 7] * tempT[k + 7]
                       + temp[k + 8] * tempT[k + 8]
                       + temp[k + 9] * tempT[k + 9]
                       + temp[k + 1] * tempT[k + 10]
                       + temp[k + 1] * tempT[k + 11]
                       + temp[k + 2] * tempT[k + 12]
                       + temp[k + 3] * tempT[k + 13]
                       + temp[k + 4] * tempT[k + 14]
                       + temp[k + 5] * tempT[k + 15]
                      + temp[k + 6] * tempT[k + 16]
                       + temp[k + 7] * tempT[k + 17]
                       + temp[k + 8] * tempT[k + 18]
                       + temp[k + 9] * tempT[k + 19]
                       + temp[k + 1] * tempT[k + 20]
                       + temp[k + 1] * tempT[k + 21]
                       + temp[k + 2] * tempT[k + 22]
                       + temp[k + 3] * tempT[k + 23]
                       + temp[k + 4] * tempT[k + 24]
                       + temp[k + 5] * tempT[k + 25]
                      + temp[k + 6] * tempT[k + 26]
                       + temp[k + 7] * tempT[k + 27]
                       + temp[k + 8] * tempT[k + 28]
                       + temp[k + 9] * tempT[k + 29]
                       + temp[k + 1] * tempT[k + 30]
                       + temp[k + 1] * tempT[k + 31]
                       + temp[k + 2] * tempT[k + 32]
                       + temp[k + 3] * tempT[k + 33]
                       + temp[k + 4] * tempT[k + 34]
                       + temp[k + 5] * tempT[k + 35]
                      + temp[k + 6] * tempT[k + 36]
                       + temp[k + 7] * tempT[k + 37]
                       + temp[k + 8] * tempT[k + 38]
                       + temp[k + 9] * tempT[k + 39];

                    }
                    output[i][j] = total;
                };
            });

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            return elapsedMs;

        }
    }
}
