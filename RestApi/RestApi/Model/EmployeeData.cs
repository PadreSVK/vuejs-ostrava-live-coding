using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Model
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Prefix { get; set; }
        public PositionEnum Position { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }

    public enum PositionEnum
    {
        CEO,
        CMO,
        HR_Manager,
        IT_Manager,
        Shipping_Manager,
        Network_Admin,
        Sales_Assistant,
        Controller,
        HR_Assistant,
        Ombudsman
    }
}
