using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects;
using SubmitForm.Models;

namespace SubmitForm.Controllers
{
    public class SubmitController : Controller
    {
        testEntities DB = new testEntities();

        [HttpGet]
        public ActionResult Submit_Form()
        {
            TB_SUBMIT model = new TB_SUBMIT();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Submit_Form(TB_SUBMIT model)
        {
            ObjectParameter seq = new ObjectParameter("seq", typeof(int));
            DB.up_submit_insert
                    (
                        model.name,
                        model.title,
                        model.contents,
                        model.hp1,
                        model.hp2,
                        model.hp3,
                        model.post_no,
                        model.adress1,
                        model.adress2,
                        model.birth_dt,
                        seq
                    );
            ViewBag.seq = seq;
            return RedirectToAction("Detail",new { seq = seq.Value });
        }
        [HttpGet]
        public ActionResult List( string search_h, byte rank_type_h = 2, int row_page_h = 10, int pageNumber = 1, byte search_type_h = 1) {
            //List<up_submit_selectList_Result> model = new List<up_submit_selectList_Result>().ToList();
            TB_SUBMIT_LIST model = new TB_SUBMIT_LIST();            
            ObjectParameter totalRecords = new ObjectParameter("TotalRecords", typeof(int));            

            model.submit_list = DB.up_submit_selectList (
                row_page_h,
                pageNumber,
                search_type_h,
                search_h,
                rank_type_h,
                totalRecords).ToList();
            
            int totalblock = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalRecords.Value) / row_page_h));
            int firstpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble((pageNumber - 1) / row_page_h) * row_page_h + 1));
            int lastpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pageNumber) / row_page_h) * row_page_h);
            if (lastpage > totalblock )
            {
                lastpage = totalblock;
            }            
            ViewBag.total = totalRecords.Value;
            ViewBag.lastpage = lastpage;
            ViewBag.firstpage = firstpage;
            ViewBag.totalblock = totalblock;
            ViewBag.nowpage = pageNumber;
            ViewBag.rowsPerPage = row_page_h;
            ViewBag.search = search_h;
            ViewBag.searchtype = search_type_h;
            ViewBag.ranktype = rank_type_h;


            return View(model);
        }
        [HttpGet]
        public ActionResult Detail(int seq , int row_page_h = 5, int pageNumber = 1)
        {
            //List<string> list = new List<string>();
            //IEnumerable<string> enumerable = new List<string>();
            //ICollection<string> collection = new List<string>();
            //IList<string> iList = new List<string>();
            


            //up_submit_selectdetail_Result model = new up_submit_selectdetail_Result();
            Detail_List model = new Detail_List();
            model.detail = DB.up_submit_selectdetail
                (
                    seq
                ).SingleOrDefault();
            ObjectParameter totalRecords = new ObjectParameter("TotalRecords", typeof(int));
            model.coment_list = DB.up_coment_select_list
                (
                    seq,
                    row_page_h,
                    pageNumber,
                    totalRecords
                ).ToList();
            int totalblock = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalRecords.Value) / row_page_h));
            int firstpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble((pageNumber - 1) / row_page_h) * row_page_h + 1));
            int lastpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pageNumber) / row_page_h) * row_page_h);

            if (lastpage > totalblock)
            {
                lastpage = totalblock;
            }

            ViewBag.seq = seq;
            ViewBag.lastpage = lastpage;
            ViewBag.firstpage = firstpage;
            ViewBag.totalblock = totalblock;
            ViewBag.nowpage = pageNumber;
            ViewBag.rowsPerPage = row_page_h;

            return View(model);
        }

        [HttpPost]
        public ActionResult Detail(Detail_List model)
        {             
            DB.up_coment_insert
                (
                    model.detail.seq,
                    model.coment.coment
                );            
            return RedirectToAction("Detail", new { seq = model.detail.seq });
        }
        public ActionResult Modify(int seq)
        {            
            up_submit_selectdetail_Result model = new up_submit_selectdetail_Result();
            model = DB.up_submit_selectdetail
                (
                    seq
                ).SingleOrDefault();
            return View(model);
        }
        [HttpPost]        
        public ActionResult Modify(TB_SUBMIT model)
        {
            model.contents = model.contents.Replace("<","&lt");
            model.contents = model.contents.Replace(">", "&gt");
            DB.up_submit_selectupdate
                (
                    model.seq,
                    model.name,
                    model.title,
                    model.contents,
                    model.hp1,
                    model.hp2,
                    model.hp3,
                    model.post_no,
                    model.adress1,
                    model.adress2,
                    model.birth_dt
                );
            return RedirectToAction("Detail",new { seq = model.seq });
        }
    }
}