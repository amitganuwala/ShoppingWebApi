using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.Models;
using ShoppingWebApi.EntityModel;

namespace ShoppingWebApi.Controllers
{
    public class PurchaseController : Controller
    {
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();

        [HttpPost]
        public JsonResult SetPurchase(tblPurchaseModel collection)
        {
            try
            {
                tblPurchase _objpurchase = new tblPurchase();
                _objpurchase.InvoiceID = collection.InvoiceID;
                _objpurchase.Date = collection.Date;
                _objpurchase.ShopName = collection.ShopName;
                _objpurchase.SupplierName = collection.SupplierName;
                _objpurchase.Address = collection.Address;
                _objpurchase.GST = collection.GST;
                _objpurchase.GrossAmount = collection.GrossAmount;
                _objpurchase.CGSTPer = collection.CGSTPer;
                //_objpurchase.CGSTAmt = collection.CGSTAmt;
                _objpurchase.SGSTPer = collection.SGSTPer;
                ////_objpurchase.SGSTAmt = collection.SGSTAmt;
                _objpurchase.GrandTotal = collection.GrandTotal;                

                _objShopdb.tblPurchases.Add(_objpurchase);
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
        public JsonResult SetPurchasedet(tblPurchaseDetailModel collection)
        {
            try
            {
                tblPurchaseDetail _objpurchasedet = new tblPurchaseDetail();
                _objpurchasedet.ID = collection.ID;
                _objpurchasedet.ItemName = collection.ItemName;
                _objpurchasedet.ItemType = collection.ItemType;
                _objpurchasedet.ItemNo = collection.ItemNo;
                _objpurchasedet.Qty = collection.Qty;
                _objpurchasedet.Rate = collection.Rate;
                _objpurchasedet.Amount = collection.Amount;
                _objpurchasedet.HSN = collection.HSN;
               
                _objShopdb.tblPurchaseDetails.Add(_objpurchasedet);
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





        [HttpPost]
        public JsonResult UpdateStatus(tblOrderModel collection)
        {

            try
            {
                var _objupdateitem = _objShopdb.tblOrders.Where(a => a.ItemNo == collection.ItemNo && a.ItemType == collection.ItemType && a.ItemName == collection.ItemName && a.CardId==collection.CardId).FirstOrDefault();

                _objupdateitem.ActDct = collection.ActDct;
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
        public JsonResult Updatestock(tblStockModel collection)
        {

            try
            {
                var _objupdatestock = _objShopdb.tblStocks.Where(a => a.ItemNo == collection.ItemNo && a.ItemType == collection.ItemType && a.ItemName == collection.ItemName).FirstOrDefault();

                _objupdatestock.StockQty = collection.StockQty;
                _objShopdb.Entry(_objupdatestock).State = System.Data.Entity.EntityState.Modified;

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
        public JsonResult DeletePurchase(tblPurchaseModel collection)
        {
            try
            {
                //var _objDel = _objShopdb.tblItemMasters.Where(a => a.ID == collection.ID).ToList();
                //foreach (var model in _objDel)
                //{
                //    _objShopdb.tblItemMasters.Remove(model);
                //    _objShopdb.SaveChanges();
                //}
                var _objDel = _objShopdb.tblPurchases.Where(a=>a.InvoiceID == collection.InvoiceID).FirstOrDefault();
                _objShopdb.tblPurchases.Remove(_objDel);
                _objShopdb.SaveChanges();

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
        public JsonResult DeletePurchasedetail(tblPurchaseDetailModel collection)
        {
            try
            {
                var _objDel = _objShopdb.tblPurchaseDetails.Where(a => a.ID == collection.ID).ToList();
                foreach (var model in _objDel)
                {
                    _objShopdb.tblPurchaseDetails.Remove(model);
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

        [HttpGet]
        public JsonResult getPurchase()
        {
            try
            {
                var result = _objShopdb.tblPurchases.ToList();
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
        public JsonResult getStock()
        {
            try
            {
                var result = _objShopdb.tblItemMasters.ToList();
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
        public JsonResult getPurchasedetails(tblPurchaseDetailModel collection)
        {
            try
            {
                var result = _objShopdb.tblPurchaseDetails.Where(a=>a.ID == collection.ID).ToList();
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
        public JsonResult getPurchaseMax(tblPurchaseModel collection)
        {
            try
            {
                var maxValue = _objShopdb.tblPurchases.Max(x => x.InvoiceID);
                var result = _objShopdb.tblPurchases.First(x => x.InvoiceID == maxValue);
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
        public JsonResult getItemnamecmb(tblItemMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a => a.ItemType == collection.ItemType).ToList();
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
        public JsonResult getItemnocmb(tblItemMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a => a.ItemName == collection.ItemName).ToList();
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

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
    }
}