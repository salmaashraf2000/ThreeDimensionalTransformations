using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDimentionalTransformations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Class3d Operation3d = new Class3d();
                double x, y, z;
                Console.WriteLine("Please enter x ,y and z\n");
                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                z = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter a choice\n 1-Transformation\n 2-Scaling\n 3-Reflection\n 4-Rotation Arround Axis\n 5-Rotation with Arbitary axis\n 6-shearing\n 7-exit\n");
                string val;
                val = Console.ReadLine();
               
                if (val == "1")
                {
                    Console.WriteLine("Please enter t1 ,t2 and t3\n");
                    double t1, t2, t3;

                    t1 = Convert.ToDouble(Console.ReadLine());
                    t2 = Convert.ToDouble(Console.ReadLine());
                    t3 = Convert.ToDouble(Console.ReadLine());
                    Operation3d.Transformation(x, y, z, t1, t2, t3);


                }
                else if (val == "2")
                {
                    Console.WriteLine("Please enter s1 ,s2 and s3\n");
                    double s1, s2, s3;
                    s1 = Convert.ToDouble(Console.ReadLine());
                    s2 = Convert.ToDouble(Console.ReadLine());
                    s3 = Convert.ToDouble(Console.ReadLine());
                    Operation3d.Scaling(x, y, z, s1, s2, s3);

                }
                else if (val == "3")
                {
                    Console.WriteLine("Please choose the reflection around plane\n 1-z y plane\n 2-x y plane\n 3-x z plane\n");

                    val = Console.ReadLine();
                    if (val == "1")
                    {
                        Operation3d.Reflection(x, y, z, 1, 0, 0);
                    }
                    else if (val == "2")
                    {
                        Operation3d.Reflection(x, y, z, 0, 1, 0);
                    }
                    else
                    {
                        Operation3d.Reflection(x, y, z, 0, 0, 1);
                    }


                }
                else if (val == "4")
                {

                    Console.WriteLine("Please choose the rotation around axis 1-x axis\n 2-y axis\n 3-z axis\n");

                    val = Console.ReadLine();
                    Console.WriteLine("Please choose the rotation angle\n");
                    double angle;
                    angle = Convert.ToDouble(Console.ReadLine());
                    if (val == "1")
                    {
                        Operation3d.RotationAroundAxis(x, y, z, 1, 0, 0, angle);
                    }
                    else if (val == "2")
                    {
                        Operation3d.RotationAroundAxis(x, y, z, 0, 1, 0, angle);
                    }
                    else
                    {
                        Operation3d.RotationAroundAxis(x, y, z, 0, 0, 1, angle);
                    }

                }
                else if (val == "5")
                {
                    Console.WriteLine("Please enter t1 ,t2, t3, alpa, beta and theta\n");
                    double t1, t2, t3, alpha, beta, theta;

                    t1 = Convert.ToDouble(Console.ReadLine());
                    t2 = Convert.ToDouble(Console.ReadLine());
                    t3 = Convert.ToDouble(Console.ReadLine());
                    alpha = Convert.ToDouble(Console.ReadLine());
                    beta = Convert.ToDouble(Console.ReadLine());
                    theta = Convert.ToDouble(Console.ReadLine());
                    Operation3d.RotationArbitaryAxis(x, y, z, alpha, beta, theta, t1, t2, t3);

                }
                else if (val == "6")
                {
                    Console.WriteLine("Please choose the shearing in which axis\n 1-x axis\n 2-y axis\n 3-z axis\n");
                    val = Console.ReadLine();
                    double sh1, sh2;
                    if (val == "1")
                    {
                        Console.WriteLine("Please enter shear y and shear z\n");
                        sh1 = Convert.ToDouble(Console.ReadLine());
                        sh2 = Convert.ToDouble(Console.ReadLine());
                        Operation3d.Shearing(x, y, z, sh1, sh2, 1, 0, 0);
                    }
                    else if (val == "2")
                    {
                        Console.WriteLine("Please enter shear x and shear z\n");
                        sh1 = Convert.ToDouble(Console.ReadLine());
                        sh2 = Convert.ToDouble(Console.ReadLine());
                        Operation3d.Shearing(x, y, z, sh1, sh2, 0, 1, 0);
                    }
                    else
                    {
                        Console.WriteLine("Please enter shear x and shear y\n");
                        sh1 = Convert.ToDouble(Console.ReadLine());
                        sh2 = Convert.ToDouble(Console.ReadLine());
                        Operation3d.Shearing(x, y, z, sh1, sh2, 0, 0, 1);
                    }
                }
                else if (val == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid choice\n");
                    continue;
                }
                Operation3d.Print();
            }
        }
    }
}
