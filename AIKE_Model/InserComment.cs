using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIKE_Model
{
    public class InserComment
    {
            public int UserID { get; set; }
            public int ProjectID { get; set; }
            public int ReplyID { get; set; }
            public string CommentContent { get; set; }
    }
}
