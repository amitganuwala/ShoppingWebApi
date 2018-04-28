using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.EntityModel;
using ShoppingWebApi.Models;

namespace ShoppingWebApi.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();
        [HttpPost]
        public JsonResult SelectActiveCard(tblCardMasterModel Model)
        {
            try
            {
                var result = _objShopdb.tblCardMasters.Where(a => a.ActDact == Model.ActDact);
                return Json(result, JsonRequestBehavior.AllowGet);
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
        public JsonResult SelectorderDetail(tblOrderModel Model)
        {
            try
            {
                var result = _objShopdb.tblOrders.Where(a => a.ActDct == Model.ActDct && a.CardId == Model.CardId);
                return Json(result, JsonRequestBehavior.AllowGet);
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
        public JsonResult SelectQty(tblOrderModel Model)
        {
            try
            {
                var result = _objShopdb.tblOrders.Where(a => a.ItemNo == Model.ItemNo);
                return Json(result, JsonRequestBehavior.AllowGet);
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
        public JsonResult SaveSaleDetail(tblSaleDetailModel Model)
        {
            try
            {
                 tblSaleDetail _objItem = new tblSaleDetail();
                _objItem.SaleItemName = Model.SaleItemName;
                _objItem.SaleRate = Model.SaleRate;
                _objItem.SaleQty = Model.SaleQty;
                _objItem.SaleAmount = Model.SaleAmount;
                _objItem.SaleItemNo = Model.SaleItemNo;

                _objShopdb.tblSaleDetails.Add(_objItem);
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
        public JsonResult DeleteOrder(tblOrderModel Model)
        {
            
            try
            {
                var _objDel = _objShopdb.tblOrders.Where(a => a.CardId == Model.CardId).ToList();
                foreach(var item in _objDel)
                {
                    _objShopdb.tblOrders.Remove(item);
                    _objShopdb.SaveChanges();
                }
                

                result _objResult = new result();
                _objResult.success = 1;
                _objResult.msg = "Deleted";
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
        [HttpPost]
        public JsonResult UpdateCardMaster(tblCardMasterModel Model)
        {
            try
            {
                var data = _objShopdb.tblCardMasters.Where(a => a.CardNo == Model.CardNo).FirstOrDefault();
                data.ActDact = Model.ActDact;

                _objShopdb.Entry(data).State = System.Data.Entity.EntityState.Modified;
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
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult SelectAllOrder()
        {
            try
            {
                var result = _objShopdb.tblOrders.ToList();
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
    }
}