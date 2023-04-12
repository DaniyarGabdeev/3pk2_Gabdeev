using _8;
using System;

var contacts = new List<ContactData>();

contacts.Add(ContactDataFactory.Create("person"));
contacts[0].Name = "Иванов Иван";
contacts[0].Phone = "+89324546372";
((Person)contacts[0]).Address = "Чкалова 10";
((Person)contacts[0]).Age = 20;

contacts.Add(ContactDataFactory.Create("entrepreneur"));
contacts[1].Name = "Анастазиз Анастасия";
contacts[1].Phone = "+89121234904";
((IndividualEntrepreneur)contacts[1]).CompanyName = "ИП Анастазиз";

contacts.Add(ContactDataFactory.Create("edu"));
contacts[2].Name = "Училищи Док";
contacts[2].Phone = "+89435647389";
((EducationalInstitution)contacts[2]).Address = "Ленинская 23/3";
((EducationalInstitution)contacts[2]).Director = "Джинов Джин";

foreach (var contact in contacts)
{
    Console.WriteLine(contact.GetInfo());
}