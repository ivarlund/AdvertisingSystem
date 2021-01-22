using System;
using System.Collections.Generic;

#nullable disable

namespace AdvertisingSystem.Models
{
    public partial class Advertiser
    {
        public Advertiser()
        {
            Ads = new HashSet<Ad>();
        }

        public int Id { get; set; }
        public int? Subscriber { get; set; }
        public int? OrgNo { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Adress { get; set; }
        public int? ZipCode { get; set; }
        public string City { get; set; }

        public virtual BillingAdress BillingAdress { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
    }
}
