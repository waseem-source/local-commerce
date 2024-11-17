using LC.DTO.SQLBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace LC.DTO
{
    public class Order:SQLTable
    {
        public string CustomerName { get; set; }  // Name of the customer
        public DateTime OrderDate { get; set; }   // Date of the order
        public decimal TotalAmount { get; set; }  // Total amount of the order
    }
}
