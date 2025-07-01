using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class SubmitOrderDTO
    {
        public string Order { get; set; }
        public int InstructionId { get; set; }
        public int InstructionValue { get; set; }
    }
}
