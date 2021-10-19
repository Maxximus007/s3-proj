using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3_proj.Models
{
    public class Attachment
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string descritpion { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public int widthInMm { get; set; }
        public int lengthInMm { get; set; }
        public int stock { get; set; }
        public int price { get; set; }
        public string imgURL { get; set; }
        public string videoURL { get; set; }

    }
}
