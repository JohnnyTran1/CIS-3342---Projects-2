using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuilderLibrary
{
    public class Buyer
    {
        private string firstName;
        private string lastName;
        private string suffix;
        private string emailAddress;
        private string address;
        private string phoneNumber;
        private string employmentInformation;
        private string income;

        public Buyer()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            suffix = string.Empty;
            emailAddress = string.Empty;
            address = string.Empty;
            phoneNumber = string.Empty;
            employmentInformation = string.Empty;
            income = string.Empty;
        }

        public Buyer(string firstName,string lastName, string suffix, string emailAddress, string address, string phoneNumber, string employmentInformation, string income)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.suffix = suffix;
            this.emailAddress = emailAddress;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.employmentInformation = employmentInformation;
            this.income = income;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Suffix
        {
            get { return suffix; }
            set { suffix = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string EmploymentInformation
        {
            get { return employmentInformation; }
            set { employmentInformation = value; }
        }

        public string Income
        {
            get { return income; } 
            set { income = value; } 
        }
    }
}
