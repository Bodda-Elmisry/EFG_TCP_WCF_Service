﻿using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EFG_TCP_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //[OperationContract]
        //void Submit(SubmitOrderDTO submitOrder);

        //[OperationContract]
        //void Submit(IEnumerable<SubmitOrderDTO> submitOrderList);

        [OperationContract(Name = "SubmitSingle")]
        void Submit(SubmitOrderDTO submitOrder);

        [OperationContract(Name = "SubmitMultiple")]
        void Submit(IEnumerable<SubmitOrderDTO> submitOrderList);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "EFG_TCP_WCF_Service.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
