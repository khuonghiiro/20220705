using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.News
{
    public class News
    {
        public string NewsId { get; set; } = string.Empty;
        public int TopNewsSameZone { get; set; }
    }
}
