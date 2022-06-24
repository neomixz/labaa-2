using System;

namespace labaa_2._2ReWrite
{
    struct Methods
    {
        //protected internal Triangle triangle { get; set; }
        public void methods()
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {           
            Triangle2 triangle2 = new Triangle2();
            Triangle1 triangle1 = new Triangle1() { triangle2 = triangle2 };
            JsonManager json_Manager = new JsonManager();



            int EXIT = 0;

            try
            {

                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Use saved DATA | 2. Change DATA | 3. Exit");
                    int a = int.Parse(Console.ReadLine());

                    switch (a)
                    {
                        case 1:
                            Console.Clear();

                            json_Manager.Deserialize(triangle1, triangle2);

                            if (triangle1.Xa != 0)
                            {
                                triangle1.Lenght();
                                triangle2.Lenght();
                                triangle1.GetInfo();
                                triangle2.GetInfo();

                                triangle1.ALL_METHODS();

                                json_Manager.Serialize(triangle1, triangle2);
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("There is no data!!");
                                Console.ReadLine();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            triangle1.Coordinates();
                            triangle1.Lenght();

                            triangle2.Coordinates();
                            triangle2.Lenght();

                            triangle1.GetInfo();
                            triangle2.GetInfo();

                            triangle1.ALL_METHODS();

                            json_Manager.Serialize(triangle1, triangle2);
                            Console.ReadLine();
                            break;
                        case 3:
                            EXIT = 3;
                            break;
                    }
                }
                while (EXIT != 3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
