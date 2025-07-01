using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTOs;
using DAL.Interfaces;
using DAL.Services;

namespace ClientApp.Helpers
{
    internal class OrderInstructionHelper
    {
        private readonly IOrderInstructionService orderInstructionService;

        public OrderInstructionHelper()
        {
            this.orderInstructionService = new OrderInstructionService();
        }

        public IEnumerable<OrderInstructionResultDTO> GetOrdersInstructionsAsync()
        {
            try
            {
                return orderInstructionService.GetOrdersInstructions();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error fetching order instructions: {ex.Message}");
                return Enumerable.Empty<OrderInstructionResultDTO>();
            }
        }
    }
}
