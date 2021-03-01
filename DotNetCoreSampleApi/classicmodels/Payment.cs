using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreSampleApi.classicmodels
{
    public partial class Payment
    {
        public int CustomerNumber { get; set; }
        public string CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer CustomerNumberNavigation { get; set; }
    }
}
