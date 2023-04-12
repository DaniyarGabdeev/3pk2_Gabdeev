using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public abstract class ContactData
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual string GetInfo()
        {
            return $"Name: {Name}, Phone: {Phone}";
        }
    }
}
