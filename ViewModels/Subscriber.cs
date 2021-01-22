using System;
using System.Collections.Generic;

#nullable disable

namespace AdvertisingSystem.ViewModels
{
    public partial class Subscriber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonNo { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
    }
}
