using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDimentionalTransformations
{
    class Class3d
    {
        double[,] result = new double[4, 1];

        public void Transformation(double x, double y, double z, double t1, double t2, double t3)
        {

            double[,] array1 = new double[,] { { 1, 0, 0, t1 }, { 0, 1, 0, t2 }, { 0, 0, 1, t3 }, { 0, 0, 0, 1 } };
            double[,] array2 = new double[,] { { x }, { y }, { z }, { 1 } };


            multiply(array1, array2);

        }

        public void Scaling(double x, double y, double z, double s1, double s2, double s3)
        {

            double[,] array1 = new double[,] { { s1, 0, 0, 0 }, { 0, s2, 0, 0 }, { 0, 0, s3, 0 }, { 0, 0, 0, 1 } };
            double[,] array2 = new double[,] { { x }, { y }, { z }, { 1 } };


            multiply(array1, array2);

        }

        public void RotationAroundAxis(double x, double y, double z, double xaxis, double yaxis, double zaxis, double theta)
        {
            double[,] array1;
            double[,] array2 = new double[,] { { x }, { y }, { z }, { 1 } };

            if (xaxis == 1)
            {
                array1 = new double[,] { { 1, 0, 0, 0 }, { 0, Math.Cos((Math.PI / 180) * theta), -Math.Sin((Math.PI / 180) * theta), 0 }, { 0, Math.Sin((Math.PI / 180) * theta), Math.Cos((Math.PI / 180) * theta), 0 }, { 0, 0, 0, 1 } };
            }
            else if (yaxis == 1)
            {
                array1 = new double[,] { { Math.Cos((Math.PI / 180) * theta), 0, Math.Sin((Math.PI / 180) * theta), 0 }, { 0, 1, 0, 0 }, { -Math.Sin((Math.PI / 180) * theta), 0, Math.Cos((Math.PI / 180) * theta), 0 }, { 0, 0, 0, 1 } };

            }
            else
            {
                array1 = new double[,] { { Math.Cos((Math.PI / 180) * theta), -Math.Sin((Math.PI / 180) * theta), 0, 0 }, { Math.Sin((Math.PI / 180) * theta), Math.Cos((Math.PI / 180) * theta), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }

            multiply(array1, array2);
        }
        public void RotationArbitaryAxis(double x, double y, double z, double alpha, double beta, double theta, double t1, double t2, double t3)
        {
            Transformation(x, y, z, t1, t2, t3);
            double[,] copy = result.Clone() as double[,];
            RotationAroundAxis(x, y, z, 1, 0, 0, -alpha);
            multiply(copy, result);
            copy = result.Clone() as double[,];
            RotationAroundAxis(x, y, z, 0, 1, 0, -beta);
            multiply(copy, result);
            copy = result.Clone() as double[,];
            RotationAroundAxis(x, y, z, 0, 0, 1, theta);
            multiply(copy, result);
            copy = result.Clone() as double[,];
            RotationAroundAxis(x, y, z, 0, 1, 0, beta);
            multiply(copy, result);
            copy = result.Clone() as double[,];
            RotationAroundAxis(x, y, z, 1, 0, 0, alpha);
            multiply(copy, result);
            copy = result.Clone() as double[,];
            Transformation(-x, -y, -z, t1, t2, t3);
            multiply(copy, result);
        }

        public void multiply(double[,] array1, double[,] array2)
        {
            double temp = 0;
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    temp = 0;
                    for (int k = 0; k < array1.GetLength(1); k++)
                    {
                        temp += array1[i, k] * array2[k, j];
                    }
                    result[i, j] = temp;
                }
            }
        }
        public void Reflection(double x, double y, double z, double zyplane, double xyplane, double xzplane)
        {
            double[,] array1;
            double[,] array2 = new double[,] { { x }, { y }, { z }, { 1 } };
            if (zyplane == 1)
            {
                array1 = new double[,] { { -1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }
            else if (xyplane == 1)
            {
                array1 = new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, -1, 0 }, { 0, 0, 0, 1 } };

            }
            else
            {
                array1 = new double[,] { { 1, 0, 0, 0 }, { 0, -1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }
            multiply(array1, array2);
        }
        public void Shearing(double x, double y, double z, double sh1, double sh2, double xaxis, double yaxis, double zaxis)
        {
            double[,] array1;
            double[,] array2 = new double[,] { { x }, { y }, { z }, { 1 } };

            if (xaxis == 1)
            {
                array1 = new double[,] { { 1, 0, 0, 0 }, { sh1, 1, 0, 0 }, { sh2, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }
            else if (yaxis == 1)
            {
                array1 = new double[,] { { 1, sh1, 0, 0 }, { 0, 1, 0, 0 }, { 0, sh2, 1, 0 }, { 0, 0, 0, 1 } };

            }
            else
            {
                array1 = new double[,] { { 1, 0, sh1, 0 }, { 0, 1, sh2, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            }

            multiply(array1, array2);
        }
        public void Print()
        {
            Console.WriteLine("New Point\n");
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.WriteLine(result[i, j] + " ");

                }
                Console.WriteLine();
            }
        }
    }
}
