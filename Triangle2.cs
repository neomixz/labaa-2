using System;
using System.Collections.Generic;
using System.Text;

namespace labaa_2._2ReWrite
{
    class Triangle2
    {
        public int Xf { get; set; }
        public int Yf { get; set; }
        public int Xq { get; set; }
        public int Yq { get; set; }
        public int Xe { get; set; }
        public int Ye { get; set; }

        public int FQ { get; set; }
        public int QE { get; set; }
        public int FE { get; set; }

        public void Coordinates()
        {
            Console.WriteLine("Введiть координати вершин трикутника 2: ");

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

            Console.Clear();
        }
        public void Lenght()
        {
            FQ = Convert.ToInt32(Math.Round(Math.Sqrt((Xq - Xf) * (Xq - Xf) + (Yq - Yf) * (Yq - Yf))));
            QE = Convert.ToInt32(Math.Round(Math.Sqrt((Xe - Xq) * (Xe - Xq) + (Ye - Yq) * (Ye - Yq))));
            FE = Convert.ToInt32(Math.Round(Math.Sqrt((Xe - Xf) * (Xe - Xf) + (Ye - Yf) * (Ye - Yf))));
        }
        public void GetInfo()
        {
            Console.WriteLine($"FQ: {FQ} QE: {QE} FE: {FE}");
            Console.WriteLine();
        }
    }              
}
