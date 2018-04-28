using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.Models;
using ShoppingWebApi.EntityModel;

namespace ShoppingWebApi.Controllers
{
    public class SaleController : Controller
    {
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();
        
        [HttpPost]
        public JsonResult SetOrder(tblOrderModel collection)
        {
            try
            {
                tblOrder _objOrder = new tblOrder();
                _objOrder.ID = Convert.ToDecimal(collection.ID);
                _objOrder.ItemType = collection.ItemType;
                _objOrder.ItemName = collection.ItemName;
                _objOrder.ItemNo = collection.ItemNo;
                _objOrder.Quantity = collection.Quantity;
                _objOrder.Rate = collection.Rate;
                _objOrder.TotAmt = collection.TotAmt;
                _objOrder.CardId = collection.CardId;
                _objOrder.ActDct = collection.ActDct;

                _objShopdb.tblOrders.Add(_objOrder);
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
        public JsonResult DeleteitemOrder(tblOrderModel collection)
        {
            try
            {
                var _objDel = _objShopdb.tblOrders.Where(a => a.CardId == collection.CardId && a.ItemNo == collection.ItemNo).ToList();

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
        public JsonResult UpdateitemOrder(tblOrderModel collection)
        {

            try
            {
                var _objupdateitem = _objShopdb.tblOrders.Where(a => a.ItemNo == collection.ItemNo && a.CardId==collection.CardId).FirstOrDefault();

                _objupdateitem.Quantity = collection.Quantity;
                _objupdateitem.TotAmt = collection.TotAmt;
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

        [HttpPost]
        public JsonResult UpdateminusitemOrder(tblOrderModel collection)
        {

            try
            {
                var _objupdateminusitem = _objShopdb.tblOrders.Where(a => a.ItemNo == collection.ItemNo && a.CardId == collection.CardId).FirstOrDefault();

                _objupdateminusitem.Quantity = collection.Quantity;
                _objupdateminusitem.TotAmt = collection.TotAmt;
                // _objupdateitem.ActDct = collection.ActDct;
                _objShopdb.Entry(_objupdateminusitem).State = System.Data.Entity.EntityState.Modified;

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

        [HttpPost]
        public JsonResult SetSale(tblSaleModel collection)
        {
            try
            {
                tblSale _objpurchase = new tblSale();
                _objpurchase.SaleInvoiceID = collection.SaleInvoiceID;
                _objpurchase.SaleDate = collection.SaleDate;
                _objpurchase.CustomerName = collection.CustomerName;
                _objpurchase.Address = collection.Address;
                _objpurchase.TotalQty = collection.TotalQty;               
                _objpurchase.GrandAmt = collection.GrandAmt;


                _objShopdb.tblSales.Add(_objpurchase);
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
        public JsonResult SetSaledet(tblSaleDetailModel collection)
        {
            try
            {
                tblSaleDetail _objsaledet = new tblSaleDetail();
                _objsaledet.SaleItemName = collection.SaleItemName;                
                _objsaledet.SaleQty = collection.SaleQty;
                _objsaledet.SaleRate = collection.SaleRate;
                _objsaledet.SaleAmount = collection.SaleAmount;

                _objShopdb.tblSaleDetails.Add(_objsaledet);
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
        public JsonResult getSaleMax(tblSaleModel collection)
        {
            try
            {
                var maxValue = _objShopdb.tblSales.Max(x => x.SaleInvoiceID);
                var result = _objShopdb.tblSales.First(x => x.SaleInvoiceID == maxValue);
                return Json(result, JsonRequestBehavior.AllowGet);

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
        public JsonResult Updatesaleitem(tblItemMasterModel collection)
        {

            try
            {
                var _objupdateitem = _objShopdb.tblItemMasters.Where(a => a.ItemName == collection.ItemName).FirstOrDefault();

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

        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
    }
}