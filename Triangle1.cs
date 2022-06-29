using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace labaa_2._2
{
    class Triangle1
    {
        int Xa, Xb, Xc, Ya, Yb, Yc;
        double AB, BC, AC;

        string path = @"D:\programing\labaa 2.2\saving.json";
        int EXIT;

        public Triangle1(Triangle2 triangle2)
        {
            do
            {
                try
                {
                    Menu(triangle2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (EXIT != 3);

        }

        ///////////////////////////////////////////////////////
        
        void Menu(Triangle2 triangle2)
        {
            Console.Clear();
            Console.WriteLine("1. Use saved DATA | 2. Change DATA | 3. Exit");
            int a = int.Parse(Console.ReadLine());

            switch (a)
            {
                case 1:
                    Console.Clear();
                    Json_Deserialize(triangle2);
                    Triangles_Sides_Lenght(triangle2);
                    All_Methods(triangle2);
                    Json_Serialize(triangle2);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    Coordinates_Writing(triangle2);
                    Triangles_Sides_Lenght(triangle2);
                    All_Methods(triangle2);
                    Json_Serialize(triangle2);
                    Console.ReadLine();
                    break;
                case 3:
                    EXIT = 3;
                    break;
            }
        }

        ///////////////////////////////////////////////////////
        

        void Coordinates_Writing(Triangle2 triangle2)
        {
            T1_Coordinates();           //координати трикутника 1
            triangle2.T2_Coordinates(); //координати трикутника 2
            Console.Clear();            
        }
        void Triangles_Sides_Lenght(Triangle2 triangle2)
        {
            T1_Sides_Lenght();           //довжини трикутника 1
            triangle2.T2_Sides_Lenght(); //довжини трикутника 2

            Console.WriteLine($"AB: {Math.Round(AB)}, BC: {Math.Round(BC)}, AC: {Math.Round(AC)}");
            Console.WriteLine($"FQ: {triangle2.FQ}, QE: {triangle2.QE}, FE: {triangle2.FE}");
            Console.WriteLine("\n");
        }
        void All_Methods(Triangle2 triangle2)
        {
            Rivnist(triangle2);
            SP();
            Heights();
            Medians();
            Bisectors();
            InOutCircle();
            Type();
            Point_Turn();
            Centre_Turn();
        }
        void Json_Serialize(Triangle2 triangle2)
        {
            int[] coordinates = { Xa, Xb, Xc, Ya, Yb, Yc, triangle2.Xf, triangle2.Xq, triangle2.Xe, triangle2.Yf, triangle2.Yq, triangle2.Ye };

            string json_serialized = JsonSerializer.Serialize(coordinates);

            string path = @"D:\programing\labaa 2.2\saving.json";

            File.WriteAllText(path, json_serialized);
        }
        void Json_Deserialize(Triangle2 triangle2)
        {
            string json_file = File.ReadAllText(path);
            int[] saved_coordinates = JsonSerializer.Deserialize<int[]>(json_file);
            Xa = saved_coordinates[0];
            Xb = saved_coordinates[1];
            Xc = saved_coordinates[2];
            Ya = saved_coordinates[3];
            Yb = saved_coordinates[4];
            Yc = saved_coordinates[5];
            triangle2.Xf = saved_coordinates[6];
            triangle2.Xq = saved_coordinates[7];
            triangle2.Xe = saved_coordinates[8];
            triangle2.Yf = saved_coordinates[9];
            triangle2.Yq = saved_coordinates[10];
            triangle2.Ye = saved_coordinates[11];
        }

        
        ///////////////////////////////////////////////////////
        
        void T1_Coordinates()
        {
            Console.WriteLine("Уведiть координати вершин трикутника 1: ");

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

            Console.WriteLine("\n");
        }

        void T1_Sides_Lenght()
        {
            AB = Math.Sqrt((Xb - Xa) * (Xb - Xa) + (Yb - Ya) * (Yb - Ya));
            BC = Math.Sqrt((Xc - Xb) * (Xc - Xb) + (Yc - Yb) * (Yc - Yb));
            AC = Math.Sqrt((Xc - Xa) * (Xc - Xa) + (Yc - Ya) * (Yc - Ya));
        }

        ///////////////////////////////////////////////////////

        void Rivnist(Triangle2 triangle2)
        {
            double[] Sides_T1 = { AB, BC, AC };
            double[] Sides_T2 = { triangle2.FQ, triangle2.QE, triangle2.FE };
            var taken_place = new List<int>();
            int n = 0;

            for (int i = 0; i < Sides_T1.Length; i++)
            {
                for (int j = 0; j < Sides_T2.Length; j++)
                {
                    if (Sides_T1[i] == Sides_T2[j] && taken_place.Contains(j) == false)
                    {
                        n += 1;
                        taken_place.Add(j);
                    }
                }
            }

            switch (n)
            {
                case 3:
                    Console.WriteLine("Трикутники рiвнi!!");
                    break;
                default:
                    Console.WriteLine("Трикутники не рiвнi!!");
                    break;
            }
        }

        void SP()
        {
            int S, P, p;

            P = Convert.ToInt32(Math.Round(AB + BC + AC));
            p = Convert.ToInt32(Math.Round((AB + BC + AC) / 2));
            S = Convert.ToInt32(Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC))));
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine($"THE PERIMETER OF TRIANGLES : {P}");
            Console.WriteLine($"THE AREA OF TRIANGLES : {S}");
        }

        void Heights()
        {
            double S, p;
            p = (AB + BC + AC) / 2;
            S = Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC)));

            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("ATITUDES' VALUES");

            Console.WriteLine($"H(a) = {Math.Round((2 * S) / AB)}");
            Console.WriteLine($"H(b) = {Math.Round((2 * S) / BC)}");
            Console.WriteLine($"H(c) = {Math.Round((2 * S) / AC)}");
        }

        void Medians()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("MADIANS' VALUES");

            Console.WriteLine($"M(a) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2 * BC * BC + 2 * AC * AC - AB * AB))}");
            Console.WriteLine($"M(b) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2 * AB * AB + 2 * AC * AC - BC * BC))}");
            Console.WriteLine($"M(c) = {Math.Round(1.0 / 2.0 * Math.Sqrt(2 * AB * AB + 2 * BC * BC - AC * AC))}");
        }

        void Bisectors()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("BISECTORS' VALUES");
            double p = (AB + BC + AC) / 2;

            Console.WriteLine($"L(a) = {Math.Round(((2.0 * Math.Sqrt(BC * AC * p * (BC + AC - AB))) / BC + AC))}");
            Console.WriteLine($"L(b) = {Math.Round(((2.0 * Math.Sqrt(AB * AC * p * (AB + AC - BC)))) / AB + AC)}");
            Console.WriteLine($"L(c) = {Math.Round(((2.0 * Math.Sqrt(AB * BC * p * (AB + BC - AC)))) / AB + BC)}");
        }

        void InOutCircle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            double S, p;
            p = (AB + BC + AC) / 2;
            S = Math.Round(Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC)));

            Console.Write("INCIRCLE'S RADIUS : ");
            Console.WriteLine(Math.Round(S / p));

            Console.Write("EXCIRCLE'S RADIUS : ");
            Console.WriteLine(Math.Round((AB * BC * AC) / (4 * S)));
        }

        void Type()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            int cos_alpha = Convert.ToInt32(Math.Round(Math.Acos((BC * BC + AC * AC - AB * AB) / (2 * BC * AC)) * (180 / Math.PI)));
            int cos_beta = Convert.ToInt32(Math.Round(Math.Acos((AB * AB + AC * AC - BC * BC) / (2 * AB * AC)) * (180 / Math.PI)));
            int cos_gamma = Convert.ToInt32(Math.Round(Math.Acos((AB * AB + BC * BC - AC * AC) / (2 * AB * BC)) * (180 / Math.PI)));

            int[] degrees = { cos_alpha, cos_beta, cos_gamma };
            double[] sides = { AB, BC, AC };

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

        void Point_Turn()
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
        void Centre_Turn()
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

        ///////////////////////////////////////////////////////
    }
}
