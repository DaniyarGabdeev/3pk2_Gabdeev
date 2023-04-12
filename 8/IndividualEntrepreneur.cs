using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public class IndividualEntrepreneur : ContactData
    {
        public string CompanyName { get; set; }


        public override string GetInfo()
        {
            return base.GetInfo() + $", Company: {CompanyName}";
        }
    }

}
