using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplodocus.Models
{
    public abstract class User
    {
        // "m_" == données membres
        protected string m_firstName { get; set; }
        protected string m_lastName { get; set; }
        protected string m_address { get; set; }
        protected string m_phoneNumber { get; set; }

        protected User(string firstName, string lastName, string address, string phoneNumber)
        {
            this.m_firstName = firstName;
            this.m_firstName = lastName;
            this.m_address = firstName;
            this.m_phoneNumber = lastName;
        }
        
        protected abstract string ToString();

    }
}