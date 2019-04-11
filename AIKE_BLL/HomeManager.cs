using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIKE_Model;
namespace AIKE_BLL
{
   public class HomeManager
    {
        public static List<ProjectType> GetProjectTypes()
        {
            return AIKE_DAL.HomeServer.GetProjectTypes();
        }
    }
}
