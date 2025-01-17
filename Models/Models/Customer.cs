﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Person, IComparable<Customer>, ICloneable
    {
        [JsonProperty("customerType")]
        public string CustomerType { get; set; }

        [JsonProperty("point")]
        public int Poin { get; set; }

        [JsonProperty("createdTime")]         
        public DateTime CreatTime { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public Customer() { }

        public Customer(//string personId, string fullName,
            //DateTime birthDate, string address, string phoneNumber,
            string customerType, int poin, DateTime creatTime, string email)
            //: base(personId, fullName, birthDate, address, phoneNumber)
        {
            CustomerType = customerType;
            Poin = poin;
            CreatTime = creatTime;
            Email = email;
        }

        public Customer(string personId, string fullName,
                        DateTime birthDate, string address, string phoneNumber,
           string customerType, int poin, DateTime creatTime, string email)
        : base(personId, fullName, birthDate, address, phoneNumber)
        {
            CustomerType = customerType;
            Poin = poin;
            CreatTime = creatTime;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   base.Equals(obj) &&
                   PersonId == customer.PersonId;
        }

        public override int GetHashCode()
        {
            int hashCode = 2079290131;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PersonId);
            return hashCode;
        }

        public int CompareTo(Customer other)
        {
            return PersonId.CompareTo(other.PersonId);
        }

        public object Clone()
        {
            return new Customer(PersonId, FullName.ToString(), BirthDate, Address, PhoneNumber, CustomerType, Poin, CreatTime, Email);
        }
    }
}
