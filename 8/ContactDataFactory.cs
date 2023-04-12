using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public static class ContactDataFactory
    {
        public static ContactData Create(string category)
        {
            switch (category)
            {
                case "person":
                    return new Person();
                case "entrepreneur":
                    return new IndividualEntrepreneur();
                case "edu":
                    return new EducationalInstitution();
                default:
                    throw new ArgumentException("Unknown category");
            }
        }
    }

}
