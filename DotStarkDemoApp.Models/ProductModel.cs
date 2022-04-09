using System;
using System.Runtime.Serialization;

namespace DotStarkDemoApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        [IgnoreDataMember]
        public int Quantity { get; set; }

        [IgnoreDataMember]
        public DateTime DateCreated { get; set; }

        [IgnoreDataMember]
        public DateTime? DateUpdate { get; set; }
    }
}
