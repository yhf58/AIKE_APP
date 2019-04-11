using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
   public class AdminUsers
    {
        //tb_User.UserID,tb_UserType.UserType,AccountNumber,RealName,AccountBalance,Phone
        public int ID { get; set; }
        public string UserType { get; set; }
        public string AccountNumber { get; set; }
        public string  RealName { get; set; }
        public decimal AccountBalance{ get; set; }
        public string Phone { get; set; }
    }
}
