using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3_proj.Models
{
    public class Weapon
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string model { get; set; }             
        public string brand { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int magSize { get; set; }
        public string caliber { get; set; }
        public int stock { get; set; }
        public string fireMode { get; set; }
        public int rpm { get; set; } //rounds per minute
        public int weightInGram { get; set; }
        public int heightInMm { get; set; }
        public int widthInMm { get; set; }
        public string color { get; set; }
        public string imgURL { get; set; }
        public string videoURL { get; set; }
    }
}
