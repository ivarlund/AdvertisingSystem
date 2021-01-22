using System;
using System.Collections.Generic;

#nullable disable

namespace AdvertisingSystem.Models
{
    public partial class BillingAdress
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int Recipient { get; set; }

        public virtual Advertiser Advertiser { get; set; }
    }
}
