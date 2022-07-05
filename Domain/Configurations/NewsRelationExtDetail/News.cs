using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.NewsRelationExtDetail
{
    public class News
    {
        public string DeviceId { get; set; } = string.Empty;
        public string NewsId { get; set; } = string.Empty;
        public int PageIndex { get; set; }
    }
}
