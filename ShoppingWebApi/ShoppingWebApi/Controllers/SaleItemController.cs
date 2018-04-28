using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.EntityModel;
using ShoppingWebApi.Models;

namespace ShoppingWebApi.Controllers
{
    public class SaleItemController : Controller
    {
        // GET: SaleItem
        public ActionResult Index()
        {
            return View();
        }
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();


        [HttpPost]
        public JsonResult SelectItemOrder(tblOrderModel Collection)
        {
            try
            {
                var result = _objShopdb.tblOrders.Where(a => a.CardId == Collection.CardId && a.ActDct=="A").ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ec)
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = ec.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }




    



        [HttpPost]
        public JsonResult SelectItem(tblItemMasterModel Collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a => a.ID == Collection.ID).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ec)
            {
                result _objResult = new result();
                _objResult.success = 0;
                _objResult.msg = ec.ToString();
                return Json(_objResult, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult getItemqty(tblItemMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a => a.ItemName == collection.ItemName && a.ItemNo == collection.ItemNo && a.ItemType == collection.ItemType).ToList();
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
        public JsonResult Updateitem(tblItemMasterModel collection)
        {

            try
            {
                var _objupdateitem = _objShopdb.tblItemMasters.Where(a => a.ItemNo == collection.ItemNo && a.ItemType == collection.ItemType && a.ItemName == collection.ItemName).FirstOrDefault();

                _objupdateitem.Quantity = collection.Quantity;
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
    }
}