using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poc.MassTransit.Message
{
    public class LogTeste
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Action { get; set; }
    }
}