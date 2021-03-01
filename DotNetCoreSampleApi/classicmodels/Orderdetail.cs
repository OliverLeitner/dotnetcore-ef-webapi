using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreSampleApi.classicmodels
{
    public partial class Orderdetail
    {
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public short OrderLineNumber { get; set; }

        public virtual Order OrderNumberNavigation { get; set; }
        public virtual Product ProductCodeNavigation { get; set; }
    }
}
