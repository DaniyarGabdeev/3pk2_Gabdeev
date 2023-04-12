using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public class Person : ContactData
    {
        public string Address { get; set; }
        public int Age { get; set; }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Address: {Address}, Age: {Age}";
        }
    }

}
