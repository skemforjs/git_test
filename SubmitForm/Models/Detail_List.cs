using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubmitForm.Models
{
    public class Detail_List
    {
        public List<up_coment_select_list_Result> coment_list { get; set; }
        public up_submit_selectdetail_Result detail { get; set; }
        public up_coment_select_list_Result coment { get; set; }
    }
}