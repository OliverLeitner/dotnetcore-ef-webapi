using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreSampleApi.classicmodels
{
    public partial class Employee
    {
        public Employee()
        {
            Customers = new HashSet<Customer>();
            InverseReportsToNavigation = new HashSet<Employee>();
        }

        public int EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string OfficeCode { get; set; }
        public int? ReportsTo { get; set; }
        public string JobTitle { get; set; }

        public virtual Office OfficeCodeNavigation { get; set; }
        public virtual Employee ReportsToNavigation { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
    }
}
