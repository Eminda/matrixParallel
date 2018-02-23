using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var systemPath = System.Environment.
                              GetFolderPath(
                                  Environment.SpecialFolder.CommonApplicationData
                              );
            var completePath = Path.Combine(systemPath, "files");
            StreamWriter outputFile = new StreamWriter("report.txt");

            //Increase n from 200 to 2000
            for (int n = 200; n <= 2000; n += 200)
            {
                Console.WriteLine("Current execution n :"+n);
                //these arrays store time array for each execution type
                double[] serial = new double[20];
                double[] parallel = new double[20];
                double[] parallelOP = new double[20];
                double[] speedUp = new double[20];

                //take 10 samples of each type
                for (int t = 0; t < 10; t++)
                {
                    double[][] matrixA = new double[n][];
                    double[][] matrixB = new double[n][];

                    //create 2d arrays
                    for (int i = 0; i < n; i++)
                    {
                        matrixA[i] = new double[n];
                        matrixB[i] = new double[n];
                    }
                    Random ran = new Random();

                    //generate random values
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrixA[i][j] = ran.Next(2, 5);
                            matrixB[i][j] = ran.Next(1, 5);
                        }
                    }

                    //execute matrix multiplication parallely without optimization
                    ParallelClass p = new ParallelClass();
                    long pTime = p.matrixMultiplyParallelLoop(matrixA, matrixB, n);
                    parallel[t] = pTime;
                    Console.WriteLine("Parallel non-optimized execution time : " + pTime);

                    //execute matrix multiplication parally with optimization
                    OptimizeParallel op = new OptimizeParallel();
                    long opTime = op.matrixMultiplyParallelLoop(matrixA, matrixB, n);
                    parallelOP[t] = opTime;
                    Console.WriteLine("Parallel optimized execution time : " + opTime);

                    //execute matrix multiplication serially
                    Serial s = new Serial();
                    long serialTime = s.matrixMultiplySerial(matrixA, matrixB, n);
                    serial[t] = serialTime;
                    Console.WriteLine("Serial execution time : " + serialTime);

                    //set speed up
                    speedUp[t] = serialTime / (opTime * 1.0);
                }

                //write to file
                outputFile.WriteLine("N is : " + n);
                outputFile.WriteLine("Serial Times: ");
                foreach (var value in serial)
                {
                    outputFile.Write(value + ",");
                }
                outputFile.WriteLine();
                outputFile.WriteLine("Parallel Times: ");
                foreach (var value in parallel)
                {
                    outputFile.Write(value + ",");
                }
                outputFile.WriteLine();
                outputFile.WriteLine("Parallel Optimized Times: ");
                foreach (var value in parallelOP)
                {
                    outputFile.Write(value + ",");
                }
                outputFile.WriteLine();
                outputFile.WriteLine("speedUp Times: ");
                foreach (var value in speedUp)
                {
                    outputFile.Write(value + ",");
                }
                outputFile.WriteLine();
            }
            //save data in file
            outputFile.Flush();
        }
    }
}


