using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.Home
{
    public class NewsByZone
    {
        public int Top { get; set; }
        public int TypeId { get; set; }
        public int ZoneId { get; set; }
        public int DisplayStyle { get; set; }
        public int AttachToTimeLine { get; set; }
    }
}
