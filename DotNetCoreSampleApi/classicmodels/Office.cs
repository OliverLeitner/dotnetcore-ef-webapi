using System.Collections.Generic;

#nullable disable

namespace DotNetCoreSampleApi.classicmodels
{
    public partial class Office
    {
        public Office()
        {
            Employees = new HashSet<Employee>();
        }

        public string OfficeCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Territory { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
