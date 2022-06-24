using System;
using System.Collections.Generic;
using System.Text;

namespace labaa_2._2ReWrite
{
    class Triangle1
    {
        public int Xa { get; set; }
        public int Ya { get; set; }
        public int Xb { get; set; }
        public int Yb { get; set; }
        public int Xc { get; set; }
        public int Yc { get; set; }

        private int AB { get; set; }
        private int BC { get; set; }
        private int AC { get; set; }

        public Triangle2 triangle2;

        public void Coordinates()
        {
            Console.WriteLine("Введiть координати вершин трикутника 1: ");

            Console.Write("A | x: ");
            Xa = int.Parse(Console.ReadLine());
            Console.Write("A | y: ");
            Ya = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("B | x: ");
            Xb = int.Parse(Console.ReadLine());
            Console.Write("B | y: ");
            Yb = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("C | x: ");
            Xc = int.Parse(Console.ReadLine());
            Console.Write("C | y: ");
            Yc = int.Parse(Console.ReadLine());

            Console.Clear();
        }
        public void Lenght()
        {
            AB = Convert.ToInt32(Math.Round(Math.Sqrt((Xb - Xa) * (Xb - Xa) + (Yb - Ya) * (Yb - Ya))));
            BC = Convert.ToInt32(Math.Round(Math.Sqrt((Xc - Xb) * (Xc - Xb) + (Yc - Yb) * (Yc - Yb))));
            AC = Convert.ToInt32(Math.Round(Math.Sqrt((Xc - Xa) * (Xc - Xa) + (Yc - Ya) * (Yc - Ya))));
        }
        public void GetInfo()
        {
            Console.WriteLine($"AB: {AB} BC: {BC} AC: {AC}");
            Console.WriteLine();
        }


        public void ALL_METHODS()
        {
            Rivnist();
            SP();
            Heights();
            Medians();
            Bisectors();
            InOutCircle();
            Type();
            Point_Turn();
            Centre_Turn();
        }

        public void Rivnist() 
        {
            int[] Sides_T1 = { AB, BC, AC };
            int[] Sides_T2 = { triangle2.FQ, triangle2.QE, triangle2.FE };

            int[] used_sides = { 3, 3, 3 };
            int n = 0;
            int m = 0;

            for (int i = 0; i < Sides_T1.Length; i++) 
            {
                for (int j = 0; j < Sides_T2.Length; j++) 
                {
                    if (Sides_T1[i] == Sides_T2[j] && i == 0)
                    {
                        n += 1;
                        used_sides[m] = j;
                        break;
                    }
                    int check = 0;
                    for (int t = 0; t < used_sides.Length - (used_sides.Length - i); t++) 
                    {
                        if (Sides_T1[i] == Sides_T2[j] && used_sides[t] != j)
                        {
                            n += 1;
                            used_sides[m] = j;
                            check = 1;
                            break;
                        }
                    }
                    if (check == 1)
                        break;
                }
            }
            
            if (n == 3)
                Console.WriteLine("Triangles are equel!!");
            else
                Console.WriteLine("Triangles are not equel!!");
        }

       

