using System;
using System.Collections.Generic;
using System.Text;

namespace foodOrder.Models
{
   public class items
    {
        public int categoryId { get; set; }
        public string description { get; set; }
        public int itemId { get; set; }
        public string itemImageUrl { get; set; }
        public string itemName { get; set; }
        public string price { get; set; }
        public string rating { get; set; }
    }
}
