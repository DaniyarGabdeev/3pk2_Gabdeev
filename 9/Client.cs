using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public class Client : Origin
    {
        public void ClientDouble(double value)
        {
            OriginDouble(value);
        }

        public void ClientInt(int value)
        {
            OriginInt(value * 2);
        }

        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
            {
                OriginChar(value);
            }
        }
    }
}
