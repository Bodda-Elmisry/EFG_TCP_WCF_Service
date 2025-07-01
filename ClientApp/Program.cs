using ClientApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderIsntructionsHelper = new OrderInstructionHelper();
            var orderIsntructions = orderIsntructionsHelper.GetOrdersInstructionsAsync();
            Console.WriteLine($"Orders Instructions count = {orderIsntructions.Count()}");
            Console.WriteLine("Press Enter to submit .....");
            Console.ReadLine();
            var orderSubmitHelper = new OrderSubmitHelper();
            orderSubmitHelper.SubmitOrders(orderIsntructions.ToList());

            Console.ReadLine();

        }
    }
}
