using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Chess_Game
{
    static class PropertiesIO
    {
        public static List<Properties_Blue> Read_blue(string file)
        {
            List<Properties_Blue> properties_blue = new List<Properties_Blue>();
            string[] line = null;
            Properties_Blue blue = null;

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Split(';');

                        blue = new Properties_Blue(line[0], Convert.ToByte(line[1]), Convert.ToByte(line[2]), Convert.ToByte(line[3]), Convert.ToByte(line[4]), Convert.ToByte(line[5]), Convert.ToByte(line[6]), Convert.ToByte(line[7]), Convert.ToByte(line[8]));

                        properties_blue.Add(blue);
                    }
                }
            }
            return properties_blue;

        }

        public static List<Properties_Yellow> Read_yellow(string file)
        {
            List<Properties_Yellow> properties_yellow = new List<Properties_Yellow>();
            string[] line = null;
            Properties_Yellow yellow = null;

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Split(';');

                        yellow = new Properties_Yellow(line[0], Convert.ToByte(line[1]), Convert.ToByte(line[2]), Convert.ToByte(line[3]), Convert.ToByte(line[4]), Convert.ToByte(line[5]), Convert.ToByte(line[6]), Convert.ToByte(line[7]), Convert.ToByte(line[8]));

                        properties_yellow.Add(yellow);
                    }
                }
            }
            return properties_yellow;

        }

        public static List<Properties_Field> Read_field(string file)
        {
            List<Properties_Field> properties_field = new List<Properties_Field>();
            string[] line = null;
            Properties_Field field = null;

            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Split(';');

                        field = new Properties_Field(Convert.ToByte(line[0]));

                        properties_field.Add(field);
                    }
                }
            }
            return properties_field;

        }
    }
}
