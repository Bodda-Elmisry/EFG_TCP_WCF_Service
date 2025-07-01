using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderInstruction
    {
        public string OrderId { get; set; }
        public int InstructionId { get; set; }
        public int Priority { get; set; }
        public bool Closed { get; set; }
    }
}
