using DAL.DTOs;
using DAL.Interfaces;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.ServiceReference1;
using DAL.Entities;

namespace ClientApp.Helpers
{
    public class OrderSubmitHelper
    {
        public void SubmitOrders(IEnumerable<OrderInstructionResultDTO> ordersInstructions)
        {


            Parallel.ForEach(ordersInstructions.GroupBy(o => o.Priority), orderInstructionGroup =>
            {
                var orders = new List<SubmitOrderDTO>();

                foreach (var orderInstruction in orderInstructionGroup)
                {
                    var submitOrder = new SubmitOrderDTO
                    {
                        Order = orderInstruction.OrderId,
                        InstructionId = orderInstruction.InstructionId,
                        InstructionValue = orderInstruction.InstructionValue
                    };

                    orders.Add(submitOrder);
                }

                FireSubmition(orders);
                orders.Clear();
            });

            //foreach(var orderInstructionGroup in ordersInstructions.GroupBy(o=> o.Priority))
            //{
            //    foreach (var orderInstruction in orderInstructionGroup)
            //    {
            //        var submitOrder = new SubmitOrderDTO
            //        {
            //            Order = orderInstruction.OrderId,
            //            InstructionId = orderInstruction.InstructionId,
            //            InstructionValue = orderInstruction.InstructionValue
            //        };

            //        orders.Add(submitOrder);
            //    }

            //    FireSubmition(orders);
            //    orders.Clear();



            //}

            

            Console.WriteLine("Submitted order.");
        }

        private void FireSubmition(IEnumerable<SubmitOrderDTO> orders)
        {
            var client = new Service1Client();

            client.SubmitMultiple(orders.ToArray());
            client.Close();
        }




}
}
