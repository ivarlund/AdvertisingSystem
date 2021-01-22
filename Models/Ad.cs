using System;
using System.Collections.Generic;

#nullable disable

namespace AdvertisingSystem.Models
{
    public partial class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ItemPrice { get; set; }
        public int AdPrice { get; set; }
        public int Publicist { get; set; }

        public virtual Advertiser Advertiser { get; set; }
    }
}
