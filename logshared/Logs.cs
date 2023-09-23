using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logshared
{
    public class Logs
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Action { get; set; }
    }
}
