using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_CRUD
{
    class Client
    {
        public string ClientId { get; set; }
        public string CompanyName { get; set; }
        public string Agent { get; set; }
        public string AgentWorkplace { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }



        public Client()
        {

        }

        public Client(string clientId, string companyName)
        {
            ClientId = clientId;
            CompanyName = companyName;
        }


        public Client(string clientId, string companyName, string agent, string agentWorkplace, string adress, string city, string region, string postCode, string country, string phoneNumber, string fax)
        {
            ClientId = clientId;
            CompanyName = companyName;
            Agent = agent;
            AgentWorkplace = agentWorkplace;
            Adress = adress;
            City = city;
            Region = region;
            PostCode = postCode;
            Country = country;
            PhoneNumber = phoneNumber;
            Fax = fax;
        }

        public string ToString()
        {
            return ClientId + " | " + CompanyName + " | " + Agent + " | " + AgentWorkplace + " | " + Adress + " | " + City + " | " + Region + " | " + PostCode + " | " + Country + " | " + PhoneNumber + " | " + Fax;
        }
    }
}
