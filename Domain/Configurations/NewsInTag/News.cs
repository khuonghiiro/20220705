using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.NewsInTag
{
    public class News
    {
        public string NewsId { get; set; } = string.Empty;
        public int Top { get; set; }
        public string SkipNewsId { get; set; } = string.Empty;
    }
}
