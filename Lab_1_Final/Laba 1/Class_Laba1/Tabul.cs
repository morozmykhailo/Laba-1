using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1.Class_Laba1
{
    internal class Tabul
    {
        public double[,] xy = new double[1000, 2];
        //Кількість елементів (обчислень) в масиві
        public int n = 0;
        //Методи для обчислення функцій
        private double f1(double x)
        {
            double temp = x + 2.0;
            double sin = Math.Sin(temp);
            if (Math.Abs(sin) < 1e-15)
            {
                return double.NaN; // повертатимемо NaN, якщо sin(x) дуже близький до нуля, щоб уникнути ділення на нуль Math.Pow(Math.Abs(x), 5.0) * cot
            }

            double cot = Math.Cos(temp) / sin;
            return Math.Pow(Math.Abs(x), 5) * cot;
        }
        private double f2(double x)
        {

            return (5 * x + Math.Pow(x, 2)) / Math.Pow(Math.Pow(x, 2) + 3, 3);
        }
        private double f3(double x)
        {
            // чисельник: sin^2(x+3)
            double numerator = Math.Pow(Math.Sin(x + 3.0), 2.0);

            // котангенсовий аргумент: π * x^3 (radians)
            double arg = Math.PI * Math.Pow(x, 3.0);
            double sinArg = Math.Sin(arg);

            const double eps = 1e-15;

            // повертатимемо NaN, якщо sin(x) дуже близький до нуля, щоб уникнути ділення на нуль
            if (Math.Abs(sinArg) < eps)
            {
                return double.NaN;
            }

            double cot = Math.Cos(arg) / sinArg;

            double denominator = Math.Pow(x, 5.0) - cot;

            // також перевірка знаменника на близькість до нуля
            if (Math.Abs(denominator) < eps)
            {
                return double.NaN;
            }

            return numerator / denominator;
        }


        //Метод Табулювання
        public void tab(double xn = 3.35, double xk = 36.26, double h = 0.1, double a = 0.2)
        {
            double x = xn, y;
            int i = 0;
            while (x <= xk)
            {
                if (x < 0)
                {
                    y = f1(x);
                }
                else
                {
                    if ((x >= 0) && (x < a))
                    {
                        y = f2(x);
                    }
                    else
                    {
                        y = f3(x);
                    }
                }

                xy[i, 0] = x;
                xy[i, 1] = y;
                x += h;
                i++;
            }
            n = i;
        }
    }
}

