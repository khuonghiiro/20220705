using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.VideoPlayListInZone
{
    public class PlayListInZone
    {
        public int ZoneId { get; set; }
        public int Mode { get; set; }
        public int Status { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
