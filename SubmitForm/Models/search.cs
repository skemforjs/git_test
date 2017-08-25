using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubmitForm.Models
{
    public class search
    {
        public byte? rank_type_h { get; set; }
        public string search_text { get; set; }
        public int row_page { get; set; }
        public int pageNumber { get; set; }
        public byte search_type { get; set; }
    }
}