        private void SP()
        {
            int S, P, p;

            P = AB + BC + AC;
            p = Convert.ToInt32(Math.Round((AB + BC + AC) / 2.0));
            S = Convert.ToInt32(Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC))));
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine($"THE PERIMETER OF TRIANGLES : {P}");
            Console.WriteLine($"THE AREA OF TRIANGLES : {S}");
        }
        private void Heights()
        {
            int p;
            double S;
            p = Convert.ToInt32(Math.Round((AB + BC + AC) / 2.0));
            S = Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC)));

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("ATITUDES' VALUES");

            Console.WriteLine($"H(a) = {Math.Round((2.0 * S) / AB)}");
            Console.WriteLine($"H(b) = {Math.Round((2.0 * S) / BC)}");
            Console.WriteLine($"H(c) = {Math.Round((2.0 * S) / AC)}");
        }
        private void Medians()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("MADIANS' VALUES");

            Console.WriteLine($"M(a) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2.0 * BC * BC + 2.0 * AC * AC - AB * AB))}");
            Console.WriteLine($"M(b) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2.0 * AB * AB + 2.0 * AC * AC - BC * BC))}");
            Console.WriteLine($"M(c) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2.0 * AB * AB + 2.0 * BC * BC - AC * AC))}");
        }
        private void Bisectors()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("BISECTORS' VALUES");
            int p = Convert.ToInt32(Math.Round((AB + BC + AC) / 2.0));

            Console.WriteLine($"L(a) = {Math.Round(((2.0 * Math.Sqrt(BC * AC * p * (BC + AC - AB))) / BC + AC))}");
            Console.WriteLine($"L(b) = {Math.Round(((2.0 * Math.Sqrt(AB * AC * p * (AB + AC - BC)))) / AB + AC)}");
            Console.WriteLine($"L(c) = {Math.Round(((2.0 * Math.Sqrt(AB * BC * p * (AB + BC - AC)))) / AB + BC)}");
        }
        private void InOutCircle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            double p;
            int S;
            p = (AB + BC + AC) / 2;
            S = Convert.ToInt32(Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC))));

            Console.Write("INCIRCLE'S RADIUS : ");
            Console.WriteLine(Math.Round(S / p));

            Console.Write("EXCIRCLE'S RADIUS : ");
            Console.WriteLine(Math.Round((AB * BC * AC) / (4.0 * S)));
        }
        private void Type() //масиви
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            int cos_alpha = Convert.ToInt32(Math.Round(Math.Acos((BC * BC + AC * AC - AB * AB) / (2.0 * BC * AC)) * (180.0 / Math.PI)));
            int cos_beta = Convert.ToInt32(Math.Round(Math.Acos((AB * AB + AC * AC - BC * BC) / (2.0* AB * AC)) * (180.0 / Math.PI)));
            int cos_gamma = Convert.ToInt32(Math.Round(Math.Acos((AB * AB + BC * BC - AC * AC) / (2.0 * AB * BC)) * (180.0 / Math.PI)));

            int[] degrees = { cos_alpha, cos_beta, cos_gamma };
            int[] sides = { AB, BC, AC };

            int enter = 0;

            foreach (var item in degrees)
            {
                if (item == 90)
                {
                    Console.WriteLine("Трикутник прямокутний!!");
                    enter = 1;
                }
                else if (item > 90)
                {
                    Console.WriteLine("Трикутник тупокутний!!");
                    enter = 1;
                }
            }

            if (enter != 1)
            {
                for (int i = 1; i < sides.Length; i++)
                {
                    if (sides[0] == sides[i])
                    {
                        enter += 1;
                    }
                }
                switch (enter)
                {
                    case 1:
                        Console.WriteLine("Трикутник рiвнобедрений!!");
                        break;
                    case 2:
                        Console.WriteLine("Трикутник рiвностороннiй!!");
                        break;
                    default:
                        Console.WriteLine("Трикутник рiзньостороннiй!!");
                        break;
                }
            }


        }
        private void Point_Turn()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            double ϕ = 0;
            Console.Write($"ENTER THE ANGLE OF TURNING AROUND 'A' : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            ϕ = (int.Parse(Console.ReadLine())) * (Math.PI / 180);
            Console.ResetColor();


            //B
            int new_Xb = Convert.ToInt32((Xb - Xa) * Math.Cos(ϕ) - (Yb - Ya) * Math.Sin(ϕ));
            int new_Yb = Convert.ToInt32((Xb - Xa) * Math.Sin(ϕ) - (Yb - Ya) * Math.Cos(ϕ));
            //x1 = x∗cos(ϕ)−y∗sin(ϕ)
            //y1 = x∗sin(ϕ)+y∗cos(ϕ)
            //C
            int new_Xc = Convert.ToInt32((Xc - Xa) * Math.Cos(ϕ) - (Yc - Ya) * Math.Sin(ϕ));
            int new_Yc = Convert.ToInt32((Xc - Xa) * Math.Sin(ϕ) - (Yc - Ya) * Math.Cos(ϕ));
            Console.WriteLine($"Новi координати трикутника: A({Xa};{Ya}), B({new_Xb + Xa};{new_Yb + Ya}), C({new_Xc + Xa};{new_Yc + Ya})");
        }
        private void Centre_Turn()
        {
            Console.WriteLine("\n");

            Console.Write($"ENTER THE ANGLE OF TURNING AROUND 'O' : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            double ϕ = (int.Parse(Console.ReadLine())) * (Math.PI / 180);
            Console.ResetColor();

            try
            {
                double a, b;
                a = ((Xc ^ 2 + Yc ^ 2 - Xb ^ 2 - Yb ^ 2) * (Yb - Ya) - (Xb ^ 2 + Yb ^ 2 - Xa ^ 2 - Ya ^ 2) * (Yb - Yc)) / ((2 * Xa - 2 * Xb) * (Yb - Yc) - (2 * Xb - 2 * Xc) * (Yb - Ya));
                b = Math.Round((a * (2 * Xb - 2 * Xc) + (Xc ^ 2 + Yc ^ 2 - Xb ^ 2 - Yb ^ 2)) / (2 * (Yb - Yc)));


                Console.WriteLine($"EXCIRCLE CENTER' COORDUNATES : ({a};{b})");

                //A
                int new_Xa = Convert.ToInt32((Xa - a) * Math.Cos(ϕ) - (Ya - b) * Math.Sin(ϕ));
                int new_Ya = Convert.ToInt32((Xa - a) * Math.Sin(ϕ) - (Ya - b) * Math.Cos(ϕ));
                //B
                int new_Xb = Convert.ToInt32((Xb - a) * Math.Cos(ϕ) - (Yb - b) * Math.Sin(ϕ));
                int new_Yb = Convert.ToInt32((Xb - a) * Math.Sin(ϕ) - (Yb - b) * Math.Cos(ϕ));
                //C
                int new_Xc = Convert.ToInt32((Xc - a) * Math.Cos(ϕ) - (Yc - b) * Math.Sin(ϕ));
                int new_Yc = Convert.ToInt32((Xc - a) * Math.Sin(ϕ) - (Yc - b) * Math.Cos(ϕ));
                Convert.ToInt32(a);
                Convert.ToInt32(b);
                Console.WriteLine($"Новi координати трикутника: A({new_Xa + a};{new_Ya + b}), B({new_Xb + a};{new_Yb + b}), C({new_Xc + a};{new_Yc + b})");
            }
            catch
            {
                Console.WriteLine("There is the problem 'without solution'!!");
            }

        }
    }
}
