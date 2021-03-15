using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreSampleApi.classicmodels
{
    public partial class Token
    {
        public int id { get; set; }
        public DateTime create_time { get; set; }
        public DateTime update_time { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
    }
}
