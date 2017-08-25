using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubmitForm.Models
{
    public class TB_SUBMIT_LIST
    {        
        public List<up_submit_selectList_Result> submit_list { get; set; }
        public search search_list { get; set; }
        public List<TB_SUBMIT> all_list { get; set; }
    }
}