using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Logs 
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Action { get; set; }
    }
}
