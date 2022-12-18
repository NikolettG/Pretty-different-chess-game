using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Chess_Game
{
    class Properties_Yellow
    {

        public string Name { get; set; }
        public byte Life { get; set; }
        public byte Shield { get; set; }
        public byte Shot { get; set; }
        public byte Y_coordinate { get; set; }
        public byte X_coordinate { get; set; }
        public byte Steps { get; set; }
        public byte Y_coordinate_now { get; set; }
        public byte X_coordinate_now { get; set; }


        public Properties_Yellow(string name, byte life, byte shield, byte shot, byte y_coordinate, byte x_coordinate, byte steps, byte y_coordinate_now, byte x_coordinate_now)
        {
            Name = name;
            Life = life;
            Shield = shield;
            Shot = shot;
            Y_coordinate = y_coordinate;
            X_coordinate = x_coordinate;
            Steps = steps;
            Y_coordinate_now = y_coordinate_now;
            X_coordinate_now = x_coordinate_now;
        }
    }
}
