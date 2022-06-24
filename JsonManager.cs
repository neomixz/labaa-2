using System;
using System.Text.Json;
using System.IO;

namespace labaa_2._2ReWrite
{
    class JsonManager
    {
        string path = @"D:\programing\labaa 2.2ReWrite\saving.json";


        public void Serialize (Triangle1 triangle1, Triangle2 triangle2)
        {
            int[] data = { triangle1.Xa, triangle1.Ya, triangle1.Xb, triangle1.Yb, triangle1.Xc, triangle1.Yc, triangle2.Xf, triangle2.Yf, triangle2.Xq, triangle2.Yq, triangle2.Xe, triangle2.Ye };
            string json_file = JsonSerializer.Serialize(data);
            File.WriteAllText(path, json_file);

        }

        public void Deserialize(Triangle1 triangle1, Triangle2 triangle2)
        {
            string json_file = File.ReadAllText(path);

            if (json_file != "")
            {
                int[] data = JsonSerializer.Deserialize<int[]>(json_file);
                triangle1.Xa = data[0];
                triangle1.Ya = data[1];
                triangle1.Xb = data[2];
                triangle1.Yb = data[3];
                triangle1.Xc = data[4];
                triangle1.Yc = data[5];
                triangle2.Xf = data[6];
                triangle2.Yf = data[7];
                triangle2.Xq = data[8];
                triangle2.Yq = data[9];
                triangle2.Xe = data[10];
                triangle2.Ye = data[11];
            }
        }

    }
}
