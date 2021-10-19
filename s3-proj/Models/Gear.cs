using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3_proj.Models
{
    public class Gear
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int lengthInMm { get; set; }
        public int widthInMm { get; set; }
        public int weightInGram { get; set; }
        public string imgURL { get; set; }
        public string videoURL { get; set; }
    }
}
