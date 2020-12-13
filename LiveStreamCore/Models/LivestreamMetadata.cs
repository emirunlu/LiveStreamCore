using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveStreamCore.Models
{
    public class LivestreamMetadata
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string username { get; set; }
        public string src { get; set; }
        public string thumbnail { get; set; }
    }
}
