using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBVTA.Models.Entities
{
    public class TreeData
    {
        public string text { get; set; }
        public string icon { get; set; }
        public string Class { get; set;}
        public string href { get; set;}
        public List<TreeData> nodes { get; set; }
    }
}
