using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class SubmitOrder
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int InstructionValue { get; set; }
    }
}
