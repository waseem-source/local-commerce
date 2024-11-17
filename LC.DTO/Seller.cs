using LC.DTO.SQLBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace LC.DTO
{
    public class Seller:SQLTable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
