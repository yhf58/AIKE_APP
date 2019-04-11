using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
   public class Admin_ProjectInfo
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectTypeName { get; set; }
        public decimal RaiseMoney { get; set; }
        public int State { get; set; }
    }
}
