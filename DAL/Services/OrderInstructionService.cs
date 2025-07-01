using DAL.DataCommunication;
using DAL.DTOs;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class OrderInstructionService : IOrderInstructionService
    {
        private readonly DapperExecution dapper;

        public OrderInstructionService()
        {
            this.dapper = new DapperExecution(string.Empty);
        }

        public IEnumerable<OrderInstructionResultDTO> GetOrdersInstructions()
        {
            var query = $"select oi.OrderId [OrderId], " +
                        $"\r\n\t   oi.InstructionId [InstructionId], " +
                        $"\r\n\t   i.Value [InstructionValue], " +
                        $"\r\n\t   oi.Priority [Priority], " +
                        $"\r\n\t   oi.Closed [Closed]" +
                        $"\r\nfrom OrderInstructions oi " +
                        $"\r\njoin Instructions i on oi.InstructionId = i.Id" +
                        $"\r\nwhere Closed = 0" +
                        $"\r\norder by Priority, OrderId";

            var result = dapper.Query<OrderInstructionResultDTO>(query, null);

            return result;
        }
    }
}
