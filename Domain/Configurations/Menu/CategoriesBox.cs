using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations.Menu
{
    public class CategoriesBox
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ShortURL { get; set; } = string.Empty;
    }
}
