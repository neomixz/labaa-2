using System;
using System.Collections.Generic;
using System.Text;

namespace labaa_2._2
{
    class Triangle2
    {
        public int Xf, Xq, Xe, Yf, Yq, Ye;
        public double FQ, QE, FE;

        public void T2_Coordinates()
        {
            Console.WriteLine("Уведiть координати вершин трикутника 2: ");

            Console.Write("F | x: ");
            Xf = int.Parse(Console.ReadLine());
            Console.Write("F | y: ");
            Yf = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Q | x: ");
            Xq = int.Parse(Console.ReadLine());
            Console.Write("Q | y: ");
            Yq = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("E | x: ");
            Xe = int.Parse(Console.ReadLine());
            Console.Write("E | y: ");
            Ye = int.Parse(Console.ReadLine());

            Console.WriteLine();
        }
        public void T2_Sides_Lenght()
        {
            FQ = Math.Round(Math.Sqrt((Xq - Xf) * (Xq - Xf) + (Yq - Yf) * (Yq - Yf)));
            QE = Math.Round(Math.Sqrt((Xe - Xq) * (Xe - Xq) + (Ye - Yq) * (Ye - Yq)));
            FE = Math.Round(Math.Sqrt((Xe - Xf) * (Xe - Xf) + (Ye - Yf) * (Ye - Yf)));
        }
    }
}
