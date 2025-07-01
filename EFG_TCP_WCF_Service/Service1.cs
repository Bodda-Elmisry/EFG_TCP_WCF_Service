using DAL.DTOs;
using DAL.Interfaces;
using DAL.Services;
using EFG_TCP_WCF_Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EFG_TCP_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private ISubmitOrderService submitOrderService;
        private static readonly object _submissionLock = new object();
        public Service1()
        {
            submitOrderService = new SubmitOrderService();
        }

        public void Submit(SubmitOrderDTO submitOrder)
        {
            submitOrderService.SubmitOrder(submitOrder);
        }

        public void Submit(IEnumerable<SubmitOrderDTO> submitOrderList)
        {
            lock (_submissionLock)
            {
                var last = submitOrderList.Last();

                foreach (var submitOrder in submitOrderList)
                {
                    submitOrderService.SubmitOrder(submitOrder);


                    if (submitOrder == last)
                        SessionStore.Set("SubmitionProceessIsRunning", false);

                }
            }
        }
    }
}
