using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class OrderInstructionResultDTO
    {
        public string OrderId { get; set; }
        public int InstructionId { get; set; }
        public int InstructionValue { get; set; }
        public int Priority { get; set; }
        public bool Closed { get; set; }
    }
}
