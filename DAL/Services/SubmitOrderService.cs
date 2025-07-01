using DAL.DataCommunication;
using DAL.DTOs;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class SubmitOrderService : ISubmitOrderService
    {
        private readonly DapperExecution dapper;

        public SubmitOrderService()
        {
            this.dapper = new DapperExecution(string.Empty);
        }

        public bool SubmitOrder(SubmitOrderDTO submitOrder)
        {
            var sql = $"INSERT INTO [dbo].[SubmitOrders]" +
                $"\r\n           ([OrderId]" +
                $"\r\n           ,[InstructionValue])" +
                $"\r\n     VALUES" +
                $"\r\n           (@OrderId" +
                $"\r\n           ,@InstructionValue)";

            var parameters = new
            {
                @OrderId = submitOrder.Order,
                @InstructionValue = submitOrder.InstructionValue
            };

            var added = dapper.Execute(sql, parameters);

            if (added > 0)
            {
                var updateOrderInstructionSql = $"Update OrderInstructions" +
                                                $"\r\nset Closed = 1" +
                                                $"\r\nWhere OrderId = @OrderId " +
                                                $"\r\nand InstructionId = @InstructionId";

                var updateOrderInstructionParameters = new
                {
                    @OrderId = submitOrder.Order,
                    @InstructionId = submitOrder.InstructionId
                };

                dapper.Execute(updateOrderInstructionSql, updateOrderInstructionParameters);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
