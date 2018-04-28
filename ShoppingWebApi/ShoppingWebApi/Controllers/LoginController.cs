using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.Models;
using ShoppingWebApi.EntityModel;

namespace ShoppingWebApi.Controllers
{
    public class LoginController : Controller
    {
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();

        [HttpPost]
        public JsonResult getLogin(tblLoginModel collection)
        {
            try
            {
                var result = _objShopdb.tblLogins.Where(a=>a.UserName == collection.UserName && a.Password == collection.Password).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);

                //var result = objCabdb.tblAreas.Where(a => a.Area == a.Area).ToList();
                //return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = "Not Success";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult getLoginscan(tblCardMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblCardMasters.Where(a => a.CardNo == collection.CardNo && a.ActDact == collection.ActDact).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);

                //var result = objCabdb.tblAreas.Where(a => a.Area == a.Area).ToList();
                //return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = "Not Success";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult getLoginscanact(tblCardMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblCardMasters.Where(a => a.CardPinno == collection.CardPinno).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);

                //var result = objCabdb.tblAreas.Where(a => a.Area == a.Area).ToList();
                //return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = "Not Success";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpPost]
        //public JsonResult getLogindata(tblCardMasterModel collection)
        //{
        //    try
        //    {
        //        var result = _objShopdb.tblCardMasters.Where(a => a.CardNo == collection.CardNo && a.CardPinno == collection.CardPinno).ToList();
        //        return Json(result, JsonRequestBehavior.AllowGet);

        //        //var result = objCabdb.tblAreas.Where(a => a.Area == a.Area).ToList();
        //        //return Json(result, JsonRequestBehavior.AllowGet);

        //    }
        //    catch
        //    {
        //        result _objResult = new result();
        //        _objResult.success = 0;
        //        _objResult.msg = "Not Success";
        //        return Json(_objResult, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public JsonResult UpdateAct(tblCardMasterModel collection)
        {

            try
            {
                var _objupdateitem = _objShopdb.tblCardMasters.Where(a => a.CardNo == collection.CardNo).FirstOrDefault();

                _objupdateitem.ActDact = collection.ActDact;
                // _objupdateitem.ActDct = collection.ActDct;
                _objShopdb.Entry(_objupdateitem).State = System.Data.Entity.EntityState.Modified;

                _objShopdb.SaveChanges();
                result _objResult = new result();
                _objResult.success = 1;
                _objResult.msg = "Update";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = "Not Success";
                return Json(_objResult);
            }
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();

        }
    }
}