using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.Models;
using ShoppingWebApi.EntityModel;

namespace ShoppingWebApi.Controllers
{
    public class RegController : Controller
    {

        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();

        [HttpPost]
        public JsonResult SetReg(tblRegModel collection)
        {
            try
            {
                tblReg _objreg = new tblReg();               
                _objreg.CustomerName = collection.CustomerName;
                _objreg.Custaddress = collection.Custaddress;
                _objreg.MobileNo = collection.MobileNo;                
                _objreg.PinNo = collection.PinNo;               

                _objShopdb.tblRegs.Add(_objreg);
                _objShopdb.SaveChanges();

                result _objResult = new result();
                _objResult.success = 1;
                _objResult.msg = "Success";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result _objresult = new result();
                _objresult.success = 0;
                _objresult.msg = "Not Success";
                return Json(_objresult);
            }
        }

        [HttpPost]
        public JsonResult SetCardDet(tblCardMasterModel collection)
        {
            try
            {
                tblCardMaster _objcard = new tblCardMaster();
                _objcard.CardNo = collection.CardNo;
                _objcard.CardPinno = collection.CardPinno;
                _objcard.ActDact = collection.ActDact;                

                _objShopdb.tblCardMasters.Add(_objcard);
                _objShopdb.SaveChanges();

                result _objResult = new result();
                _objResult.success = 1;
                _objResult.msg = "Success";
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                result _objresult = new result();
                _objresult.success = 0;
                _objresult.msg = "Not Success";
                return Json(_objresult);
            }
        }

        [HttpPost]
        public JsonResult getRegLogin(tblRegModel collection)
        {
            try
            {
                var result = _objShopdb.tblRegs.Where(a => a.PinNo == collection.PinNo).ToList();
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
        public JsonResult getRegdet(tblRegModel collection)
        {
            try
            {
                var result = _objShopdb.tblRegs.Where(a => a.Regid == collection.Regid).ToList();
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

        [HttpGet]
        public JsonResult getReg(tblRegModel collection)
        {
            try
            {
                var result = _objShopdb.tblRegs.ToList();
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

        // GET: Reg
        public ActionResult Index()
        {
            return View();
        }
    }
}