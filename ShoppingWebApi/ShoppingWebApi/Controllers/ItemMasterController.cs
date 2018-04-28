using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebApi.Models;
using ShoppingWebApi.EntityModel;

namespace ShoppingWebApi.Controllers
{
    public class ItemMasterController : Controller
    {
        ShoppingMallEntities1 _objShopdb = new ShoppingMallEntities1();

        [HttpGet]
        public JsonResult getItem()
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
        public JsonResult getSaleItem(tblItemMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a=>a.ItemName == collection.ItemName).ToList();
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
        public JsonResult getItemdet(tblItemMasterModel collection)
        {
            try
            {
                var result = _objShopdb.tblItemMasters.Where(a => a.ItemNo == collection.ItemNo).ToList();
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
        public JsonResult SetItem(tblItemMasterModel collection)
        {
            try
            {
                tblItemMaster _objItem = new tblItemMaster();
                _objItem.ID = collection.ID;
                _objItem.ItemName = collection.ItemName;
                _objItem.ItemType = collection.ItemType;
                _objItem.ItemNo = collection.ItemNo;
                _objItem.Quantity = collection.Quantity;
                _objItem.Rate = collection.Rate;

                _objShopdb.tblItemMasters.Add(_objItem);
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


        //[HttpPost]
        //public JsonResult SetOrder(tblOrderModel collection)
        //{
        //    try
        //    {
        //        //tblOrder _objItem = new tblOrder();
        //        _objItem.ID = collection.ID;
        //        _objItem.ItemName = collection.ItemName;
        //        _objItem.ItemType = collection.ItemType;
        //        _objItem.ItemNo = collection.ItemNo;
        //        _objItem.Quantity = collection.Quantity;
        //        _objItem.Rate = collection.Rate;

        //        _objShopdb.tblOrders.Add(_objItem);
        //        _objShopdb.SaveChanges();

        //        result _objResult = new result();
        //        _objResult.success = 1;
        //        _objResult.msg = "Success";
        //        return Json(_objResult, JsonRequestBehavior.AllowGet);
        //    }
        //    catch
        //    {
        //        result _objresult = new result();
        //        _objresult.success = 0;
        //        _objresult.msg = "Not Success";
        //        return Json(_objresult);
        //    }
        //}




        [HttpPost]
        public JsonResult SetStock(tblStockModel collection)
        {
            try
            {
                tblStock _objstock = new tblStock();
                _objstock.StockID = collection.StockID;
                _objstock.ItemName = collection.ItemName;
                _objstock.ItemType = collection.ItemType;
                _objstock.ItemNo = collection.ItemNo;
                _objstock.StockQty = collection.StockQty;
                _objstock.StockRate = collection.StockRate;

                _objShopdb.tblStocks.Add(_objstock);
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
        public JsonResult Deleteitem(tblItemMasterModel collection)
        {
            try
            {
                var _objDel = _objShopdb.tblItemMasters.Where(a=>a.ID == collection.ID).FirstOrDefault();
                _objShopdb.tblItemMasters.Remove(_objDel);
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
        public JsonResult DeleteItemType(tblItemTypeModel Collection)
        {
            try
            {
                tblItemType _objitemtype = new tblItemType();
                var _objDel = _objShopdb.tblItemTypes.Where(a => a.ItemType == Collection.ItemType).FirstOrDefault();
                _objShopdb.tblItemTypes.Remove(_objDel);
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

        [HttpGet]
        public JsonResult getItemtype()
        {
            try
            {
                var result = _objShopdb.tblItemTypes.ToList();
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
        public JsonResult getItemname()
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
        public JsonResult SetItemtype(tblItemTypeModel collection)
        {
            try
            {
                tblItemType _objitemtype = new tblItemType();
                _objitemtype.ItemType = collection.ItemType;
               

                _objShopdb.tblItemTypes.Add(_objitemtype);
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

        [HttpGet]
        public JsonResult getItemMax()
        {
            try
            {
                var maxValue = _objShopdb.tblItemMasters.Max(x => x.ID);
                var result = _objShopdb.tblItemMasters.First(x => x.ID == maxValue);
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


        // GET: ItemMaster
        public ActionResult Index()
        {
            return View();
        }
    }
}