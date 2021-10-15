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
        public int price { get; set; }
        public string brand { get; set; }
        public int stock { get; set; }
        public int weightInGram { get; set; }
        public int heightInMm { get; set; }
        public int widthInMm { get; set; }
    }
}
