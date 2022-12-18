using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Chess_Game
{
    class Properties_Field
    {
        public byte Size { get; set; }

        public Properties_Field(byte size)
        {
            Size = size;
        }
    }
}
