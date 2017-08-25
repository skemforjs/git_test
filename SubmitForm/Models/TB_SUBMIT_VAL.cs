using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SubmitForm.Models
{
    [MetadataType(typeof(Metadata))]
    public partial class TB_SUBMIT
    {
        sealed class Metadata
        {
            public int seq { get; set; }
            [Required(ErrorMessage = "이름을 입력해 주세요.")]
            public string name { get; set; }
            [Required(ErrorMessage = "전화번호를 입력해주세요.")]
            [MaxLength(4, ErrorMessage = "4자리 이하의 숫자만 넣어주세요")]
            [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "숫자만 넣어주세요")]
            public string hp1 { get; set; }            
            [Required(ErrorMessage = "전화번호를 입력해주세요.")]
            [MaxLength(4, ErrorMessage = "4자리 이하의 숫자만 넣어주세요")]
            [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "숫자만 넣어주세요")]
            public string hp2 { get; set; }
            [Required(ErrorMessage = "전화번호를 입력해주세요.")]
            [MaxLength(4, ErrorMessage = "4자리 이하의 숫자만 넣어주세요")]
            [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "숫자만 넣어주세요")]
            public string hp3 { get; set; }
            [Required(ErrorMessage = "우편번호를 입력해 주세요.")]
            public string post_no { get; set; }
            [Required(ErrorMessage = "주소를 입력해 주세요.")]
            public string adress1 { get; set; }
            [Required(ErrorMessage = "주소를 입력해 주세요.")]
            public string adress2 { get; set; }
            [Required(ErrorMessage = "생일을 입력해 주세요.")]
            [MinLength(8, ErrorMessage = "8자리 의 숫자를 넣어주세요")]
            [MaxLength(8, ErrorMessage = "8자리 이하의 숫자만 넣어주세요")]
            [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "숫자만 넣어주세요")]
            public string birth_dt { get; set; }
            public Nullable<System.DateTime> reg_dt { get; set; }
            public Nullable<System.DateTime> edit_dt { get; set; }
            [Required(ErrorMessage = "제목을 입력해 주세요.")]
            public string title { get; set; }
            [AllowHtml]
            [Required(ErrorMessage = "내용을 입력해 주세요.")]
            public string contents { get; set; }
        }   
    }

}