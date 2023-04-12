using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public class EducationalInstitution : ContactData
    {
        public string Address { get; set; }
        public string Director { get; set; }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Address: {Address}, Director: {Director}";
        }
    }
}
